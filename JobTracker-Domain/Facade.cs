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

        #endregion

        #region Contact

        #endregion

        public void Dispose()
        {
            clientRegister.Dispose();
        }
    }
}
