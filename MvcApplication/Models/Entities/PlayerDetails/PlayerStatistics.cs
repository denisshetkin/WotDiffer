namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class PlayerStatistics
  {
    public OverallStatistics Overall { get; set; }
    public ClanStatistics Clan { get; set; }
    public CompanyStatistics Company { get; set; }
    public long MaxXp { get; set; }
  }
}
