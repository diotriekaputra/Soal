using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Context
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<History> History { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                 .HasOne(a => a.Employee)
                 .WithOne(b => b.Role)
                 .HasForeignKey<Employee>(b => b.RoleId);
            modelBuilder.Entity<Rent>()
                 .HasOne(a => a.History)
                 .WithOne(b => b.Rent)
                 .HasForeignKey<History>(b => b.OrderId);
            modelBuilder.Entity<Customer>()
               .HasMany(a => a.Rent)
               .WithOne(b => b.Customer);
            modelBuilder.Entity<Employee>()
              .HasMany(a => a.Rent)
              .WithOne(b => b.Employee);
            modelBuilder.Entity<Car>()
              .HasMany(a => a.Rent)
              .WithOne(b => b.Car);
        }
    }
}
