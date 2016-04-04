using Newtonsoft.Json;
using System.Collections.Generic;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Achievements
{
    public class TankAchievement : Achievement
    {
        /// <summary>
        /// Section order
        /// </summary>
        [JsonProperty("section_order")]
        public long SectionOrder { get; set; }

        /// <summary>
        /// Service Record
        /// </summary>
        [JsonProperty("options")]
        public List<AchievementOption> Options { get; set; }
    }
}
