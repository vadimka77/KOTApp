using System;
using KOTApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KOTApp.Data
{
    public class ApplicationDbContext : IdentityDbContext //
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(Models.AppConfig.DBConnectionString);
            }
        }

        public DbSet<CompanyOwner> CompanyOwners { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TxEntry> TxEntries { get; set; }
        public DbSet<PayTimeFrame> PayTimeFrames { get; set; }
        public DbSet<EmployeePayRateHistory> EmployeePayRates { get; set; }
        public DbSet<ChangeOrder> ChangeOrders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //[Column(TypeName = "decimal(18,2)")]
        //    modelBuilder.Entity<ChangeOrder>().Property(p => p.Cost).HasPrecision(16, 2);
        //}
    }
}