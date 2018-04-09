using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain.Interfaces
{
    public interface IContact
    {
        Guid ID { get; }
        string Name { get; }
        string Phone { get; }
    }
}
