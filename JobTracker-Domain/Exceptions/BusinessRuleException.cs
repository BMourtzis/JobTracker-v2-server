using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Exceptions
{
    class BusinessRuleException: Exception
    {
        public BusinessRuleException(string message) : base(message) { }
    }
}
