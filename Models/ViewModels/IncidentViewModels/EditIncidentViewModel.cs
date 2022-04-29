using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting_LAIR.Models.ViewModels.IncidentViewModels
{
  public class EditIncidentViewModel
  {
    [Key]
    public int Id { get; internal set; }
    [Required]
    public string Title { get; set; }
    public DateTime Date { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public int TechnicianId { get; set; }

    public string? Description { get; set; }

    //drop downs
    public List<SelectListItem>? Customers { get; set; }
    public List<SelectListItem>? Products { get; set; }
    public List<SelectListItem>? Technicians { get; set; }
  }
}
