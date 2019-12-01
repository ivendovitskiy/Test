using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TestCoreApp.Services.Settings
{
    public class SettingsService
    {
        public SettingsService()
        {
            settingsPath = Path.Combine(Environment.CurrentDirectory,  "settings.json");
            LoadSettings();
        }

        private readonly string settingsPath;

        public Settings LoadSettings()
        {
            if (File.Exists(settingsPath))
            {
                using(StreamReader sr = File.OpenText(settingsPath))
                {
                    Settings = JsonSerializer.Deserialize<Settings>(sr.ReadToEnd(), new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                }
            }
            else
            {
                SaveSettings();
            }

            return new Settings();
        }

        public void SaveSettings()
        {
            using(StreamWriter file = File.CreateText(settingsPath))
            {
                string json;

                if (Settings == null)
                {
                    json = JsonSerializer.Serialize(new Settings());
                }
                else
                {
                    json = JsonSerializer.Serialize(Settings);
                }
                
                file.Write(json);                
            }
        }

        public Settings Settings { get; private set; }
    }
}
