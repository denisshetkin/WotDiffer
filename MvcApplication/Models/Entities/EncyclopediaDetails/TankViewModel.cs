using System.Collections.Generic;
using MvcApplication.Models.Entities.EncyclopediaDetails.Modules;

namespace MvcApplication.Models.Entities.EncyclopediaDetails
{
    public class TankViewModel : VehicleViewModel
    {
        public long Id { get; set; }
        public long SuspensionRotationSpeed { get; set; }
        public long CircularVisionRadius { get; set; }
        public string ContourImage { get; set; }
        public long EnginePower { get; set; }
        public long GunDamageMax { get; set; }
        public long GunDamageMin { get; set; }
        public long GunMaxAmmo { get; set; }
        public string GunName { get; set; }
        public long GunPiercingPowerMax { get; set; }
        public long GunPiercingPowerMin { get; set; }
        public decimal GunRateOfFire { get; set; }
        public string Image { get; set; }
        public string ImageSmall { get; set; }
        public bool IsGift { get; set; }
        public decimal LoadLimit { get; set; }
        public string LocalizedNameObs { get; set; }
        public long HitPoints { get; set; }
        public long PriceCredit { get; set; }
        public long PriceGold { get; set; }
        public long RadioDistance { get; set; }
        public decimal SpeedLimit { get; set; }
        public long TurretArmorFront { get; set; }
        public long TurretArmorRear { get; set; }
        public long TurretArmorSides2 { get; set; }
        public long TurretRotationSpeed { get; set; }
        public long ArmorSides { get; set; }
        public long ArmorRear { get; set; }
        public long ArmorFront { get; set; }
        public List<long> ParentTanks { get; set; }
        public long? PriceXp { get; set; }
        public decimal Weight { get; set; }

        public List<Gun> Guns { get; set; }
        public List<Chassis> Chassis { get; set; }
        public List<Turret> Turrets { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Radio> Radios { get; set; }
    }
}
