using JobTrackerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.Client
{
    internal class EnabledState : ClientState
    {
        #region Constructors

        public EnabledState(): base(true) { }

        #endregion

        #region Setters

        public override void setBusinessName(Action action)
        {
            action();
        }

        public override void setFirstName(Action action)
        {
            action();
        }

        public override void setLastName(Action action)
        {
            action();
        }

        public override void setInvoicePrefix(Action action)
        {
            action();
        }

        public override void setAddress(Action action)
        {
            action();
        }

        public override void setEmail(Action action)
        {
            action();
        }

        public override void setPrimaryPhone(Action action)
        {
            action();
        }

        #endregion

        #region Methods

        public override void CreateSingleJob(Action action)
        {
            action();
        }

        public override void CreateTemplateJob(Action action)
        {
            action();
        }

        public override void Disable(Action action)
        {
            action();
        }

        public override void Enable(Action action)
        {
            throw new BusinessRuleException("The client is already enabled.");
        }

        public override void addContact(Action action)
        {
            action();
        }

        public override void removeContact(Action action)
        {
            action();
        }

        public override void updateContact(Action action)
        {
            action();
        }

        public override void findContact(Action action)
        {
            action();
        }

        #endregion
    }
}
