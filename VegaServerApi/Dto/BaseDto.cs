using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto
{
    public abstract class BaseDto
    {
        [JsonProperty("cmd")]
        public string Command { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("err_string")]
        public string ErrorString { get; set; }
    }
}
