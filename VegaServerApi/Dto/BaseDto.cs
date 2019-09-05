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
    }
}
