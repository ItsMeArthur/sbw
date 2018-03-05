using SBW.MVC.Data;
using SBW.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Data
{
    public static class DbInitializer
    {
        // Seed some demo data into the database.
        public static void Seed(AppDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.AddRange
                    (
                        new Customer { Name = "Joseph Danes", Address = "1 Street", City = "London", Email = "joseph@server.com", IsActive = true },
                        new Customer { Name = "Clark Jones", Address = "Baker Street", City = "London", Email = "clark@server.com", IsActive = true },
                        new Customer { Name = "Mary Smith", Address = "Cloverfield Lane", City = "Boston", Email = "mary@server.com", IsActive = true },
                        new Customer { Name = "Meredith Mirra", Address = "79 Street", City = "Paris", Email = "meredith@server.com", IsActive = true },
                        new Customer { Name = "Roney Patt", Address = "Nine Boulevard", City = "Madrid", Email = "roney@server.com", IsActive = true }
                    );
            }

            context.SaveChanges();
        }
    }
}
