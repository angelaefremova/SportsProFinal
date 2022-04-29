using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models.ViewModels.TechIncidentViewModels
{
  public class EditTechIncidentViewModel
  {
    [Key]
    public int? IncidentId { get; internal set; }
    public string? Title { get; set; }
    public DateTime? DateOpened { get; set; }
    public DateTime? DateClosed { get; set; }
    public string? Description { get; set; }
    public string? Customer { get; set; }
    public string? Product { get; set; }
    public string? Technician { get; set; }
    public int? TechnicianId { get; set; }
  }
}
