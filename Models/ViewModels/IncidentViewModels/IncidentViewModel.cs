using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting_LAIR.Models.ViewModels.IncidentViewModels
{
  public class IncidentViewModel
  {
    public int Id { get; internal set; }
    public string? Title { get; set; }
    public string? CustomerName { get; set; }
    public string? ProductName { get; set; }
    public DateTime Date { get; set; }

    // List of Customers
    public List<SelectListItem>? Customers { get; set; }
    public List<SelectListItem>? Products { get; set; }
    public List<SelectListItem>? Technicians { get; set; }
  }
}
