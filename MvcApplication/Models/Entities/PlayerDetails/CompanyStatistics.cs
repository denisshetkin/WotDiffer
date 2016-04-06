using MvcApplication.Models.Enums;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class CompanyStatistics : BaseStatistics
  {
    public override StatisticsType StatisticsType
    {
      get { return StatisticsType.Company; }
    }
  }
}
