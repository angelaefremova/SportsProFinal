using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models

{
  public class Country
  {
    //Defines Country Class properties and Regex
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
