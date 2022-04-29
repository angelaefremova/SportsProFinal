using GBCSporting_LAIR.Models.ViewModels.IncidentViewModels;

namespace GBCSporting_LAIR.Models.ViewModels.IncidentViewModels
{
  public class IncidentsViewModel
  {
    public IEnumerable<IncidentViewModel>? Incidents { get; set; }
    public string? SelectedFilter { get; set; }
  }
}
