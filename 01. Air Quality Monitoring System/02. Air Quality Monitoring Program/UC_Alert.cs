using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air_Quality_Monitoring
{
    public partial class UC_Alert : UserControl
    {
        // 경고 임계값 설정폼

        public UC_Alert()
        {
            InitializeComponent();
        }

        public void LoadSettings(AlertSettings t)
        {
            num_temp_good.Value = (decimal)t.Temperature.Good;
            num_temp_normal.Value = (decimal)t.Temperature.Normal;
            num_temp_bad.Value = (decimal)t.Temperature.Bad;

            num_humid_good.Value = (decimal)t.Humidity.Good;
            num_humid_normal.Value = (decimal)t.Humidity.Normal;
            num_humid_bad.Value = (decimal)t.Humidity.Bad;

            num_oxy_good.Value = (decimal)t.Oxygen.Good;
            num_oxy_normal.Value = (decimal)t.Oxygen.Normal;
            num_oxy_bad.Value = (decimal)t.Oxygen.Bad;

            num_co2_good.Value = (decimal)t.CO2.Good;
            num_co2_normal.Value = (decimal)t.CO2.Normal;
            num_co2_bad.Value = (decimal)t.CO2.Bad;

            num_pm10_good.Value = (decimal)t.PM10.Good;
            num_pm10_normal.Value = (decimal)t.PM10.Normal;
            num_pm10_bad.Value = (decimal)t.PM10.Bad;

            num_pm25_good.Value = (decimal)t.PM25.Good;
            num_pm25_normal.Value = (decimal)t.PM25.Normal;
            num_pm25_bad.Value = (decimal)t.PM25.Bad;
        }

        public AlertSettings GetSettings()
        {
            return new AlertSettings
            {
                Temperature = new AlertItem
                {
                    Good = (double)num_temp_good.Value,
                    Normal = (double)num_temp_normal.Value,
                    Bad = (double)num_temp_bad.Value,
                    Reverse = false
                },
                Humidity = new AlertItem
                {
                    Good = (double)num_humid_good.Value,
                    Normal = (double)num_humid_normal.Value,
                    Bad = (double)num_humid_bad.Value,
                    Reverse = false
                },
                Oxygen = new AlertItem
                {
                    Good = (double)num_oxy_good.Value,
                    Normal = (double)num_oxy_normal.Value,
                    Bad = (double)num_oxy_bad.Value,
                    Reverse = true
                },
                CO2 = new AlertItem
                {
                    Good = (double)num_co2_good.Value,
                    Normal = (double)num_co2_normal.Value,
                    Bad = (double)num_co2_bad.Value,
                    Reverse = false
                },
                PM10 = new AlertItem
                {
                    Good = (double)num_pm10_good.Value,
                    Normal = (double)num_pm10_normal.Value,
                    Bad = (double)num_pm10_bad.Value,
                    Reverse = false
                },
                PM25 = new AlertItem
                {
                    Good = (double)num_pm25_good.Value,
                    Normal = (double)num_pm25_normal.Value,
                    Bad = (double)num_pm25_bad.Value,
                    Reverse = false
                }
            };
        }
    }
}
