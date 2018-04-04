using JobTrackerDomain.Exceptions;
using JobTrackerDomain.Interfaces;
using JobTrackerDomain.StateMachines.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobTrackerDomain.Models
{
    internal class Client: IClient
    {
        // fields
        private Guid _id;
        private string _firstname;
        private string _lastname;
        private string _businessName;
        private string _shortname;
        private ClientState _state;

        private List<Job> _jobs;

        #region Constructor

        private Client() { }

        public Client(string firstname, string lastname, string businessName, string shortname)
        {
            _firstname = firstname;
            _lastname = lastname;
            _businessName = businessName;
            _shortname = shortname;
            _state = new EnabledState();
        }

        #endregion

        #region Properties

        [Key]
        public Guid ID
        {
            get => _id;
            private set => _id = value;
        }

        [Required]
        public string FirstName
        {
            get => _firstname;
            set
            {
                if (value != null)
                {
                    _state.setFirstName(delegate ()
                    {
                        _firstname = value;
                    });
                }

            }
        }

        [Required]
        public string LastName
        {
            get => _lastname;
            set
            {
                if(value != null)
                {
                    _state.setLastName(delegate ()
                    {
                        _lastname = value;
                    });
                }
            }
        }

        [Required]
        public string FullName
        {
            get => $"{_firstname} {_lastname}";
        }

        [Required]
        public string BusinessName
        {
            get => _businessName;
            set
            {
                if(value != null)
                {
                    _state.setBusinessName(delegate ()
                    {
                        _businessName = value;
                    });
                }
            }
        }

        [Required]
        public string ShortName
        {
            get => _shortname;
            set
            {
                if(value != null)
                {
                    _state.setShortName(delegate ()
                    {
                        _shortname = value;
                    });
                }
            }
        }

        public bool Enabled
        {
            get => _state.Enabled;
        }

        public IEnumerable<Job> Jobs
        {
            get => _jobs;
        }

        #endregion

        #region Methods

        public Job CreateSingleJob(string name, Decimal price, DateTime bookingDate)
        {
            Job job = null;
            _state.CreateSingleJob(delegate ()
            {
                job = new Job(name, price, _id, bookingDate);
            });
            return job;
        }

        public Job CreateTemplateJob(string name, Decimal price)
        {
            Job job = null;
            _state.CreateTemplateJob(delegate ()
            {
                //TODO: change with the new constructor
                job = new Job(name, price, _id, 1);
            });
            return job;
        }

        public void Enable()
        {
            _state.Enable(delegate ()
            {
                _state = new EnabledState();
            });
        }

        public void Disable()
        {
            _state.Disable(delegate () 
            {
                _state = new DisabledState();
            });
        }

        #endregion
    }
}
