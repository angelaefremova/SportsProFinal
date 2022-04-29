using AutoMapper;
using GBCSporting_LAIR.Interfaces;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Models.ViewModels.TechnicianViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting_LAIR.Controllers
{
  public class TechnicianController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public TechnicianController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    // GET: TechnicianController
    public ActionResult Index()
    {
      var model = _unitOfWork.Technicians.GetAll();
      var vm = _mapper.Map<List<TechnicianViewModel>>(model);
      return View(vm);
    }

    // GET: TechnicianController/Details/5
    public ActionResult Details(int id)
    {
      var model = _unitOfWork.Technicians.GetById(Convert.ToString(id));
      var vm = _mapper.Map<TechnicianViewModel>(model);
      return View(vm);
    }

    // GET: TechnicianController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: TechnicianController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(AddTechnicianViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Technician>(vm);
        _unitOfWork.Technicians.Add(model);
        TempData["message"] = vm.Name + " added successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Technician");
      }
      catch
      {
        return View();
      }
    }

    // GET: TechnicianController/Edit/5
    public ActionResult Edit(int id)
    {
      var model = _unitOfWork.Technicians.GetById(Convert.ToString(id));
      var vm = _mapper.Map<AddTechnicianViewModel>(model);
      return View(vm);
    }

    // POST: TechnicianController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(AddTechnicianViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Technician>(vm);
        _unitOfWork.Technicians.Update(model);
        TempData["message"] = vm.Name + " updated successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Technician");
      }
      catch
      {
        return View();
      }
    }

    // GET: TechnicianController/Delete/5
    public ActionResult Delete(int id)
    {
      var model = _unitOfWork.Technicians.GetById(Convert.ToString(id));
      var vm = _mapper.Map<AddTechnicianViewModel>(model);
      return View(vm);
    }

    // POST: TechnicianController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(AddTechnicianViewModel vm)
    {
      try
      {
        var model = _mapper.Map<Technician>(vm);
        _unitOfWork.Technicians.Delete(model);
        TempData["message"] = vm.Name + " has been fired successfully.";
        _unitOfWork.Save();
        return RedirectToAction("Index", "Technician");
      }
      catch
      {
        return View();
      }
    }
  }
}
