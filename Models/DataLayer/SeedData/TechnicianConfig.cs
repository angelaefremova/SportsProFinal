using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_LAIR.Models
{
  internal class TechnicianConfig : IEntityTypeConfiguration<Technician>
  {
    public void Configure(EntityTypeBuilder<Technician> entity)
    {
      // Set Code propertise as a primary key because it doesn't follow the convention
      entity.HasData(
        new Technician { Id = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Cell = "800-555-0443" },
        new Technician { Id = 2, Name = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", Cell = "800-555-0449" },
        new Technician { Id = 3, Name = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", Cell = "800-555-0459" },
        new Technician { Id = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", Cell = "800-555-0400" },
        new Technician { Id = 5, Name = "Jason Lee", Email = "jason@sportsprosoftware.com", Cell = "800-555-0444" }
      );
    }
  }
}
