using System.Data.Entity.Migrations;
using System.Linq;
using Infopulse.Core.Model;
using Infopulse.EntityFramework.EntityFramework;

namespace Infopulse.EntityFramework.Migrations
{
    public class Configuration : DbMigrationsConfiguration<InfopulseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InfopulseDbContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            AddCustomer(context, "customer 1", "description 1");
            AddCustomer(context, "customer 2", "description 2");
            AddCustomer(context, "customer 3", "description 3");
            AddCustomer(context, "customer 4", "description 4");
            AddCustomer(context, "customer 5", "description 5");
            AddCustomer(context, "customer 6", "description 6");
            AddCustomer(context, "customer 7", "description 7");
        }

        private Customer AddCustomer(InfopulseDbContext context, string name, string description)
        {
            var customer = new Customer
            {
                Name = name,
                Description = description
            };
          
            return context.Customers.Add(customer);
        }
    }
}
