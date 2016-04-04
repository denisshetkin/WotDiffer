using System;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules
{
    public class Engine : TankModule
    {
        /// <summary>
        /// Chance of Fire
        /// </summary>
        [JsonProperty("fire_starting_chance")]
        public long ChanceOfFire { get; set; }

        /// <summary>
        /// Power
        /// </summary>
        [JsonProperty("power")]
        public long Power { get; set; }

        /// <summary>
        /// Cost of research in experience
        /// </summary>
        [JsonProperty("price_xp")]
        [Obsolete("Warning. The field will be disabled.")]
        public long? PriceXp { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        [JsonProperty("weight")]
        [Obsolete("Warning. The field will be disabled.")]
        public decimal? Weight { get; set; }
    }
}
