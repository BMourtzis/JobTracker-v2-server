using JobTrackerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.JobInstance
{
    internal class JIDoneState: JIState
    {
        #region Constrcutors
        public JIDoneState() : base(1, "Done")
        {

        }

        #endregion

        #region Methods

        public override void UpdateBookingTime(Action action)
        {
            throw new JIStateException("Booking Time", "Done");
        }

        public override void UpdatePrice(Action action)
        {
            throw new JIStateException("Price", "Done");
        }

        #region State Machine

        public override void Pending(Action action)
        {
            action();
        }

        public override void Done(Action action)
        {
            throw new JIStateException("State", "Done");
        }

        public override void Invoiced(Action action)
        {
            action();
        }

        public override void Paid(Action action)
        {
            throw new JIStateException("State", "Done");
        }

        #endregion

        #endregion
    }
}
