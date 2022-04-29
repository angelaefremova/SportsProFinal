using AutoMapper;
using GBCSporting_LAIR.Models;
using GBCSporting_LAIR.Models.ViewModels.CustomerViewModels;
using GBCSporting_LAIR.Models.ViewModels.ProductViewModels;
using GBCSporting_LAIR.Models.ViewModels.RegViewModel;
using GBCSporting_LAIR.Models.ViewModels.TechnicianViewModels;

namespace GBCSporting_LAIR.Helpers
{
  public class Helper : Profile
  {
    public Helper()
    {
      CreateMap<Customer, CustomerViewModel>().ReverseMap();
      CreateMap<AddCustomerViewModel, Customer>().ReverseMap();

      CreateMap<Product, ProductViewModel>().ReverseMap();
      CreateMap<AddProductViewModel, Product>().ReverseMap();

      CreateMap<Technician, TechnicianViewModel>().ReverseMap();
      CreateMap<AddTechnicianViewModel, Technician>().ReverseMap();

      CreateMap<Registration, RegViewModel>().ReverseMap();
      CreateMap<AddRegViewModel, Registration>().ReverseMap();
    }
  }
}
