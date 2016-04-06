using System.Collections.Generic;

namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class PrivateData
  {
    public string AccountType { get; set; }
    public string LocalizedAccountType { get; set; }
    public string AccountBanDetails { get; set; }
    public long EndTimeOfAccountBan { get; set; }
    public long Credits { get; set; }
    public long FreeExperience { get; set; }
    public List<long> FriendIds { get; set; }
    public long Gold { get; set; }
    public long HasMobile { get; set; }
    public long HasPremium { get; set; }
    public long PremiumAccountExpiresAt { get; set; }
    public long ChatRestrictionsExpiresAt { get; set; }
    public long ClanRestrictionsExpiresAt { get; set; }
  }
}
