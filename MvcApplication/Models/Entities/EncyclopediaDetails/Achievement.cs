using System.Collections.Generic;

namespace MvcApplication.Models.Entities.EncyclopediaDetails
{
  public class Achievement
  {
    public string Description { get; set; }
    public string ImageUri { get; set; }
    public string Name { get; set; }
    public string LocalizedName { get; set; }
    public long Order { get; set; }
    public string Section { get; set; }
    public long SectionOrder { get; set; }
    public string Type { get; set; }
    public List<AchievementOption> Options { get; set; }

    public override string ToString()
    {
      if (string.IsNullOrWhiteSpace(LocalizedName))
        return string.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;

      return LocalizedName;
    }
  }

  public class AchievementOption
  {
    public string ImageUri { get; set; }
    public string LocalizedName { get; set; }

    public override string ToString()
    {
      return string.IsNullOrWhiteSpace(LocalizedName) ? base.ToString() : LocalizedName;
    }
  }
}
