namespace MvcApplication.Models.Entities.EncyclopediaDetails.Modules
{
    public class Engine : TankModule
    {
        public long ChanceOfFire { get; set; }
        public long Power { get; set; }
        public long? PriceXp { get; set; }
        public decimal? Weight { get; set; }
    }
}
