using JobTrackerDomain.Exceptions;
using JobTrackerDomain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobTrackerDomain.Models
{
    internal class Contact: IContact
    {
        private Guid _id;
        private string _name;
        private string _contactValue;
        private Guid _clientId;
        private int _contactType;

        #region Constructors

        private Contact() { }

        public Contact(string name, string contactValue, Guid clientId, ContactType type)
        {
            _name = name;
            _contactValue = contactValue;
            _clientId = clientId;
            _contactType = (int)type;
        }

        #endregion

        #region Properties

        [Key]
        public Guid ID
        {
            get => _id;
        }

        public ContactType ContactType
        {
            get => (ContactType)_contactType;
        }

        [Required]
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new BusinessRuleException("The name of the contact cannot be empty");
        }

        [Required]
        public string ContactValue
        {
            get => _contactValue;
        }

        public Guid ClientID
        {
            get => _clientId;
        }

        #endregion

        #region Methods

        public void Update(string name, string contactValue)
        {
            if(_name != name)
            {
                _name = name;
            }

            if (_contactValue != contactValue)
            {
                _contactValue = contactValue;
            }
        }

        #endregion
    }

    public enum ContactType
    {
        Phone, Email
    }
}
