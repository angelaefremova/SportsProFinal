namespace GBCSporting_LAIR.Models.ViewModels.TechnicianViewModels
{
  public class TechnicianViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Cell { get; set; }

    public List<Incident> Incidents { get; set; }
  }
}
