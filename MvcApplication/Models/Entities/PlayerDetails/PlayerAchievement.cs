namespace MvcApplication.Models.Entities.PlayerDetails
{
  public class PlayerAchievement
  {
    public string Name { get; set; }
    public long TimesAchieved { get; set; }

    public override string ToString()
    {
      return string.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;
    }
  }
}
