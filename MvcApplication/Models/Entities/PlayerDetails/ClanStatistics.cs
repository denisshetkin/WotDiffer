using MvcApplication.Models.Enums;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class ClanStatistics : BaseStatistics
  {
    public override StatisticsType StatisticsType
    {
      get { return StatisticsType.Clan; }
    }
  }
}
