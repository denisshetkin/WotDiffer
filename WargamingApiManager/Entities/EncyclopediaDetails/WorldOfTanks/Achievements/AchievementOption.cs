using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks.Achievements
{
    public class AchievementOption
    {
        /// <summary>
        /// Image
        /// </summary>
        [JsonProperty("image")]
        public string ImageURI { get; set; }

        /// <summary>
        /// Localized name field
        /// </summary>
        [JsonProperty("name_i18n")]
        public string LocalizedName { get; set; }

        #region Overrides

        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(LocalizedName) ? base.ToString() : LocalizedName;
        }

        #endregion Overrides
    }
}
