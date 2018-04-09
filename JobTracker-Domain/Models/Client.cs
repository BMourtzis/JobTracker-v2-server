using JobTrackerDomain.Exceptions;
using JobTrackerDomain.Interfaces;
using JobTrackerDomain.StateMachines.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobTrackerDomain.Models
{
    internal class Client : IClient
    {
        // fields
        [Key]
        private Guid _id;
        [Required]
        private string _firstname;
        [Required]
        private string _lastname;
        [Required]
        private string _businessName;
        [Required]
        private string _invoicePrefix;
        [Required]
        private string _address;
        [Required]
        private string _email;
        private string _primaryphone;
        [Required]
        private ClientStatus _status;

        private List<Contact> _contacts;
        private ClientState _state;

        private List<Job> _jobs;

        #region Constructor

        private Client()
        {
            if(_status == ClientStatus.Enabled)
            {
                _state = new EnabledState();
            }
            else
            {
                _state = new DisabledState();
            }
        }

        public Client(string firstname, string lastname, string businessName, string invoicePrefix, string address, string email, string primaryPhone)
        {
            _firstname = firstname;
            _lastname = lastname;
            _businessName = businessName;
            _invoicePrefix = invoicePrefix;
            _address = address;
            _email = email;
            _primaryphone = primaryPhone;
            _state = new EnabledState();
            _status = ClientStatus.Enabled;
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
                _state.setFirstName(delegate ()
                {
                    _firstname = value ?? throw new BusinessRuleException("First name cannot be empty");
                });

            }
        }

        [Required]
        public string LastName
        {
            get => _lastname;
            set
            {
                _state.setLastName(delegate ()
                {
                    _lastname = value ?? throw new BusinessRuleException("Last name cannot be empty");
                });
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
                _state.setBusinessName(delegate ()
                {
                    _businessName = value ?? throw new BusinessRuleException("Business Name cannot be emtpy");
                });
            }
        }

        [Required]
        public string InvoicePrefix
        {
            get => _invoicePrefix;
            set
            {
                _state.setInvoicePrefix(delegate ()
                {
                    _invoicePrefix = value ?? throw new BusinessRuleException("Invoice Prefix cannot be empty");
                });
            }
        }

        [Required]
        public string Address
        {
            get => _address;
            set
            {
                _state.setAddress(delegate ()
                {
                    _address = value ?? throw new BusinessRuleException("Address canoot be empty");
                });

            }
        }

        [Required]
        public string Email
        {
            get => _email;
            set
            {
                _state.setEmail(delegate ()
                {
                    _email = value ?? throw new BusinessRuleException("Email cannot be empty");
                });
            }
        }

        public string PrimaryPhone
        {
            get => _primaryphone;
            set
            {
                _state.setPrimaryPhone(delegate ()
                {
                    _primaryphone = value ?? throw new BusinessRuleException("Primary Phone cannot be empty");
                });
            }
        }

        //public List<Contact> Contacts
        //{
        //    get => _contacts;
        //}

        public bool Enabled
        {
            get => _state.Enabled;
        }

        //public IEnumerable<Job> Jobs
        //{
        //    get => _jobs;
        ////}

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
                _status = ClientStatus.Enabled;
            });
        }

        public void Disable()
        {
            _state.Disable(delegate ()
            {
                _state = new DisabledState();
                _status = ClientStatus.Disabled;
            });
        }

        #region Contact

        public Contact addContact(string name, string phone)
        {
            Contact contact = null;
            _state.addContact(delegate ()
            {
                contact = new Contact(name, phone, _id);
                _contacts.Add(contact);
            });
            return contact;
        }

        // I might have to find a better parameter format
        //public void addContacts(List<Tuple<string, string>> contacts)
        //{

        //}

        public void removeContact(Guid id)
        {
            _state.removeContact(delegate ()
            {
                var contact = _contacts.Find(c => c.ID == id);
                _contacts.Remove(contact);
            });
        }

        //public void removeContact(List<Guid> removeList)
        //{

        //}

        #endregion

        #endregion
    }
}
