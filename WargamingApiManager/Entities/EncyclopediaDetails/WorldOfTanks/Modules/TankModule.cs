using System.Collections.Generic;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Modules
{
    public class TankModule : Module
    {
        /// <summary>
        /// Module ID
        /// </summary>
        [JsonProperty("module_id")]
        public long Id { get; set; }

        /// <summary>
        /// Nation
        /// </summary>
        [JsonProperty("nation")]
        public string Nation { get; set; }

        /// <summary>
        /// Localized nation
        /// </summary>
        [JsonProperty("nation_i18n")]
        public string LocalizedNation { get; set; }

        /// <summary>
        /// Purchase cost in gold
        /// </summary>
        [JsonProperty("price_gold")]
        public string Gold { get; set; }

        /// <summary>
        /// Compatible vehicles IDs
        /// </summary>
        [JsonProperty("tanks")]
        public List<long> CompatibleTankIds { get; set; }
    }
}
