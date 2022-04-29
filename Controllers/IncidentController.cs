using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GBCSporting_LAIR.Models.ViewModels.IncidentViewModels;

namespace GBCSporting_LAIR.Controllers
{
  public class IncidentController : Controller
  {
    // Adds a private variable to the model that is used to query and assign specific values for the variables below
    private SportsProContext dBContext { get; set; }
    public IncidentController(SportsProContext ctx) { dBContext = ctx; }

    //Method that displays incident index page and accesses customer and product database
    public ViewResult Index(string id = "all")
    {
      IQueryable<IncidentViewModel> incidents;
      ViewBag.Filter = id;
      if (id == "ua")
      {
        incidents = from incident in dBContext.Incidents
                    join customer in dBContext.Customers on incident.CustomerId equals customer.CustomerId
                    join products in dBContext.Products on incident.ProductId equals products.ProductId
                    where incident.TechnicianId == 0
                    select new IncidentViewModel
                    {
                      Id = incident.Id,
                      CustomerName = customer.FirstName + " " + customer.LastName,
                      ProductName = products.Name,
                      Date = incident.DateOpened.Date,
                      Title = incident.Title
                    };
      }
      else if (id == "open")
      {
        incidents = from incident in dBContext.Incidents
                    join customer in dBContext.Customers on incident.CustomerId equals customer.CustomerId
                    join products in dBContext.Products on incident.ProductId equals products.ProductId
                    where incident.DateClosed == null
                    select new IncidentViewModel
                    {
                      Id = incident.Id,
                      CustomerName = customer.FirstName + " " + customer.LastName,
                      ProductName = products.Name,
                      Date = incident.DateOpened.Date,
                      Title = incident.Title
                    };
      }
      else
      {
        incidents = from incident in dBContext.Incidents
                    join customer in dBContext.Customers on incident.CustomerId equals customer.CustomerId
                    join products in dBContext.Products on incident.ProductId equals products.ProductId
                    select new IncidentViewModel
                    {
                      Id = incident.Id,
                      CustomerName = customer.FirstName + " " + customer.LastName,
                      ProductName = products.Name,
                      Date = incident.DateOpened.Date,
                      Title = incident.Title
                    };
      }
      var viewModel = new IncidentsViewModel()
      {
        Incidents = incidents.ToList()
      };
      return View(viewModel);
    }
    // Action method to add a new index entry
    public IActionResult Add()
    {
      var Products = dBContext.Products.Select(c =>
                  new SelectListItem { Text = c.Name, Value = c.ProductId.ToString() }).ToList();

      var Customers = dBContext.Customers.Select(c =>
                 new SelectListItem { Text = c.FirstName + " " + c.LastName, Value = c.CustomerId.ToString() }).ToList();

      var Technicians = dBContext.Technicians.Select(c =>
                    new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();

      var viewModel = new AddEditIncidentViewModel()
      {
        Products = Products,
        Customers = Customers,
        Technicians = Technicians,
        Operation = "Add"
      };

      return View("AddEdit", viewModel);
    }

    [HttpPost]
    public IActionResult Create(CreateIncidentViewModel values)
    {
      var data = new Incident
      {
        ProductId = values.ProductId,
        CustomerId = values.CustomerId,
        TechnicianId = values.TechnicianId,
        DateOpened = DateTime.Now.Date,
        Title = values.Title,
        Description = values.Description
      };
      TempData["message"] = values.Title + " was added successfully.";
      dBContext.Incidents.Add(data);
      int saved = dBContext.SaveChanges();

      if (saved == 1)
      {
        return Redirect("~/incident/?msg=Save Successful");
      }

      return RedirectToAction("", "Incident");
    }

    public IActionResult Edit(int id)
    {
      var incident = dBContext.Incidents.Find(id);

      var Products = dBContext.Products.Select(c =>
      new SelectListItem { Text = c.Name, Value = c.ProductId.ToString() }).ToList();

      var Customers = dBContext.Customers.Select(c =>
                 new SelectListItem { Text = c.FirstName + " " + c.LastName, Value = c.CustomerId.ToString() }).ToList();

      var Technicians = dBContext.Technicians.Select(c =>
           new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();

      var data = new AddEditIncidentViewModel()
      {
        Id = incident.Id,
        CustomerId = incident.CustomerId,
        ProductId = incident.ProductId,
        TechnicianId = incident.TechnicianId,
        Title = incident.Title,
        DateOpened = incident.DateOpened,
        Description = incident.Description,
        Products = Products,
        Customers = Customers,
        Technicians = Technicians,
        Operation = "Edit"
      };

      return View("AddEdit", data);
    }

    [HttpPost]
    public IActionResult EditConfirm(ConfirmEditIncidentViewModel editIncidentViewModel)
    {
      var incident = dBContext.Incidents.Find(editIncidentViewModel.IncidentId);

      incident.Title = editIncidentViewModel.Title;
      incident.Description = editIncidentViewModel.Description;
      incident.ProductId = editIncidentViewModel.ProductId;
      incident.CustomerId = editIncidentViewModel.CustomerId;
      incident.TechnicianId = editIncidentViewModel.TechnicianId;
      TempData["message"] = incident.Title + " was updated successfully.";
      dBContext.Update(incident);

      int saved = dBContext.SaveChanges();

      if (saved == 1)
      {
        return Redirect("~/incident/?msg=Edit Successful");
      }

      return View();
    }

    // Action method to delete an index entry
    [HttpPost, ActionName("Delete")]
    public IActionResult Delete(int id)
    {
      // Query the incident object from the database
      var incident = dBContext.Incidents.Find(id);
      // Remove the found incident
      dBContext.Incidents.Remove(incident);
      TempData["message"] = " was deleted successfully.";
      dBContext.SaveChanges(true);
      return RedirectToAction(nameof(Index));
    }
  }
}
