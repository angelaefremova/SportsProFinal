using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting_LAIR.Models.ViewModels.CustomerViewModels
{
  [Keyless]
  public class CustomerViewModel
  {
    public string CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    [NotMapped]
    public List<Product> Products { get; set; }
  }
}
