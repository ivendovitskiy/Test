using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto.UserAuthorization
{
    public class AuthResponse : BaseDto
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        public AuthResponse()
        {
        }
    }
}
