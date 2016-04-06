using System.Collections.Generic;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class PlayerTankViewModel : EncyclopediaDetails.TankViewModel
  {
    public PlayerTankViewModel()
    {
      Achievements = new List<PlayerAchievement>();
    }

    private long masteryBadge = -1;
    public long MasteryBadge { get { return masteryBadge; } set { masteryBadge = value; } }

    public TankStatistics TankStatistics { get; set; }
    public OverallStatistics Overall { get; set; }
    public ClanStatistics Clan { get; set; }
    public CompanyStatistics Company { get; set; }
    public TeamStatistics Team { get; set; }
    public int MaxFrags { get; set; }
    public int MaxXp { get; set; }
    public Player Player { get; set; }
    public List<PlayerAchievement> Achievements { get; set; }

    public override string ToString()
    {
      return Id != 0 ? Id.ToString() : base.ToString();
    }
  }
}
