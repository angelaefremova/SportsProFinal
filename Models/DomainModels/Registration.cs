using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models
{
  public class Registration
  {
    //Defines Customer Class properties
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public DateTime RegisteredDate { get; set; }
  }
}