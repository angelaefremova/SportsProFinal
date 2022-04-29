using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GBCSporting_LAIR.Models
{
  // Simple Model
  public class Incident
  {
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }

    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int TechnicianId { get; set; }

    public string? Description { get; set; }
    public DateTime DateOpened { get; set; }
    public DateTime? DateClosed { get; set; }
  }
}
