using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models.ViewModels.IncidentViewModels
{
  public class AddEditIncidentViewModel
  {
    [Key]
    public int? Id { get; internal set; }

    [Required]
    public string? Title { get; set; }
    public DateTime? DateOpened { get; set; }
    public string? Description { get; set; }

    [Required]
    public int? CustomerId { get; set; }

    [Required]
    public int? ProductId { get; set; }
    public int? TechnicianId { get; set; }

    // "Add" or "Edit".
    public string Operation { get; set; }

    public List<SelectListItem>? Customers { get; set; }
    public List<SelectListItem>? Products { get; set; }
    public List<SelectListItem>? Technicians { get; set; }
  }
}
