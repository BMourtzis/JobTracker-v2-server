using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Exceptions
{
    class JIStateException: BusinessRuleException
    {
        public JIStateException(string item, string state): base($"Cannot update {item} because the state is {state}") { }
    }
}
