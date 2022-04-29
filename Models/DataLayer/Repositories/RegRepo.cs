using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;

namespace GBCSporting_LAIR.Models.DataLayer.Repositories
{
  public class RegRepo : IRepository<Registration>
  {
    private readonly SportsProContext _context;
    public RegRepo(SportsProContext context) { _context = context; }

    public void Add(Registration reg)
    {
      _context.Registrations.Add(reg);
    }

    public void Delete(Registration reg)
    {
      _context.Registrations.Remove(reg);
    }
    public void Update(Registration reg)
    {
      _context.Registrations.Update(reg);
    }
    public List<Registration> GetAll()
    {
      return _context.Registrations.ToList();
    }
    public Registration GetById(string rid)
    {
      if (rid.IndexOf(Convert.ToChar("-"), StringComparison.CurrentCultureIgnoreCase) != -1)
      {
        string[] ids = rid.Split(Convert.ToChar('-'));
        return _context.Registrations.Where(r => r.CustomerId == Convert.ToInt32(ids[0])).Where(r => r.ProductId == Convert.ToInt32(ids[1])).FirstOrDefault();
      }
      return _context.Registrations.Where(r => r.CustomerId == Convert.ToInt32(rid)).FirstOrDefault();
    }
  }
}
