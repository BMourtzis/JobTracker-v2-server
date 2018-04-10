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

        public Contact addContact(string name, string phone)
        {
            Contact contact = null;
            _state.addContact(delegate ()
            {
                contact = new Contact(name, phone, ID);
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
