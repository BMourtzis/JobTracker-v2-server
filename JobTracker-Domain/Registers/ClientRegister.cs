using JobTrackerDomain.Interfaces;
using JobTrackerDomain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Registers
{
    internal class ClientRegister : IDisposable
    {
        private JobsDbContext _context;

        public ClientRegister()
        {
            //_context = new JobsDbContext();
        }

        public ClientRegister(JobsDbContext dbContext)
        {
            _context = dbContext;
        }

        #region Client

        public Client CreateClient(string firstname, string lastname, string businessName, string invoicePrefix, string address, string email, string primaryPhone)
        {
            var client = new Client(firstname, lastname, businessName, invoicePrefix, address, email, primaryPhone);
            _context.Clients.Add(client);
            _context.SaveChangesAsync();

            return client;
        }

        public Client UpdateClient(Guid id, string firstname, string lastname, string businessName, string address, string email, string primaryPhone)
        {
            var client = GetClient(id);
            client.Update(firstname, lastname, businessName, address, email, primaryPhone);
            _context.Clients.Update(client);
            _context.SaveChanges();
            return client;
        }

        public Client EnableClient(Guid id)
        {
            var client = GetClient(id);
            client.Enable();
            _context.Clients.Update(client);
            _context.SaveChanges();
            return client;
        }

        public Client DisableClient(Guid id)
        {
            var client = GetClient(id);
            client.Disable();
            _context.Clients.Update(client);
            _context.SaveChanges();
            return client;
        }

        public void DeleteClient(Guid id)
        {
            var client = GetClient(id);
            // TODO: if jobs length is zero, else throw exception
            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        public IEnumerable<Client> GetClients()
        {
            var clients = _context.Clients.ToList();
            return clients;
        }

        public Client GetClient(Guid id)
        {
            var client = _context.Clients.Find(id);
            //maybe throw error on no client found
            return client;
        }

        #endregion

        #region Contact

        public Contact AddContact(Guid clientId, string name, string contactValue, int type)
        {
            var contact = GetClient(clientId).addContact(name, contactValue, type);
            _context.SaveChanges();
            return contact;
        }

        public Contact UpdateContact(Guid clientId, Guid contactId, string name, string contactValue)
        {
            var contact = GetClient(clientId).updateContact(contactId, name, contactValue);
            _context.SaveChanges();
            return contact;
        }

        public void RemoveContact(Guid clientId, Guid contactId)
        {
            GetClient(clientId).removeContact(contactId);
        }

        #endregion

        public void Dispose()
        {
            //_context.Dispose();
        }
    }
}
