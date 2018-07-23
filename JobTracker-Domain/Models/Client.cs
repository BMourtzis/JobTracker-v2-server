using JobTrackerDomain.Interfaces;
using JobTrackerDomain.StateMachines.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobTrackerDomain.Models
{
    internal class Client : IClient
    {
        // fields
        private ClientStatus _status;

        private List<Contact> _contacts;
        private ClientState _state;

        private List<Job> _jobs;

        #region Constructor

        private Client() { }

        public Client(string firstname, string lastname, string businessName, string invoicePrefix, string address, string email, string primaryPhone)
        {
            FirstName = firstname;
            LastName = lastname;
            BusinessName = businessName;
            InvoicePrefix = invoicePrefix;
            Address = address;
            Email = email;
            PrimaryPhone = primaryPhone;
            _state = new EnabledState();
            _status = ClientStatus.Enabled;
        }

        #endregion

        #region Properties

        [Key]
        public Guid ID { get; private set; }

        [Required]
        public string FirstName { get; private set; }

        [Required]
        public string LastName { get; private set; }

        [Required]
        public string BusinessName { get; private set; }

        [Required]
        public string InvoicePrefix { get; private set; }

        [Required]
        public string Address { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public int Status
        {
            get => (int)_status;
            private set
            {
                _status = (ClientStatus)value;
                if (_status == ClientStatus.Enabled)
                {
                    _state = new EnabledState();
                }
                else
                {
                    _state = new DisabledState();
                }
            }
        }

        public string PrimaryPhone { get; private set; }

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

        public void Update(string firstname, string lastname, string businessName, string address, string email, string primaryPhone)
        {
            if(firstname != FirstName)
            {
                FirstName = firstname;
            }

            if(lastname != LastName)
            {
                LastName = lastname;
            }

            if(businessName != BusinessName)
            {
                BusinessName = businessName;
            }

            if(address != Address)
            {
                Address = address;
            }

            if(email != Email)
            {
                Email = email;
            }

            if(primaryPhone != PrimaryPhone)
            {
                PrimaryPhone = primaryPhone;
            }
        }

        public Job CreateSingleJob(string name, Decimal price, DateTime bookingDate)
        {
            Job job = null;
            _state.CreateSingleJob(delegate ()
            {
                job = new Job(name, price, ID, bookingDate);
            });
            return job;
        }

        public Job CreateTemplateJob(string name, Decimal price)
        {
            Job job = null;
            _state.CreateTemplateJob(delegate ()
            {
                //TODO: change with the new constructor
                job = new Job(name, price, ID, 1);
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
                _status = ClientStatus.Disabled;
                _state = new DisabledState();
            });
        }

        #region Contact

        public Contact addContact(string name, string contactValue, int type)
        {
            Contact contact = null;
            _state.addContact(delegate ()
            {
                contact = new Contact(name, contactValue, ID, type);
                _contacts.Add(contact);
            });
            return contact;
        }

        public Contact updateContact(Guid id, string name, string contactValue)
        {
            Contact contact = null;
            _state.updateContact(delegate ()
            {
                contact = findContact(id);
                contact.Update(name, contactValue);
            });
            return contact;
        }

        public Contact findContact(Guid id)
        {
            Contact contact = null;
            _state.findContact(delegate ()
            {
                contact = _contacts.Find(c => c.ID == id);
            });

            return contact;
        }



        public void removeContact(Guid id)
        {
            _state.removeContact(delegate ()
            {
                var contact = findContact(id);
                _contacts.Remove(contact);
            });
        }

        // I might have to find a better parameter format
        //public void addContacts(List<Tuple<string, string>> contacts)
        //{

        //}

        //public void removeContact(List<Guid> removeList)
        //{

        //}

        #endregion

        #endregion
    }
}
