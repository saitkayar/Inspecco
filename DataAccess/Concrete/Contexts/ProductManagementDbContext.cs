using Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete.Contexts
{
    public class ProductManagementDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ProductManagementDb;Trusted_Connection=True");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, CustomerName = "sait" },
            new Customer { Id = 2, CustomerName = "kayar" }, new Customer { Id = 3, CustomerName = "fena" }
            );
            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, CompanyName = "kayarlar", CustomerId = 1 },
                new Company { Id = 2, CompanyName = "fenalar", CustomerId = 2 },
                new Company { Id = 3, CompanyName = "bakmazlar", CustomerId = 3 });
        }

    }
}
