using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;

namespace GBCSporting_LAIR.Models.DataLayer.Repositories
{
  public class Repository<T> : IRepository<T>
  {
    private readonly SportsProContext _context;
    public Repository(SportsProContext context) { _context = context; }
    public void Add(T entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
      throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
      throw new NotImplementedException();
    }

    public T GetById(string id)
    {
      throw new NotImplementedException();
    }

    public void Update(T entity)
    {
      throw new NotImplementedException();
    }
  }
}
