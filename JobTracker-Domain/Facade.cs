using JobTrackerDomain.Interfaces;
using JobTrackerDomain.Registers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain
{
    public class Facade : IDisposable
    {
        ClientRegister clientRegister;

        public Facade()
        {
            clientRegister = new ClientRegister();
        }

        public Facade(DbContextOptions options)
        {
            clientRegister = new ClientRegister(new JobsDbContext(options));
        }

        #region Client

        public IClient CreateClient(string firstname, string lastname, string businessName, string invoicePrefix, string address, string email, string primaryPhone)
        {
            IClient client = clientRegister.CreateClient(firstname, lastname, businessName, invoicePrefix, address, email, primaryPhone);
            return client;
        }

        public IClient UpdateClient(Guid id, string firstname, string lastname, string businessName, string address, string email, string primaryPhone)
        {
            var client = clientRegister.UpdateClient(id, firstname, lastname, businessName, address, email, primaryPhone);
            return client;
        }

        public IClient GetClient(Guid id)
        {
            IClient client;
            client = clientRegister.GetClient(id);
            return client;
        }

        public IEnumerable<IClient> GetClients()
        {
            var clients = clientRegister.GetClients();
            return clients;
        }

        public IClient EnableClient(Guid id)
        {
            var client = clientRegister.EnableClient(id);
            return client;
        }

        public IClient DisableClient(Guid id)
        {
            var client = clientRegister.DisableClient(id);
            return client;
        }

        public void DeleteClient(Guid id)
        {
            clientRegister.DeleteClient(id);
        }

        #endregion

        #region Contact

        public IContact AddContact(Guid clientId, string name, string contactValue, int type)
        {
            var contact = clientRegister.AddContact(clientId, name, contactValue, type);
            return contact;
        }

        public IEnumerable<IContact> AddContact(Guid clientId, List<Tuple<string, string, int>> details)
        {
            var contacts = new List<IContact>();
            foreach(var dets in details)
            {
                contacts.Add(AddContact(clientId, dets.Item1, dets.Item2, dets.Item3));
            }

            return contacts;
        }

        public IContact UpdateContact(Guid clientId, Guid contactId, string name, string contactValue)
        {
            var contact = clientRegister.UpdateContact(clientId, contactId, name, contactValue);
            return contact;
        }

        public void RemoveContact(Guid clientId, Guid contactId)
        {
            clientRegister.RemoveContact();
        }

        #endregion

        public void Dispose()
        {
            clientRegister.Dispose();
        }
    }
}
