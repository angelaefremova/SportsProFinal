using AutoMapper;
using GBCSporting_LAIR.Data;
using GBCSporting_LAIR.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GBCSporting_LAIR.Controllers
{
  public class HomeController : Controller
  {
    // Adds a private variable to the model that is used to query and assign specific values for the variables below
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    // Methods to display index and about page
    public IActionResult Index()
    {
      return View("Index");
    }
    public IActionResult About()
    {
      return View("About");
    }
  }
}