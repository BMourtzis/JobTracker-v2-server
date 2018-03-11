using JobTrackerDomain.StateMachines.JobInstance;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Models
{
    class JobInstance
    {
        private Guid _id;
        private DateTime _bookingTime;
        private Decimal _price; //With GST
        private JIState _state;


        #region Constructor

        private JobInstance() { }

        public JobInstance(DateTime bookingTime, Decimal price)
        {
            _bookingTime = bookingTime;
            _price = price; // Should get GST percentage from settings
            _state = new JIPendingState();
        }

        #endregion

        #region Properties

        public Guid ID
        {
            get => _id;
        }

        public DateTime BookingTime
        {
            get => _bookingTime;
            set
            {
                _state.UpdateBookingTime(delegate(){
                    _bookingTime = value;
                });
            }
        }

        public Decimal Price
        {
            get => _price;
            set
            {
                _state.UpdatePrice(delegate ()
                {
                    _price = _price + value * 0.1m;
                });
            }
        }

        public int StateCode
        {
            get => _state.Code;
        }

        public string StateDescription
        {
            get => _state.Description;
        }

        #endregion

        #region Methods

        #region State Machine

        public void Pending()
        {
            _state.Done(delegate ()
            {
                _state = new JIPendingState();
            });
        }

        public void Done()
        {
            _state.Done(delegate ()
            {
                _state = new JIDoneState();
            });
        }

        public void Invoiced()
        {
            _state.Done(delegate ()
            {
                _state = new JIInvoicedState();
            });
        }

        public void Paid()
        {
            _state.Done(delegate ()
            {
                _state = new JIPaidState();
            });
        }

        #endregion 

        #endregion
    }
}
