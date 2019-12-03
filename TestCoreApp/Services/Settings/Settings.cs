using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace TestCoreApp.Services.Settings
{
    public class Settings : PropertyChangedBase
    {
        private string devicesPath;
        private string responsePath;
        private string protocolPath;
        private string connectionString;

        [JsonPropertyName("DevicesPath")]
        public string DevicesPath
        {
            get => devicesPath;
            set => Notify(ref devicesPath, value);
        }

        [JsonPropertyName("ResponsePath")]
        public string ResponsePath
        {
            get => responsePath;
            set => Notify(ref responsePath, value);
        }

        [JsonPropertyName("ProtocolPath")]
        public string ProtocolPath
        {
            get => protocolPath;
            set => Notify(ref protocolPath, value);
        }

        [JsonPropertyName("ConnectionString")]
        public string ConnectionString
        {
            get => connectionString;
            set => Notify(ref connectionString, value);
        }
    }
}
