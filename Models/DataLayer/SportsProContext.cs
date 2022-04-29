/*
  COMP 2139 – Assignment #2
  Course: COMP2139
  Team Name: L.A.I.R
  Team Members: Le An Nguyen - 101292266, Angela Efremova - 101311327, Israr Wahid - 101348701, Renzzi Adorador - 101277841
  Latest edit: 2022 Feb 27 11.03PM
 */
using Microsoft.EntityFrameworkCore;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Models.ViewModels.CustomerViewModels;
using GBCSporting_LAIR.Models.ViewModels.ProductViewModels;
using GBCSporting_LAIR.Models.ViewModels.TechnicianViewModels;

namespace GBCSporting_LAIR.Data
{
    public class SportsProContext : DbContext
    {
        // Invoke SportsProContext object to connect to the Database
        public SportsProContext(DbContextOptions<SportsProContext> options)
          : base(options) { }
        // Customer Table
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerViewModel> CustomerViewModel { get; set; }
        // Product Table
        public DbSet<Product> Products { get; set; }
        // Technician Table
        public DbSet<Technician> Technicians { get; set; }
        // Registration Table
        public DbSet<Registration> Registrations { get; set; }
        // Incident Table
        public DbSet<Incident> Incidents { get; set; }
        // Country table for Customer objects
        public DbSet<Country> Countries { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
              optionsBuilder.UseSqlServer("name=SportsProContext");
    }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      // We have not implemeted the relationship part for the Registration Table yet
      modelBuilder.Entity<Registration>().HasKey(r => new { r.CustomerId, r.ProductId });
            modelBuilder.Entity<Registration>().
              HasOne(r => r.Customer).
                WithMany(r => r.Registrations).HasForeignKey(r => r.CustomerId);
        
            modelBuilder.Entity<Registration>().
              HasOne(r => r.Product).
                WithMany(r => r.Registrations).HasForeignKey(r =>r.ProductId);
            
            // The lines below are to seed the initial data for testing purposes during the developing progress
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new TechnicianConfig());
            // modelBuilder.ApplyConfiguration(new IncidentConfig());
            
        }
        
        public DbSet<GBCSporting_LAIR.Models.ViewModels.CustomerViewModels.AddCustomerViewModel> AddCustomerViewModel { get; set; }
        
        public DbSet<GBCSporting_LAIR.Models.ViewModels.ProductViewModels.ProductViewModel> ProductViewModel { get; set; }
        
        public DbSet<GBCSporting_LAIR.Models.ViewModels.ProductViewModels.AddProductViewModel> AddProductViewModel { get; set; }
        
        public DbSet<GBCSporting_LAIR.Models.ViewModels.TechnicianViewModels.TechnicianViewModel> TechnicianViewModel { get; set; }
        
        public DbSet<GBCSporting_LAIR.Models.ViewModels.TechnicianViewModels.AddTechnicianViewModel> AddTechnicianViewModel { get; set; }
    }
}
