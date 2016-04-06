using System.Collections.Generic;

namespace MvcApplication.Models.Entities.EncyclopediaDetails.Modules
{
  public class Gun : TankModule
  {
    public List<long> Damage { get; set; }
    public List<long> PiercingPower { get; set; }
    public decimal RateOfFire { get; set; }
    public long? PriceXp { get; set; }
    public decimal? Weight { get; set; }
  }
}
