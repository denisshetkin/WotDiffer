using MvcApplication.Models.Enums;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class TeamStatistics : BaseStatistics
  {
    public override StatisticsType StatisticsType
    {
      get { return StatisticsType.Team; }
    }
  }
}
