using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto
{
    /// <summary>
    /// Over The Air Activation
    /// </summary>
    public class Otaa
    {
        /// <summary>
        /// Application EUI (16 HEX digits).
        /// </summary>
        [JsonProperty("appEui")]
        public string AppEui { get; set; }

        /// <summary>
        /// Application key (32 HEX digits).
        /// </summary>
        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        /// <summary>
        /// Time of last join procedure [server UTC timestamp (ms from Linux epoch)].
        /// </summary>
        [JsonProperty("last_join_ts")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastJoinTs { get; set; }
    }
}
