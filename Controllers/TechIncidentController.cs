using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Models.ViewModels.IncidentViewModels;
using GBCSporting_LAIR.Models.ViewModels.TechIncidentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting_LAIR.Controllers
{
  public class TechIncidentController : Controller
  {
    private SportsProContext dBContext { get; set; }

    public TechIncidentController(SportsProContext dBContext)
    {
      this.dBContext = dBContext;
    }

    public IActionResult Get()
    {
      var technicians = dBContext.Technicians.Select(c =>
                    new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();

      var viewModel = new GetTechIncidentsViewModel()
      {
        Technicians = technicians
      };

      return View(viewModel);
    }

    public IActionResult List(int id)
    {
      var incidents = from incident in dBContext.Incidents
                      where incident.TechnicianId == id && !incident.DateClosed.HasValue
                      join customer in dBContext.Customers on incident.CustomerId equals customer.CustomerId
                      join products in dBContext.Products on incident.ProductId equals products.ProductId
                      select new IncidentViewModel
                      {
                        Id = incident.Id,
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        ProductName = products.Name,
                        Date = incident.DateOpened,
                        Title = incident.Title
                      };

      var technician = dBContext.Technicians.FirstOrDefault(t => t.Id == id);

      var viewModel = new ListTechIncidentsViewModel()
      {
        TechnicianName = technician?.Name,
        Incidents = incidents.ToList()
      };

      HttpContext.Session.SetInt32("TechnicianId", id);

      return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
      var incidents = from incident in dBContext.Incidents
                      where incident.Id == id
                      join customer in dBContext.Customers on incident.CustomerId equals customer.CustomerId
                      join product in dBContext.Products on incident.ProductId equals product.ProductId
                      join technician in dBContext.Technicians on incident.TechnicianId equals technician.Id
                      select new
                      {
                        Id = incident.Id,
                        CustomerName = customer.FirstName + " " + customer.LastName,
                        ProductName = product.Name,
                        TechnicianName = technician.Name,
                        TechnicianId = technician.Id,
                        DateOpened = incident.DateOpened,
                        DateClosed = incident.DateClosed,
                        Title = incident.Title,
                        Description = incident.Description
                      };

      var incidentList = incidents.ToList();

      var incidentModel = incidents.FirstOrDefault();

      var viewModel = new EditTechIncidentViewModel()
      {
        IncidentId = incidentModel.Id,
        Customer = incidentModel.CustomerName,
        Product = incidentModel.ProductName,
        Technician = incidentModel.TechnicianName,
        TechnicianId = incidentModel.TechnicianId,
        Title = incidentModel.Title,
        DateOpened = incidentModel.DateOpened,
        DateClosed = incidentModel.DateClosed,
        Description = incidentModel.Description,
      };

      return View(viewModel);
    }

    [HttpPost]
    public IActionResult EditConfirm(ConfirmEditTechIncidentViewModel confirmEditTechIncidentViewModel)
    {
      var incident = dBContext.Incidents.Find(confirmEditTechIncidentViewModel.IncidentId);

      incident.Description = confirmEditTechIncidentViewModel.Description;
      incident.DateClosed = confirmEditTechIncidentViewModel.DateClosed;

      dBContext.Update(incident);

      int saved = dBContext.SaveChanges();

      int? technicianId = HttpContext.Session.GetInt32("TechnicianId");

      if (saved == 1)
      {
        return Redirect("~/techincident/list/" + technicianId);
      }

      return View();
    }
  }
}
