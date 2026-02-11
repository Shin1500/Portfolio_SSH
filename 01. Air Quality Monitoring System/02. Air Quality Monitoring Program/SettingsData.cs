using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Air_Quality_Monitoring
{
    public class SettingsData
    {
        // 설정 데이터 클래스

        public string ServerIP { get; set; } = "192.168.0.130";

        public int ServerPort { get; set; } = 6000;

        public AlertSettings Alerts { get; set; } = new AlertSettings();

        private static readonly string FilePath = "Setting.json";

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public static SettingsData Load()
        {
            if (!File.Exists(FilePath))
            {
                var defaultSettings = new SettingsData();
                defaultSettings.Save();

                return defaultSettings;
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<SettingsData>(json) ?? new SettingsData();
        }
    }
}
