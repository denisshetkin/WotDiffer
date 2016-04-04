using System;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules
{
    public class Turret : TankModule
    {
        /// <summary>
        /// Armor: sides
        /// </summary>
        [JsonProperty("armor_board")]
        public long ArmorSides { get; set; }

        /// <summary>
        /// Armor: rear
        /// </summary>
        [JsonProperty("armor_fedd")]
        public long ArmorRear { get; set; }

        /// <summary>
        /// Armor: front
        /// </summary>
        [JsonProperty("armor_forehead")]
        public long ArmorFront { get; set; }

        /// <summary>
        /// View Range
        /// </summary>
        [JsonProperty("circular_vision_radius")]
        public long ViewRange { get; set; }

        /// <summary>
        /// Traverse speed
        /// </summary>
        [JsonProperty("rotation_speed")]
        public long TraverseSpeed { get; set; }

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
