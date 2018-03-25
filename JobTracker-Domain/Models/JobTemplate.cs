using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Models
{
    internal abstract class JobTemplate
    {
        private Guid _id;
        private Job _job;
        private TemplateType _type;
        protected TemplateValues[] _values;

        #region Constructor

        protected JobTemplate() { }

        protected JobTemplate(Guid jobId, TemplateType type)
        {
            _type = type;
        }

        #endregion

        #region Properties

        public TemplateType Type
        {
            get => _type;
        }

        public TemplateValues[] Values
        {
            get => _values;
        }

        #endregion

        #region Methods

        public abstract List<DateTime> GenerateJobs(int year, int month);

        #endregion
    }

    enum TemplateType
    {
        Daily,
        Weekly,
        Fortnightly,
        Monthly
    }

    internal struct TemplateValues
    {
        int dayOfWeek;
        DateTime time;
        int weekOfMonth;
    }
}
