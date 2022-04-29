using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models.ViewModels.ProductViewModels
{
  public class ProductViewModel
  {
    [Key]
    public int ProductId { get; set; }
    public string Code { get; set; }
    // Product name property
    public string Name { get; set; }
    public double? YearlyPrice { get; set; }
    // The date property below will be taken automatically by the system/DateTime.Now
    [DataType(DataType.Date)]
    public DateTime ReleasedDate { get; set; }
  }
}
