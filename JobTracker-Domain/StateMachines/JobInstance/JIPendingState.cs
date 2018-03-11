using System;
using System.Collections.Generic;
using System.Text;
using JobTrackerDomain.Exceptions;
using JobTrackerDomain.Models;

namespace JobTrackerDomain.StateMachines.JobInstance
{
    internal class JIPendingState: JIState
    {
        #region Consctructor

        public JIPendingState(): base(0, "Pending")
        {
            
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        public override void UpdateBookingTime(Action action)
        {
            action();
        }

        public override void UpdatePrice(Action action)
        {
            action();
        }

        #region State Machine

        public override void Pending(Action action)
        {
            throw new JIStateException("State", "Pending");
        }

        public override void Done(Action action)
        {
            action();
        }

        public override void Invoiced(Action action)
        {
            throw new JIStateException("State", "Pending");
        }

        public override void Paid(Action action)
        {
            throw new JIStateException("State", "Pending");
        }

        #endregion

        #endregion
    }
}
