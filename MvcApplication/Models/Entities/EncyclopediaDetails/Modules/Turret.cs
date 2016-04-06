namespace MvcApplication.Models.Entities.EncyclopediaDetails.Modules
{
  public class Turret : TankModule
  {
    public long ArmorSides { get; set; }
    public long ArmorRear { get; set; }
    public long ArmorFront { get; set; }
    public long ViewRange { get; set; }
    public long TraverseSpeed { get; set; }
    public long? PriceXp { get; set; }
    public decimal? Weight { get; set; }
  }
}
