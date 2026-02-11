using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Air_Quality_Monitoring
{
    // 경고설정 클래스

    public enum AirGrade
    {
        Good,
        Normal,
        Bad,
        VeryBad
    }

    public class AlertItem
    {
        public double Good { get; set; }
        public double Normal { get; set; }
        public double Bad { get; set; }

        // true = 값이 작아질수록 나쁨 (산소)
        public bool Reverse { get; set; }
    }

    public class AlertSettings
    {
        public AlertItem Temperature { get; set; } = new AlertItem { Good = 25, Normal = 27, Bad = 30, Reverse = false };
        public AlertItem Humidity { get; set; } = new AlertItem { Good = 60, Normal = 70, Bad = 80, Reverse = false };
        public AlertItem Oxygen { get; set; } = new AlertItem { Good = 20.5, Normal = 19.5, Bad = 18, Reverse = true };
        public AlertItem CO2 { get; set; } = new AlertItem { Good = 800, Normal = 1000, Bad = 1500, Reverse = false };
        public AlertItem PM10 { get; set; } = new AlertItem { Good = 30, Normal = 80, Bad = 150, Reverse = false };
        public AlertItem PM25 { get; set; } = new AlertItem { Good = 15, Normal = 35, Bad = 75, Reverse = false };
    }
}
