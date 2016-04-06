namespace MvcApplication.Models.Entities.EncyclopediaDetails
{
  public class VehicleViewModel
  {
    public bool IsPremium { get; set; }
    public long Tier { get; set; }
    public string Name { get; set; }
    public string LocalizedName { get; set; }
    public string Nation { get; set; }
    public string LocalizedNation { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
      string result;

      if (!string.IsNullOrWhiteSpace(LocalizedName))
        result = LocalizedName;
      else if (!string.IsNullOrWhiteSpace(Name))
        result = Name;
      else
        result = base.ToString();

      return result;
    }
  }
}
