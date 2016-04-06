using System.Collections.Generic;

namespace MvcApplication.Models.Entities.ClanDetails
{
  public class Clan
  {
    public string Tag { get; set; }
    public long Id { get; set; }
    public string Color { get; set; }
    public long CreatedAt { get; set; }
    public string Description { get; set; }
    public string DescriptionHtml { get; set; }
    public string IsDisbanded { get; set; }
    public long MembersCount { get; set; }
    public string Motto { get; set; }
    public string Name { get; set; }
    public long CommanderId { get; set; }
    public string CommanderName { get; set; }
    public string RatingPosition { get; set; }
    public string VictoryPoints { get; set; }
    public string VictoryPointsStage { get; set; }
    public string VictoryPointsTurn { get; set; }
    public string CanInvite { get; set; }
    public long UpdatedAt { get; set; }
    public Emblem Emblems { get; set; }
    private IList<Member> _members = new List<Member>();
    public IList<Member> Members { get { return _members; } set { _members = value; } }
  }
}