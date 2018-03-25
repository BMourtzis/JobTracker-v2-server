using JobTrackerDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobTrackerDomain
{
    internal class JobsDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(locald\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
    }
}
