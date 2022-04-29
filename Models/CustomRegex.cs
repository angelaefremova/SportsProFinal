using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models
{
  // Regex for Name Input Field
  public class NamePattern : RegularExpressionAttribute
  {
    public NamePattern()
      : base(@"^[A-Z][a-z]*[\.]*([\s][A-Z][a-z]*[\.]*)*$") { }
  }
  // Regex for Email Input Field
  public class EmailPattern : RegularExpressionAttribute
  {
    public EmailPattern()
      : base(@"^[A-Za-z0-9]*([_\.\-]?[A-Za-z0-9]+)*@[A-Za-z0-9]+([\.\-]?[A-Za-z0-9]+)*(\.{1})([A-Za-z]{2,})$") { }
  }
  // Regex for Post Code Input Field
  public class PostCodePattern : RegularExpressionAttribute
  {
    public PostCodePattern()
      : base(@"^([A-Za-z]{1}(\d{1})[A-Za-z]{1}){1}(\s)?((\d{1})[A-Za-z]{1}(\d{1})){1}$") { }
  }
}