using JobTrackerDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerDomain
{
    public class JobsDbContext: DbContext
    {
        public JobsDbContext(DbContextOptions options): base(options) { }

        public JobsDbContext()
        {
            
        }

        internal DbSet<Client> Clients { get; set; }
        private DbSet<Contact> Contacts { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JobDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
