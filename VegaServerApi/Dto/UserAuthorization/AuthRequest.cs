using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaServerApi.Dto.UserAuthorization
{
    public class AuthRequest : BaseDto
    {
        /// <summary>
        /// Case insensitive string.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; set; }

        /// <summary>
        /// Original password string without any encoding.
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        public AuthRequest()
        {
            Command = "auth_req";
        }
    }
}
