using AutoMapper;
using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Models.ViewModels.CustomerViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting_LAIR.Controllers
{
  public class CustomerController : Controller
  {
    private readonly SportsProContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public CustomerController(IUnitOfWork unitOfWork, IMapper mapper, SportsProContext context)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _context = context;
    }

    // GET: CustomerController
    public IActionResult Index()
    {
      var model = _unitOfWork.Customers.GetAll();
      var vm = _mapper.Map<List<CustomerViewModel>>(model);
      return View(vm);
    }

    // GET: CustomerController/Details/5
    public ActionResult Details(int id)
    {
      var customer = _unitOfWork.Customers.GetById(Convert.ToString(id));
      var vm = _mapper.Map<CustomerViewModel>(customer);
      vm.Country = _unitOfWork.Countries.GetById(Convert.ToString(customer.CountryId));

      var productsFromRepo = _unitOfWork.Products.GetAll();
      var regs = _unitOfWork.Registrations.GetAll();
      foreach (var reg in regs)
      {
        if (reg.CustomerId == customer.CustomerId)
        {
          vm.Products.Add(_unitOfWork.Products.GetById(Convert.ToString(reg.ProductId)));
        }
      }

      return View(vm);
    }

    // GET: CustomerController/Create
    public ActionResult Create() 
    {
      var countries = _unitOfWork.Countries.GetAll();
      var countryList = new List<SelectListItem>();
      foreach (var c in countries)
      {
        countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
      }
      var vm = new AddCustomerViewModel()
      {
        Countries = countryList
      };
      return View(vm);
    }

    // POST: CustomerController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AddCustomerViewModel vm)
    {
      var email = (from e in _unitOfWork.Customers.GetAll()
                   where e.Email == vm.Email
                   select e).ToList();
      if (ModelState.IsValid)
      {
        try
        {
          // We can map the "AddCustomerViewMode" object into "Customer" object type
          var model = _mapper.Map<Customer>(vm);
          if (email.Count > 0)
          {
            TempData["warning"] = vm.Email + " is not available.";
            var countries = _unitOfWork.Countries.GetAll();
            var countryList = new List<SelectListItem>();
            foreach (var c in countries)
            {
              countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
            }
            vm.Countries = countryList;
            return View(vm);
          } else
          {
            TempData["message"] = vm.FullName + " added successfully.";
            _unitOfWork.Customers.Add(model);
            _unitOfWork.Save();

            return RedirectToAction("Index", "Customer");
          }
        }
        catch
        {
          var countries = _unitOfWork.Countries.GetAll();
          var countryList = new List<SelectListItem>();
          foreach (var c in countries)
          {
            countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
          }
          vm.Countries = countryList;
          return View(vm);
        }
      } else
      {
        var countries = _unitOfWork.Countries.GetAll();
        var countryList = new List<SelectListItem>();
        foreach (var c in countries)
        {
          countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
        }
        vm.Countries = countryList;
        return View(vm);
      }
    }

    // GET: CustomerController/Edit/5
    public ActionResult Edit(int id)
    {
      var countries = _unitOfWork.Countries.GetAll();
      var countryList = new List<SelectListItem>();
      foreach (var c in countries)
      {
        countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
      }

      var model = _unitOfWork.Customers.GetById(Convert.ToString(id));
      var vm = _mapper.Map<AddCustomerViewModel>(model);

      vm.Countries = countryList;
      return View(vm);
    }

    // POST: CustomerController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(AddCustomerViewModel vm)
    {
      var email = (from e in _unitOfWork.Customers.GetAll()
                   where e.Email == vm.Email
                   select e).ToList();
      if (ModelState.IsValid)
      {
        try
        {
          // We can map the "AddCustomerViewMode" object into "Customer" object type
          var model = _mapper.Map<Customer>(vm);
          if (email.Count > 0)
          {
            TempData["warning"] = vm.Email + " is not available.";
            var countries = _unitOfWork.Countries.GetAll();
            var countryList = new List<SelectListItem>();
            foreach (var c in countries)
            {
              countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
            }
            vm.Countries = countryList;
            return View(vm);
          }
          else
          {
            TempData["message"] = vm.FullName + " updated successfully.";
            _unitOfWork.Customers.Add(model);
            _unitOfWork.Save();

            return RedirectToAction("Index", "Customer");
          }
        }
        catch
        {
          var countries = _unitOfWork.Countries.GetAll();
          var countryList = new List<SelectListItem>();
          foreach (var c in countries)
          {
            countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
          }
          vm.Countries = countryList;
          return View(vm);
        }
      }
      else
      {
        var countries = _unitOfWork.Countries.GetAll();
        var countryList = new List<SelectListItem>();
        foreach (var c in countries)
        {
          countryList.Add(new SelectListItem(c.Name, Convert.ToString(c.Id)));
        }
        vm.Countries = countryList;
        return View(vm);
      }
    }

    // GET: CustomerController/Delete/5
    public ActionResult Delete(int id)
    {
      var model = _unitOfWork.Customers.GetById(Convert.ToString(id));
      var vm = _mapper.Map<AddCustomerViewModel>(model);
      return View(vm);
    }

    // POST: CustomerController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(AddCustomerViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Customer>(vm);

        _unitOfWork.Customers.Delete(model);
        TempData["message"] = "Customer record deleted successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Customer");
      }
      catch (Exception ex)
      {
        TempData["error"] = ex.Message;
        return View("Index");
      }
    }
  }
}
