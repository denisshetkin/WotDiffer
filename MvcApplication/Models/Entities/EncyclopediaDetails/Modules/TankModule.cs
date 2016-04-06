using System.Collections.Generic;

namespace MvcApplication.Models.Entities.EncyclopediaDetails.Modules
{
  public class TankModule : Module
  {
    public long Id { get; set; }
    public string Nation { get; set; }
    public string LocalizedNation { get; set; }
    public string Gold { get; set; }
    public List<long> CompatibleTankIds { get; set; }

    public int TankId { get; set; }
    public virtual TankViewModel TankViewModel { get; set; }
  }
}
