using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_LAIR.Models
{
  internal class CustomerConfig : IEntityTypeConfiguration<Customer>
  {
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
      
      entity.HasData(new Customer
      {
        CustomerId = 1,
        FirstName = "Kaitlyn",
        LastName = "Anthoni",
        Address = "",
        City = "San Francisco",
        Province = "",
        PostalCode = "",
        CountryId = 74,
        Email = "kanthoni@pge.com",
        Phone = ""
      },
      new Customer
      {
        CustomerId = 2,
        FirstName = "Ania",
        LastName = "Irvin",
        Address = "",
        City = "Washington",
        Province = "",
        PostalCode = "",
        CountryId = 74,
        Email = "ania@mma.nidc.com",
        Phone = ""
      },
      new Customer
      {
        CustomerId = 3,
        FirstName = "Gonzalo",
        LastName = "Keeton",
        Address = "",
        City = "Mission Veijo",
        Province = "",
        PostalCode = "",
        CountryId = 18,
        Email = "",
        Phone = ""
      },
      new Customer
      {
        CustomerId = 4,
        FirstName = "Anton",
        LastName = "Mauro",
        Address = "",
        City = "Sacramento",
        Province = "",
        PostalCode = "",
        CountryId = 42,
        Email = "amauro@yahoo.org",
        Phone = ""
      },
      new Customer
      {
        CustomerId = 5,
        FirstName = "Kendall",
        LastName = "Mayte",
        Address = "",
        City = "Fresno",
        Province = "",
        PostalCode = "",
        CountryId = 35,
        Email = "kmayte@fresno.ca.gov",
        Phone = ""
      },
      new Customer
      {
        CustomerId = 6,
        FirstName = "Kenzie",
        LastName = "Quinn",
        Address = "",
        City = "Los Angeles",
        Province = "",
        PostalCode = "",
        CountryId = 79,
        Email = "kenzie@mma.jobtrak.com",
        Phone = ""
      },
      new Customer
      {
        CustomerId = 7,
        FirstName = "Marvin",
        LastName = "Quintin",
        Address = "",
        City = "Fresno",
        Province = "",
        PostalCode = "",
        CountryId = 78,
        Email = "marvin@expedata.com",
        Phone = ""
      });
      
    }
  }
}
