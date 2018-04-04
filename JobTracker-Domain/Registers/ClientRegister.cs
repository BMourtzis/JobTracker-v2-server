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
            _context = new JobsDbContext();
        }

        #region Client

        public Client CreateClient(string firstname, string lastname, string businessName, string shortname)
        {
            var client = new Client(firstname, lastname, businessName, shortname);
            _context.Clients.Add(client);
            _context.SaveChangesAsync();

            return client;
        }

        public Client UpdateClient(Guid id, string firstname, string lastname, string businessName)
        {
            var client = GetClient(id);
            _context.Clients.Update(client); // Not sure why I have to do this
            client.FirstName = firstname;
            client.LastName = lastname;
            client.BusinessName = businessName;
            _context.SaveChanges();
            return client;
        }

        public IEnumerable<Client> GetClients()
        {
            var clients = _context.Clients.Where<Client>(c => c.Enabled == true);
            return clients;
        }

        public Client GetClient(Guid id)
        {
            var client = _context.Clients.Find(id);
            //maybe throw error on no client found
            return client;
        }

        public bool EnableClient(Guid id)
        {
            var client = GetClient(id);
            client.Enable();
            return client.Enabled;
        }

        public bool DisableClient(Guid id)
        {
            var client = GetClient(id);
            client.Disable();
            return client.Enabled;
        }

        #endregion

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
