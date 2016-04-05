using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks
{
  public class CompatibleModules
  {
    /// <summary>
    /// Cost of research in experience
    /// </summary>
    [JsonProperty("module_id")]
    public long? ModuleId { get; set; }

    /// <summary>
    /// Cost of research in experience
    /// </summary>
    [JsonProperty("is_default")]
    public bool? IsDefault { get; set; }
  }
}
