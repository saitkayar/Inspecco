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
    public class InspeccoDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=InspeccoDb;Trusted_Connection=True");

        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, CustomerName = "sait",IsInvited=true },
            new Customer { Id = 2, CustomerName = "kayar", IsInvited = true},
            new Customer { Id = 3, CustomerName = "fena", IsInvited = true }
            );
            modelBuilder.Entity<Company>().HasData(new Company { Id = 1, CompanyName = "kayarlar", CustomerId = 1 },
                new Company { Id = 2, CompanyName = "fenalar", CustomerId = 2 },
                new Company { Id = 3, CompanyName = "bakmazlar", CustomerId = 3 });
            modelBuilder.Entity<Invitation>().HasData(new Invitation { Id = 1, CompanyId = 1, CustomerId = 1 },
             new Invitation { Id = 2, CompanyId = 2, CustomerId = 2 },
      new Invitation { Id = 3, CompanyId = 2, CustomerId = 2 });
        }

    }
}
