using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models
{
  public class Product
  {
    //Defines Products Class properties
    [Key]
    public int ProductId { get; set; }
    //User needs to enter a value in Code, Name, and Price field since they are required.
    [Required(ErrorMessage = "Please enter a valid product code.")]
    public string Code { get; set; }

    // Product name property
    [Required(ErrorMessage = "Please enter a valid product name.")]
    public string Name { get; set; }
    [Required]
    [RegularExpression(@"^\d+[\.\d*]?$", ErrorMessage = "Please enter a valid price.")]
    public double? YearlyPrice { get; set; }

    // The date property below will be taken automatically by the system/DateTime.Now
    [DataType(DataType.Date)]
    public DateTime ReleasedDate { get; set; }
    
    // public ICollection<Incident> Incidents { get; set; }
    public List<Registration> Registrations { get; set; }
  }
}
