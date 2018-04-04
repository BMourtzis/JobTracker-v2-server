using JobTrackerDomain.Interfaces;
using JobTrackerDomain.Registers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain
{
    public class Facade : IDisposable
    {
        ClientRegister clientRegister = new ClientRegister();

        #region Client

        public IClient CreateClient(string firstname, string lastname, string businessName, string shortname)
        {
            IClient client = clientRegister.CreateClient(firstname, lastname, businessName, shortname);
            return client;
        }

        public IClient UpdateClient(Guid id, string firstname, string lastname, string businessName)
        {
            var client = clientRegister.UpdateClient(id, firstname, lastname, businessName);
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
            IEnumerable<IClient> clients;
            clients = clientRegister.GetClients();
            return clients;
        }

        public bool EnableClient(Guid id)
        {
            bool enabled;
            enabled = clientRegister.EnableClient(id);
            return enabled;
        }

        public bool DisableClient(Guid id)
        {
            bool enabled;
            enabled = clientRegister.DisableClient(id);
            return enabled;
        }

        #endregion

        public void Dispose()
        {
            clientRegister.Dispose();
        }
    }
}
