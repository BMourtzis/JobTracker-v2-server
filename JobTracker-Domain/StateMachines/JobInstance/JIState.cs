using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.StateMachines.JobInstance
{
    internal abstract class JIState
    {
        private int _statecode;
        private string _description;

        #region Constructors

        private JIState() { }

        protected JIState(int statecode, string description)
        {
            _statecode = statecode;
            _description = description;
        }

        #endregion

        #region Properties

        public int Code
        {
            get => _statecode;
        }

        public string Description
        {
            get => _description;
        }

        #endregion

        #region Methods

        public abstract void UpdateBookingTime(Action action);

        public abstract void UpdatePrice(Action action);

        #region State Machine

        public abstract void Pending(Action action);

        public abstract void Done(Action action);

        public abstract void Invoiced(Action action);

        public abstract void Paid(Action action);

        #endregion

        #endregion
    }
}
