using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Models
{
    abstract class JobTemplate
    {
        private Guid _id;
        private TemplateType _type;

        private Job _job;

        #region Constructor

        private JobTemplate() { }

        protected JobTemplate(Guid jobId)
        {
            
        }

        #endregion

        #region Properties

        public TemplateType Type
        {
            get => _type;
            protected set => _type = value;
        }

        #endregion

        #region Methods

        public abstract void GenerateJobs(int year, int month);

        #endregion
    }

    enum TemplateType
    {
        Daily,
        Weekly,
        Fortnightly,
        Monthly
    }
}
