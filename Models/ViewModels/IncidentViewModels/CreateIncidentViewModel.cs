namespace GBCSporting_LAIR.Models.ViewModels.IncidentViewModels
{
  public class CreateIncidentViewModel
  {
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int TechnicianId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
  }
}
