using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestCoreApp.Services.Settings
{
    public class Settings
    {
        [JsonPropertyName("DevicesPath")]
        public string DevicesPath { get; set; } = "";

        [JsonPropertyName("ResponsePath")]
        public string ResponsePath { get; set; } = "";

        [JsonPropertyName("ProtocolPath")]
        public string ProtocolPath { get; set; } = "";
    }
}
