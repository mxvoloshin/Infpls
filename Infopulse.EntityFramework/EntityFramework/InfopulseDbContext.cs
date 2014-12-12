using System.Data.Entity;
using Infopulse.Core.Model;

namespace Infopulse.EntityFramework.EntityFramework
{
    public class InfopulseDbContext : DbContext
    {
        public InfopulseDbContext() : base("Default")
        {
            
        }

        public DbSet<Customer> Customers { get; set; } 
    }
}
