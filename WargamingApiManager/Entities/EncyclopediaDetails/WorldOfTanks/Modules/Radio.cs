using System;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules
{
    public class Radio : TankModule
    {
        /// <summary>
        /// Signal range
        /// </summary>
        [JsonProperty("distance")]
        public long Distance { get; set; }

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
