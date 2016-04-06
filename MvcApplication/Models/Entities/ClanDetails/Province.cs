namespace MvcApplication.Models.Entities.ClanDetails
{
  public class Province
  {
    public long ArenaId { get; set; }
    public string ArenaName { get; set; }
    public string ArenaNameLocalized { get; set; }
    public bool IsAttacked { get; set; }
    public bool IsCombatRunning { get; set; }
    public string Name { get; set; }
    public long OccupancyTime { get; set; }
    public long PrimeTime { get; set; }
    public string Id { get; set; }
    public long Revenue { get; set; }
    public string Type { get; set; }
  }
}
