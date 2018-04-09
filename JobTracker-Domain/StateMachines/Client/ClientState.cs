using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.Client
{
    internal abstract class ClientState
    {
        private bool _enabled;

        #region Constructors

        private ClientState() { }

        protected ClientState(bool enabled)
        {
            _enabled = enabled;
        }

        #endregion

        #region Properties

        public bool Enabled
        {
            get => _enabled;
        }

        #endregion

        #region Setters

        public abstract void setFirstName(Action action);
        public abstract void setLastName(Action action);
        public abstract void setBusinessName(Action action);
        public abstract void setInvoicePrefix(Action action);
        public abstract void setAddress(Action action);
        public abstract void setPrimaryPhone(Action action);
        public abstract void setEmail(Action action);

        #endregion

        #region Methods 

        public abstract void Enable(Action action);
        public abstract void Disable(Action action);

        public abstract void CreateSingleJob(Action action);
        public abstract void CreateTemplateJob(Action action);

        public abstract void addContact(Action action);
        public abstract void removeContact(Action action);

        #endregion
    }

    internal enum ClientStatus
    {
        Enabled,
        Disabled
    }
}
