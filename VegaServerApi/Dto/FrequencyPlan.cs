using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto
{
    public class FrequencyPlan
    {
        /// <summary>
        /// Frequency for channel 4 in Hz.
        /// </summary>
        [JsonProperty("freq4")]
        public int Frequency4 { get; set; }

        /// <summary>
        /// Frequency for channel 5 in Hz.
        /// </summary>
        [JsonProperty("freq5")]
        public int Frequency5 { get; set; }

        /// <summary>
        /// Frequency for channel 6 in Hz.
        /// </summary>
        [JsonProperty("freq6")]
        public int Frequency6 { get; set; }

        /// <summary>
        /// Frequency for channel 7 in Hz.
        /// </summary>
        [JsonProperty("freq7")]
        public int Frequency7 { get; set; }

        /// <summary>
        /// Frequency for channel 8 in Hz.
        /// </summary>
        [JsonProperty("freq8")]
        public int Frequency8 { get; set; }
    }
}
