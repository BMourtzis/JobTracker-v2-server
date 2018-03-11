using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Models
{
    internal class Job
    {
        // Fields
        private Guid _id;
        private string _name;
        private Decimal _price;
        private Guid _clientId;

        private JobTemplate _template;
        private List<JobInstance> _instances;
        private List<Notes> _notes;

        #region Constructors

        private Job() { }

        private Job(string name, Decimal price, Guid clientId)
        {
            _name = name;
            _price = price;
            _clientId = clientId;
        }

        /// <summary>
        /// Creates a new Job with a single instance
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="clientId"></param>
        /// <param name="bookignDate"></param>
        public Job(string name, Decimal price, Guid clientId, DateTime bookignDate): this(name, price, clientId)
        {
           
        }
        
        /// <summary>
        /// Creates a new Job with a Template
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="clientId"></param>
        /// <param name="i"></param>
        public Job(string name, Decimal price, Guid clientId, int i): this(name, price, clientId)
        {

        }

        #endregion

        #region Properties

        public Guid ID
        {
            get => _id;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Decimal Price
        {
            get => _price;
            set => _price = value;
        }

        //public Client Client
        //{
        //    get => 
        //}

        public JobTemplate Template
        {
            get => _template;
        }

        public List<JobInstance> Instaces
        {
            get => _instances;
        }

        public List<Notes> Notes
        {
            get => _notes;
        }

        #endregion

        #region Methods

        public void CreateTemplate()
        {

        }

        public void GenerateInstances(int year, int month)
        {
            if(_template == null)
            {
                // throw exception
            }
        }

        public void CreateInstance()
        {

        }

        #endregion
    }
}
