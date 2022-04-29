using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_LAIR.Models
{
  internal class IncidentConfig : IEntityTypeConfiguration<Incident>
  {
    public void Configure(EntityTypeBuilder<Incident> entity)
    {
      // All data has been removed due to the integrity of the whole database
      /* entity.HasData(
          new Incident { IncidentId = 1, CustomerId = 5, ProductId = 4, Title = "Could not install", Description = "Abc", TechnicianId = 2, DateOpened = new DateTime(2020,1,8), DateClosed = DateTime.MaxValue },

          new Incident { IncidentId = 2, CustomerId = 3, ProductId = 1, Title = "Could not update", Description = "Xyz", TechnicianId = 1, DateOpened = new DateTime(2020, 1, 8), DateClosed = DateTime.MaxValue },

          new Incident { IncidentId = 3, CustomerId = 2, ProductId = 3, Title = "Error Importing data", Description = "Can not import data from earlier version", TechnicianId = 3, DateOpened = new DateTime(2020, 1, 9), DateClosed = DateTime.MaxValue },

          new Incident { IncidentId = 4, CustomerId = 5, ProductId = 2, Title = "Error Launching program", Description = "609 Error when launching from icon on Desktop", TechnicianId = 4, DateOpened = new DateTime(2020, 1, 10), DateClosed = DateTime.MaxValue }
        );
      */
    }
  }
}