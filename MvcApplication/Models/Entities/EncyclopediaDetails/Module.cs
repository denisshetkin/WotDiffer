namespace MvcApplication.Models.Entities.EncyclopediaDetails
{
  public class Module
  {
    public long? ModuleId { get; set; }
    public bool? IsDefault { get; set; }
    public long Tier { get; set; }
    public string Name { get; set; }
    public string LocalizedName { get; set; }
    public string Credits { get; set; }

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
