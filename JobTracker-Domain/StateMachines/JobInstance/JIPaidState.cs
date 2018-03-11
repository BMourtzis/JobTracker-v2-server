using JobTrackerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.JobInstance
{
    internal class JIPaidState: JIState
    {
        #region Constructors

        public JIPaidState(): base(3, "Paid")
        {

        }

        #endregion

        #region Methods

        public override void UpdateBookingTime(Action action)
        {
            throw new JIStateException("Booking Time", "Paid");
        }

        public override void UpdatePrice(Action action)
        {
            throw new JIStateException("Price", "Paid");
        }

        #region State Machine

        public override void Pending(Action action)
        {
            throw new JIStateException("State", "Paid");
        }

        public override void Done(Action action)
        {
            throw new JIStateException("State", "Paid");
        }

        public override void Invoiced(Action action)
        {
            action();
        }

        public override void Paid(Action action)
        {
            throw new JIStateException("State", "Paid");
        }


        #endregion

        #endregion
    }
}
