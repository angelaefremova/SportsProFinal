namespace GBCSporting_LAIR.Models.ViewModels.RegViewModel
{
  public class AddRegViewModel
  {
    public int? CustomerId { get; set; }
    public int? ProductId { get; set; }
    public Customer customer { get; set; }
    public Product product { get; set; }
    public List<Customer> Customers { get; set; }
    public List<Product> Products { get; set; }
  }
}
