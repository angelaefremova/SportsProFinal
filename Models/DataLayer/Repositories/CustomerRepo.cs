using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Data;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting_LAIR.Repositories
{

  public class CustomerRepo : IRepository<Customer>
  {
    private readonly SportsProContext _context;
    public CustomerRepo(SportsProContext context) { _context = context; }

    public void Add(Customer customer)
    {
      _context.Customers.Add(customer);
    }

    public void Delete(Customer customer)
    {
      _context.Customers.Remove(customer);
    }

    public List<Customer> GetAll()
    {
      return _context.Customers.OrderBy(c => c.FirstName).ToList();
    }

    public Customer GetById(string id)
    {
      return _context.Customers.Include("Registrations.Product").FirstOrDefault(c => c.CustomerId == Convert.ToInt32(id));
    }

    public void Update(Customer customer)
    {
      _context.Customers.Update(customer);
    }
  }
}
