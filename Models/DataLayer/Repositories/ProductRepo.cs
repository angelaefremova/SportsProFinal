using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Data;

namespace GBCSporting_LAIR.Repositories
{
  public class ProductRepo : IRepository<Product>
  {
    private readonly SportsProContext _context;

    public ProductRepo(SportsProContext context) { _context = context; }
    public List<Product> GetAll()
    {
      return _context.Products.ToList();
    }

    public Product GetById(string id)
    {
      return _context.Products.FirstOrDefault(p => p.ProductId == Convert.ToInt32(id));
    }

    public void Add(Product product)
    {
      _context.Products.Add(product);
    }

    public void Delete(Product product)
    {
      _context.Products.Remove(product);
    }

    public void Update(Product product)
    {
      _context.Products.Update(product);
    }
  }
}
