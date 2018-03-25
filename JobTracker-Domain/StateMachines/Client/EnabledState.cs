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

        public override void setShortName(Action action)
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

        #endregion
    }
}
