using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Exceptions
{
    class InternalException: Exception
    {
        public InternalException(string message): base(message) { }
    }
}
