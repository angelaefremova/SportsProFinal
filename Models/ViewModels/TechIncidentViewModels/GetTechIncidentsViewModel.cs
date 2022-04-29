using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting_LAIR.Models.ViewModels.TechIncidentViewModels
{
  public class GetTechIncidentsViewModel
  {
    public List<SelectListItem>? Technicians { get; set; }
  }
}
