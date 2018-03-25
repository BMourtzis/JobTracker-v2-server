using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Interfaces
{
    public interface IClient
    {
        Guid ID { get; }
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
        string BusinessName { get; }
        string ShortName { get; }
        //IEnumerable<IJob> Jobs { get; }
    }
}
