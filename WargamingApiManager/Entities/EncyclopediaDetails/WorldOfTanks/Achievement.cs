/*
The MIT License (MIT)

Copyright (c) 2014 Iulian Grosu

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WargamingApiManager.Entities.EncyclopediaDetails.WorldOfTanks
{
    public class Achievement
    {
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [JsonProperty("image")]
        public string ImageURI { get; set; }

        /// <summary>
        /// Achievement name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Localized name field
        /// </summary>
        [JsonProperty("name_i18n")]
        public string LocalizedName { get; set; }

        /// <summary>
        /// Achievement order
        /// </summary>
        [JsonProperty("order")]
        public long Order { get; set; }

        /// <summary>
        /// Section
        /// </summary>
        [JsonProperty("section")]
        public string Section { get; set; }

        /// <summary>
        /// Section order
        /// </summary>
        [JsonProperty("section_order")]
        public long SectionOrder { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Service Record
        /// </summary>
        [JsonProperty("options")]
        public List<AchievementOption> Options { get; set; }

        #region Overrides

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(LocalizedName))
                return string.IsNullOrWhiteSpace(Name) ? base.ToString() : Name;

            return LocalizedName;
        }

        #endregion Overrides
    }
}
