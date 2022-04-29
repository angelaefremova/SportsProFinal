using System.ComponentModel.DataAnnotations;
namespace GBCSporting_LAIR.Models
{
  public class Customer
  {
    //Defines Customer Class properties and Regex
    [Key]
    public int CustomerId { get; set; }

    //First Name field is required and only letters and space are accepted.
    [Required]
    [StringLength(50, MinimumLength = 1)]
    [NamePattern(ErrorMessage = "Please enter a valid first name.")]
    public string FirstName { get; set; }

    //Last Name field is required and only letters and space are accepted.
    [Required]
    [StringLength(50, MinimumLength = 1)]
    [NamePattern(ErrorMessage = "Please enter a valid last name.")]
    public string LastName { get; set; }
    //Address field is required but user can input letters, numbers, and symbols.
    [Required(ErrorMessage = "Please enter a valid address.")]
    [StringLength(50, MinimumLength = 1)]
    public string Address { get; set; }
    [Required(ErrorMessage = "Please enter the City name.")]
    [StringLength(50, MinimumLength = 1)]
    public string City { get; set; }
    [Required(ErrorMessage = "Please enter the Province name.")]
    [StringLength(50, MinimumLength = 1)]
    public string Province { get; set; }
    //Postal Code is required and only letters and space are accepted. Should follow the Canadian formatting which is A1A 1A1 or A1A1A1 [without space] (A = Letters, 1 = Numbers)
    [Required(ErrorMessage = "Please enter a valid postal code.")]
    [StringLength(20, MinimumLength = 1)]
    public string PostalCode { get; set; }

    [Required]
    public int CountryId { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 1)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [RegularExpression(@"^(\([0-9]{3}\)[ ][0-9]{3}[-][0-9]{4})$", ErrorMessage = "Please enter a valid phone number. Accepted format: (999) 999-9999")]
    public string Phone { get; set; }
    public string FullName => $"{FirstName} {LastName}";


    // public List<Incident> Incidents { get; set; }
    public List<Registration>? Registrations { get; set; } = new List<Registration>();
  }
}
