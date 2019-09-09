using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto
{
    /// <summary>
    /// Activation By Personalization 
    /// </summary>
    public class Abp
    {
        /// <summary>
        /// 32-bit device address (should be less then 0x01FFFFFF)
        /// </summary>
        [JsonProperty("devAddress")]
        public int DevAddress { get; set; }

        /// <summary>
        /// Application session key [contains symbols 0-9a-fA-F].
        /// </summary>
        [JsonProperty("appsKey")]
        public string AppSKey { get; set; }

        /// <summary>
        /// Network session key [contains symbols 0-9a-fA-F].
        /// </summary>
        [JsonProperty("nwksKey")]
        public string NwkSKey { get; set; }
    }
}
