using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;

namespace GBCSporting_LAIR.Models.DataLayer.Repositories
{
  public class IncidentRepo : IRepository<Incident>
  {
    private readonly SportsProContext _context;
    public IncidentRepo(SportsProContext context) { _context = context; }

    public void Add(Incident incident)
    {
      _context.Incidents.Add(incident);
    }

    public void Delete(Incident incident)
    {
      _context.Incidents.Remove(incident);
    }

    public List<Incident> GetAll()
    {
      return _context.Incidents.OrderBy(x => x.Id).ToList();
    }

    public Incident GetById(string id)
    {
      return _context.Incidents.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
    }

    public void Update(Incident incident)
    {
      _context.Incidents.Update(incident);
    }
  }
}
