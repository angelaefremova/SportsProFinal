using GBCSporting_LAIR.Models;

namespace GBCSporting_LAIR.Interfaces
{
  public interface IUnitOfWork
  {
    IRepository<Customer> Customers { get; }
    IRepository<Product> Products { get; }
    IRepository<Technician> Technicians { get; }
    IRepository<Country> Countries { get; }
    IRepository<Registration> Registrations { get; }
    IRepository<Incident> Incidents { get; }
    void Save();
  }
}
