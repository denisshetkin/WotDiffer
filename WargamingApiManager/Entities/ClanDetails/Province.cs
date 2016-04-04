using Newtonsoft.Json;

namespace WargamingApiManager.Entities.ClanDetails
{
    public class Province
    {
        [JsonProperty("arena_id")]
        public long ArenaId { get; set; }

        [JsonProperty("arena_name")]
        public string ArenaName { get; set; }

        public string ArenaNameLocalized { get; set; }

        [JsonProperty("attacked")]
        public bool IsAttacked { get; set; }

        [JsonProperty("combats_running")]
        public bool IsCombatRunning { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Province owned (days)
        /// </summary>
        [JsonProperty("occupancy_time")]
        public long OccupancyTime { get; set; }

        /// <summary>
        /// Prime Time
        /// </summary>
        [JsonProperty("prime_time")]
        public long PrimeTime { get; set; }

        [JsonProperty("province_id")]
        public string Id { get; set; }

        [JsonProperty("revenue")]
        public long Revenue { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
