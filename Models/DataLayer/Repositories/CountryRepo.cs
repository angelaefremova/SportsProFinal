using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;

namespace GBCSporting_LAIR.Models.DataLayer.Repositories
{
  public class CountryRepo : IRepository<Country>
  {
    private readonly SportsProContext _context;

    public CountryRepo(SportsProContext context) { _context = context; }
    public void Add(Country country)
    {
      _context.Countries.Add(country);
    }

    public List<Country> GetAll()
    {
      return _context.Countries.OrderBy(c => c.Id).ToList();
    }

    public Country GetById(string id)
    {
      return _context.Countries.Where(c => c.Id == Convert.ToInt32(id)).FirstOrDefault();
    }

    public void Update(Country country)
    {
      _context.Countries.Update(country);
    }
    public void Delete(Country country)
    {
      _context.Countries.Remove(country);
    }
  }
}
