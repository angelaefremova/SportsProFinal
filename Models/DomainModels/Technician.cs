using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models
{
  public class Technician
  {
    //Defines Technician Class properties and Regex
    [Key]
    public int Id { get; set; }
    //User needs to enter a value in every field since they are required.
    [Required(ErrorMessage ="Please enter a name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your phone number.")]
    [RegularExpression(@"^([0-9]{3}[-]?[0-9]{3}[-]?[0-9]{4})$", ErrorMessage = "Please enter a valid phone number. Accepted formats: 1234567890 or 123-456-7890")]
    public string Cell { get; set; }
    
    // Deploy One-to-Many Relationship between Technician and Incident Tables
    public ICollection<Incident>? Incidents { get; set; }
  }
}
