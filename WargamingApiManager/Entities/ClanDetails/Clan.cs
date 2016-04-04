using System.Collections.Generic;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.ClanDetails
{
    public class Clan
    {
        [JsonProperty("abbreviation")]
        public string Tag { get; set; }

        [JsonProperty("clan_id")]
        public long Id { get; set; }

        [JsonProperty("clan_color")]
        public string Color { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("description_html")]
        public string DescriptionHtml { get; set; }

        [JsonProperty("is_clan_disbanded")]
        public string IsDisbanded { get; set; }

        [JsonProperty("members_count")]
        public long MembersCount { get; set; }

        [JsonProperty("motto")]
        public string Motto { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long CommanderId { get; set; }

        [JsonProperty("owner_name")]
        public string CommanderName { get; set; }

        /// <summary>
        /// Position in rating -- populated only if clan is returned by top 100 method
        /// </summary>
        [JsonProperty("rating_position")]
        public string RatingPosition { get; set; }

        /// <summary>
        /// Victory points for the entire campaign -- populated only if clan is returned by top 100 method
        /// </summary>
        [JsonProperty("victory_points")]
        public string VictoryPoints { get; set; }

        /// <summary>
        /// Victory points for the current stage -- populated only if clan is returned by top 100 method
        /// </summary>
        [JsonProperty("victory_points_step_delta")]
        public string VictoryPointsStage { get; set; }

        /// <summary>
        /// Victory points for the latest turn -- populated only if clan is returned by top 100 method
        /// </summary>
        [JsonProperty("victory_points_turn_delta")]
        public string VictoryPointsTurn { get; set; }

        /// <summary>
        /// Clan can invite players
        /// </summary>
        [JsonProperty("request_availability")]
        public string CanInvite { get; set; }

        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonProperty("emblems")]
        public Emblem Emblems { get; set; }

        private IList<Member> _members = new List<Member>();
        /// <summary>
        /// Populated by parser
        /// </summary>
        [JsonIgnore]
        public IList<Member> Members { get { return _members; } set { _members = value; } }
    }
}