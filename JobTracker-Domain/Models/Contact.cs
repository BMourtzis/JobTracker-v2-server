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
        private string _phone;
        private Guid _clientId;

        #region Constructors

        private Contact() { }

        public Contact(string name, string phone, Guid clientId)
        {
            _name = name;
            _phone = phone;
            _clientId = clientId;
        }

        #endregion

        #region Properties

        [Key]
        public Guid ID
        {
            get => _id;
        }

        [Required]
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new BusinessRuleException("The name of the contact cannot be empty");
        }

        [Required]
        public string Phone
        {
            get => _phone;
            set => _phone = value ?? throw new BusinessRuleException("The phone of the contect cannot be empty");
        }

        public Guid ClientID
        {
            get => _clientId;
        }

        #endregion

        #region Methods

        #endregion
    }
}
