using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;

namespace GBCSporting_LAIR.Models.DataLayer.Repositories
{
  public class TechnicianRepo : IRepository<Technician>
  {
    private readonly SportsProContext _context;

    public TechnicianRepo(SportsProContext context) { _context = context; }
    public void Add(Technician technician)
    {
      _context.Technicians.Add(technician);
    }

    public void Delete(Technician technician)
    {
      _context.Technicians.Remove(technician);
    }

    public List<Technician> GetAll()
    {
      return _context.Technicians.OrderBy(t => t.Name).ToList();
    }

    public Technician GetById(string id)
    {
      return _context.Technicians.Where(t => t.Id == Convert.ToInt32(id)).FirstOrDefault();
    }

    public void Update(Technician technician)
    {
      _context.Technicians.Update(technician);
    }
  }
}
