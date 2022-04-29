using GBCSporting_LAIR.Models.ViewModels.IncidentViewModels;

namespace GBCSporting_LAIR.Models.ViewModels.TechIncidentViewModels
{
  public class ListTechIncidentsViewModel
  {
    public string? TechnicianName { get; set; }
    public IList<IncidentViewModel>? Incidents { get; set; }
  }
}
