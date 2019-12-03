using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace TestCoreApp.Services.Settings
{
    public class SettingsService : PropertyChangedBase
    {
        public SettingsService()
        {
            settingsPath = Path.Combine(Environment.CurrentDirectory, "settings.json");
            LoadSettings();
        }

        private readonly string settingsPath;

        public void LoadSettings()
        {
            if (File.Exists(settingsPath))
            {
                using (StreamReader sr = File.OpenText(settingsPath))
                {
                    Settings = JsonSerializer.Deserialize<Settings>(sr.ReadToEnd(), new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    });
                }
            }
            else
            {
                SaveSettings();
            }
        }

        public void SaveSettings()
        {
            using (StreamWriter file = File.CreateText(settingsPath))
            {
                string json;

                if (Settings == null)
                {
                    json = JsonSerializer.Serialize(new Settings()
                    {
                        ConnectionString = string.Empty,
                        DevicesPath = string.Empty,
                        ProtocolPath = string.Empty,
                        ResponsePath = string.Empty
                    });
                }
                else
                {
                    json = JsonSerializer.Serialize(Settings);
                }

                file.Write(json);
            }
        }

        private Settings settings;
        public Settings Settings
        {
            get => settings;
            set => Notify(ref settings, value);
        }
    }
}
