using MvcApplication.Models.Enums;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class OverallStatistics : BaseStatistics
  {
    public override StatisticsType StatisticsType
    {
      get { return StatisticsType.Overall; }
    }
  }
}
