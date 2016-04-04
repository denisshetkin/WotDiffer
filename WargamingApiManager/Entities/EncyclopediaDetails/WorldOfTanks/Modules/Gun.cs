using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules
{
    public class Gun : TankModule
    {
        /// <summary>
        /// Damage
        /// </summary>
        [JsonProperty("damage")]
        public List<long> Damage { get; set; }

        /// <summary>
        /// Penetration
        /// </summary>
        [JsonProperty("piercing_power")]
        public List<long> PiercingPower { get; set; }

        /// <summary>
        /// Rate of Fire
        /// </summary>
        [JsonProperty("rate")]
        public decimal RateOfFire { get; set; }

        /// <summary>
        /// Cost of research in experience
        /// </summary>
        [JsonProperty("price_xp")]
        [Obsolete("Warning. The field will be disabled.")]
        public long? PriceXp { get; set; }

        /// <summary>
        /// Cost of research in experience
        /// </summary>
        [JsonProperty("weight")]
        [Obsolete("Warning. The field will be disabled.")]
        public decimal? Weight { get; set; }
    }
}
