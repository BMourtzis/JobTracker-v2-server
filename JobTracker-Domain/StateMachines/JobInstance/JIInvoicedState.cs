using JobTrackerDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.JobInstance
{
    internal class JIInvoicedState: JIState
    {
        #region Constructors

        public JIInvoicedState(): base(2, "Invoiced")
        {

        }

        #endregion

        #region Methods

        public override void UpdateBookingTime(Action action)
        {
            throw new JIStateException("Booking Time", "Invoiced");
        }

        public override void UpdatePrice(Action action)
        {
            throw new JIStateException("Price", "Invoiced");
        }

        #region State Machine

        public override void Pending(Action action)
        {
            throw new JIStateException("State", "Invoiced");
        }

        public override void Done(Action action)
        {
            action();
        }

        public override void Invoiced(Action action)
        {
            throw new JIStateException("State", "Invoiced");
        }

        public override void Paid(Action action)
        {
            action();
        }

        #endregion

        #endregion
    }
}
