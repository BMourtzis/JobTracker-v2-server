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
        string BusinessName { get; }
        string InvoicePrefix { get; }
        string Address { get; }
        string Email { get; }
        string PrimaryPhone { get; }
        bool Enabled { get; }

        //IEnumerable<IJob> Jobs { get; }
    }
}
