using System.Collections.Generic;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class Player
  {
    public Player()
    {
      Achievements = new List<PlayerAchievement>();
      Tanks = new List<PlayerTankViewModel>();
    }

    public long AccountId { get; set; }
    public string Nickname { get; set; }
    public long CreatedAt { get; set; }
    public decimal GlobalRating { get; set; }
    public long LastBattleTime { get; set; }
    public long LastLogout { get; set; }
    public long UpdatedAt { get; set; }
    public Achievements AchievementsOld { get; set; }
    public PrivateData Private { get; set; }
    public PlayerStatistics Statistics { get; set; }
    public List<PlayerAchievement> Achievements { get; set; }
    public List<PlayerTankViewModel> Tanks { get; set; }

    public override string ToString()
    {
      string result;

      if (!string.IsNullOrWhiteSpace(Nickname))
        result = Nickname;
      else if (AccountId != 0)
        result = AccountId.ToString();
      else
        result = base.ToString();

      return result;
    }
  }
}
