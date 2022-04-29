using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GBCSporting_LAIR.Models
{
  internal class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> entity)
    {
      // Set Code propertise as a primary key because it doesn't follow the convention
      entity.HasData(
        new Product { ProductId = 1, Code = "TRNY10", Name = "Tournament Master 1.0", YearlyPrice = 4.99, ReleasedDate = new DateTime(2015, 12, 1) },
        new Product { ProductId = 2, Code = "LEAG10", Name = "League Scheduler 1.0", YearlyPrice = 4.99, ReleasedDate = new DateTime(2016, 5, 1) },
        new Product { ProductId = 3, Code = "LEAGD10", Name = "League Scheduler Deluxe 1.0", YearlyPrice = 7.99, ReleasedDate = new DateTime(2016, 8, 1) },
        new Product { ProductId = 4, Code = "DRAFT10", Name = "Draft Manager 1.0", YearlyPrice = 4.99, ReleasedDate = new DateTime(2017, 2, 1) },
        new Product { ProductId = 5, Code = "TEAM10", Name = "Team Manager 1.0", YearlyPrice = 4.99, ReleasedDate = new DateTime(2017, 5, 1) },
        new Product { ProductId = 6, Code = "TRNY20", Name = "Tournament Master 2.0", YearlyPrice = 5.99, ReleasedDate = new DateTime(2018, 2, 15) },
        new Product { ProductId = 7, Code = "DRAFT20", Name = "Draft Manager 2.0", YearlyPrice = 5.99, ReleasedDate = new DateTime(2019, 7, 15) }
        );

    }
  }
}
