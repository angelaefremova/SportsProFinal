namespace GBCSporting_LAIR.Models.ViewModels.IncidentViewModels
{
  public class ConfirmEditIncidentViewModel
  {
    public int IncidentId { get; set; }
    public int CustomerId { get; set; }
    public int TechnicianId { get; set; }
    public int ProductId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
  }
}
