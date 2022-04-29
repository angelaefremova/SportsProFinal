using AutoMapper;
using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Models.ViewModels.RegViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_LAIR.Controllers
{
  public class RegistrationController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public RegistrationController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    // GET: RegistrationController
    public ActionResult Index()
    {
      var regs = _unitOfWork.Registrations.GetAll();
      var vm = new List<Registration>();
      for (int i = 0; i < regs.Count; i++)
      {
        vm.Add(new Registration() {
          CustomerId = regs[i].CustomerId,
          Customer = _unitOfWork.Customers.GetById(Convert.ToString(regs[i].CustomerId)),
          ProductId = regs[i].ProductId,
          Product = _unitOfWork.Products.GetById(Convert.ToString(regs[i].ProductId)),
          RegisteredDate = regs[i].RegisteredDate
        });
      }
      return View("List", vm);
    }

    // GET: RegistrationController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }
    public ActionResult CustomerSelect()
    {
      var customers = _unitOfWork.Customers.GetAll();
      var vm = new AddRegViewModel()
      {
        Customers = customers
      };
      return View("CustomerSelect", vm);
    }
    [HttpPost]
    public ActionResult CustomerSelect(AddRegViewModel rvm)
    {
      try
      {
        Customer selectedCustomer = _unitOfWork.Customers.GetById(Convert.ToString(rvm.CustomerId));
        TempData["message"] = "Selected" + selectedCustomer.FullName;
        var products = _unitOfWork.Products.GetAll();
        rvm.customer = selectedCustomer;
        rvm.Products = products;
        return View("ProductSelect", rvm);
      }
      catch (Exception ex)
      {
        TempData["error"] = ex.Message;
        return View();
      }
    }
    [HttpPost]
    public ActionResult ProductSelect(AddRegViewModel rvm)
    {
      try
      {
        DateTime now = DateTime.Now;
        Registration new_reg = new Registration()
        {
          CustomerId = Convert.ToInt32(rvm.CustomerId),
          ProductId = Convert.ToInt32(rvm.ProductId),
          RegisteredDate = now.Date
        };
        _unitOfWork.Registrations.Add(new_reg);
        TempData["message"] = "Record added successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Registration");
      }
      catch (Exception e)
      {
        return View();
      }
    }
    // GET: RegistrationController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: RegistrationController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: RegistrationController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: RegistrationController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: RegistrationController/Delete/5
    public ActionResult Delete(string id)
    {
      try
      {
        if (id != null)
        {
          if (id != "")
          {
            var del_reg = _unitOfWork.Registrations.GetById(id);
            if (del_reg != null)
            {
              TempData["message"] = "Found reg";
              var model = _mapper.Map<RegViewModel>(del_reg);
              model.Customer = _unitOfWork.Customers.GetById(Convert.ToString(model.CustomerId));
              model.Product = _unitOfWork.Products.GetById(Convert.ToString(model.ProductId));
              return View(model);
            }
            else
            {
              TempData["error"] = "Reg not found";
            }
          }
        }
        else
        {
          TempData["error"] = "Failed to pass the ids";
          return View("List");
        }
        return RedirectToAction("Index", "Registration");
      }
      catch (Exception ex)
      {
        TempData["error"] = "Failed to pass the ids";
        return View("Index");
      }
    }

    // POST: RegistrationController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(RegViewModel rvm)
    {
      try
      {
        var model = _mapper.Map<Registration>(rvm);
        _unitOfWork.Registrations.Delete(model);
        TempData["message"] = "Record deleted successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Registration");
      }
      catch (Exception e)
      {
        TempData["error"] = e.Message;
        return View();
      }
    }
  }
}
