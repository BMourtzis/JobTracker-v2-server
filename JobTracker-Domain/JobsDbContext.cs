using JobTrackerDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain
{
    public class JobsDbContext: DbContext
    {
        public JobsDbContext(DbContextOptions options): base(options) { }

        public JobsDbContext()
        {

        }

        internal DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
