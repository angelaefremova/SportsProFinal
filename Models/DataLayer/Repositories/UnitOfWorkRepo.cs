using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Models.DataLayer.Repositories;
using GBCSporting_LAIR.Models;

namespace GBCSporting_LAIR.Repositories
{
  public class UnitOfWorkRepo : IUnitOfWork
  {
    private readonly SportsProContext _context;
    private IRepository<Product> _productRepo;
    private IRepository<Customer> _customerRepo;
    private IRepository<Technician> _technicianRepo;
    private IRepository<Country> _countryRepo;
    private IRepository<Registration> _regRepo;
    private IRepository<Incident> _incidentRepo;
    public UnitOfWorkRepo(SportsProContext context) { _context = context; }

    // All of the references below are for etablishing
    public IRepository<Customer> Customers
    {
      get { return _customerRepo = _customerRepo ?? new CustomerRepo(_context); }
    }

    public IRepository<Product> Products
    {
      get { return _productRepo = _productRepo ?? new ProductRepo(_context); }
    }

    public IRepository<Technician> Technicians
    {
      get { return _technicianRepo = _technicianRepo ?? new TechnicianRepo(_context); }
    }

    public IRepository<Country> Countries
    {
      get { return _countryRepo = _countryRepo ?? new CountryRepo(_context); }
    }

    public IRepository<Registration> Registrations
    {
      get { return _regRepo = _regRepo ?? new RegRepo(_context); }
    }

    public IRepository<Incident> Incidents
    {
      get { return _incidentRepo = _incidentRepo ?? new IncidentRepo(_context); }
    }

    public void Save()
    {
      _context.SaveChanges();
    }
  }
}
