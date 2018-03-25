using JobTrackerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.Client
{
    internal class DisabledState: ClientState
    {
        #region Constructors

        public DisabledState() : base(false) { }

        #endregion

        #region Setters

        public override void setBusinessName(Action action)
        {
            throw new BusinessRuleException("The client is disabled.");
        }

        public override void setFirstName(Action action)
        {
            throw new BusinessRuleException("The client is disabled.");
        }

        public override void setLastName(Action action)
        {
            throw new BusinessRuleException("The client is disabled.");
        }

        public override void setShortName(Action action)
        {
            throw new BusinessRuleException("The client is disabled.");
        }

        #endregion

        #region Methods

        public override void CreateSingleJob(Action action)
        {
            throw new BusinessRuleException("The client is disabled.");
        }

        public override void CreateTemplateJob(Action action)
        {
            throw new BusinessRuleException("The client is disabled.");
        }

        public override void Disable(Action action)
        {
            throw new BusinessRuleException("The client is already disabled.");
        }

        public override void Enable(Action action)
        {
            action();
        }

        #endregion
    }
}
