namespace MvcApplication.Models.Entities.ClanDetails
{
  public class Member
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public long ClanId { get; set; }
    public string ClanName { get; set; }
    public long DateJoined { get; set; }
    public string Role { get; set; }
    public string LocalizedRole { get; set; }
    public long DateDetailsUpdated { get; set; }
    public long Since { get; set; }
  }
}