using System.Data.Entity;
using MvcApplication.Models.Entities.EncyclopediaDetails;

namespace MvcApplication.Models
{
  public class WotContext : DbContext
  {
    public DbSet<TankViewModel> Tanks { get; set; }
  }
}