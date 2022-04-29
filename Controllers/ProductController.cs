using AutoMapper;
using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Models.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_LAIR.Controllers
{
  public class ProductController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ProductController(IUnitOfWork regUnit, IMapper mapper)
    {
      _unitOfWork = regUnit;
      _mapper = mapper;
    }
    // GET: ProductController
    public ActionResult Index()
    {
      var model = _unitOfWork.Products.GetAll();
      var vm = _mapper.Map<List<ProductViewModel>>(model);
      return View(vm);
    }

    // GET: ProductController/Details/5
    public ActionResult Details(int id)
    {
      var model = _unitOfWork.Products.GetById(Convert.ToString(id));
      var vm = _mapper.Map<ProductViewModel>(model);

      return View(vm);
    }

    // GET: ProductController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: ProductController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AddProductViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Product>(vm);
        _unitOfWork.Products.Add(model);
        TempData["message"] = vm.Name + " added successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Product");
      }
      catch
      {
        return View();
      }
    }

    // GET: ProductController/Edit/5
    public ActionResult Edit(int id)
    {
      var model = _unitOfWork.Products.GetById(Convert.ToString(id));
      var vm = _mapper.Map<AddProductViewModel>(model);

      return View(vm);
    }

    // POST: ProductController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(AddProductViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Product>(vm);
        _unitOfWork.Products.Update(model);
        TempData["message"] = vm.Name + " updated successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Product");
      }
      catch
      {
        return View();
      }
    }

    // GET: ProductController/Delete/5
    public ActionResult Delete(int id)
    {
      var model = _unitOfWork.Products.GetById(Convert.ToString(id));
      var vm = _mapper.Map<AddProductViewModel>(model);

      return View(vm);
    }

    // POST: ProductController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(AddProductViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Product>(vm);
        _unitOfWork.Products.Delete(model);
        TempData["message"] = "Product deleted successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Product");
      }
      catch
      {
        return View();
      }
    }
  }
}
