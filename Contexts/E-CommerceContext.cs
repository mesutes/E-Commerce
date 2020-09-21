using E_Commerce.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace E_Commerce.Contexts
{
    public class E_CommerceContext :IdentityDbContext<AppUser>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(x => x.Addresses).WithOne(x => x.Customer);
            modelBuilder.Entity<Adress>().HasOne(x => x.Customer).WithMany(x => x.Addresses);
            modelBuilder.Entity<ProductCategory>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryID, x.ProductID });
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.Product).WithMany(x => x.ProductCategories).HasForeignKey(x => x.ProductID);
            modelBuilder.Entity<ProductCategory>().HasOne(x => x.Category).WithMany(x => x.ProductCategories).HasForeignKey(x => x.CategoryID);
            modelBuilder.Entity<Customer>().HasOne(x => x.PhoneNumber).WithOne(x => x.Customer).HasForeignKey<PhoneNumber>(x => x.CustomerID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAdress> CustomerAdresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }

    }
}
