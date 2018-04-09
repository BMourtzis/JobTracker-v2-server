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
            _context.Clients.Update(client); // Not sure why I have to do this
            client.FirstName = firstname;
            client.LastName = lastname;
            client.BusinessName = businessName;
            client.Address = address;
            client.Email = email;
            client.PrimaryPhone = primaryPhone;
            _context.SaveChanges();
            return client;
        }

        public Client EnableClient(Guid id)
        {
            var client = GetClient(id);
            client.Enable();
            _context.SaveChanges();
            return client;
        }

        public Client DisableClient(Guid id)
        {
            var client = GetClient(id);
            _context.Clients.Update(client);
            client.Disable();
            _context.SaveChanges();
            return client;
        }

        public Contact addContact(Guid clientId, string name, string phone)
        {
            var contact = GetClient(clientId).addContact(name, phone);
            _context.SaveChanges();
            return contact;
        }

        public IEnumerable<Client> GetClients()
        {
            var clients = _context.Clients.Where<Client>(c => c.Enabled == true);
            //var clients = _context.Clients;
            return clients;
        }

        public Client GetClient(Guid id)
        {
            var client = _context.Clients.Find(id);
            //maybe throw error on no client found
            return client;
        }

        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
