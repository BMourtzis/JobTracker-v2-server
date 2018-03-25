using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Models
{
    internal class DailyJobTemplate : JobTemplate
    {
        #region Constrcutors

        private DailyJobTemplate(): base() { }

        public DailyJobTemplate(Guid jobId): base(jobId, TemplateType.Daily)
        {
            _values = new TemplateValues[1];
        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        public override List<DateTime> GenerateJobs(int year, int month)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
