using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Models
{
    internal class Client
    {
        // fields
        private Guid _id;
        private string _firstname;
        private string _lastname;
        private string _businessName;
        private string _shortname;

        private List<Job> _jobs;

        #region Constructor

        private Client() { }

        public Client(string firstname, string lastname, string businessName, string shortname)
        {
            _firstname = firstname;
            _lastname = lastname;
            _businessName = businessName;
            _shortname = shortname;
        }

        #endregion

        #region Properties

        public Guid ID
        {
            get => _id;
        }

        public string FirstName
        {
            get => _firstname;
            set => _firstname = value;
        }

        public string LastName
        {
            get => _lastname;
            set => _lastname = value;
        }

        public string FullName
        {
            get => $"{_firstname} {_lastname}";
        }

        public string BusinessName
        {
            get => _businessName;
            set => _businessName = value;
        }

        public string ShortName
        {
            get => _shortname;
            set => _shortname = value;
        }

        public IEnumerable<Job> Jobs
        {
            get => _jobs;
        }

        #endregion

        #region Methods

        public Job CreateSingleJob(string name, Decimal price, DateTime bookingDate)
        {
            var job = new Job(name, price, _id, bookingDate);
            return job;
        }

        public Job CreateTemplateJob(string name, Decimal price, DateTime)
        {
            //TODO: change with the new constructor
            var job = new Job(name, price, _id, 1);
            return job;
        }

        #endregion
    }
}
