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
    // 각 항목 데이터 UI폼 

    public partial class IndexGrade : UserControl
    {
        public IndexGrade()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            SetValueVisible(false);
        }

        private AirGrade GetGrade(double value, AlertItem item)
        {
            if (!item.Reverse)
            {
                if (value <= item.Good) return AirGrade.Good;
                if (value <= item.Normal) return AirGrade.Normal;
                if (value <= item.Bad) return AirGrade.Bad;
                return AirGrade.VeryBad;
            }
            else // 산소처럼 높을수록 좋은 경우
            {
                if (value >= item.Good) return AirGrade.Good;
                if (value >= item.Normal) return AirGrade.Normal;
                if (value >= item.Bad) return AirGrade.Bad;
                return AirGrade.VeryBad;
            }
        }

        private void ApplyGrade(Label label, PictureBox pictureBox, AirGrade grade)
        {
            switch (grade)
            {
                case AirGrade.Good:
                    label.Text = "좋음";
                    label.ForeColor = Color.Blue;
                    break;

                case AirGrade.Normal:
                    label.Text = "보통";
                    label.ForeColor = Color.Green;
                    break;

                case AirGrade.Bad:
                    label.Text = "나쁨";
                    label.ForeColor = Color.Goldenrod;
                    break;

                case AirGrade.VeryBad:
                    label.Text = "매우나쁨";
                    label.ForeColor = Color.Red;
                    break;
            }

            pictureBox.Image = GetGradeImage(grade);
        }

        public void UpdateAverage(DataAverage avg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateAverage(avg)));

                return;
            }

            SetValueVisible(true); // 최초 데이터 수신 시 표시

            lb_temp.Text = $"{avg.Temp.ToString("F1")} ℃";
            lb_hum.Text = $"{avg.Hum.ToString("F1")} %";
            lb_oxy.Text = $"{avg.O2.ToString("F1")} %";
            lb_co2.Text = $"{avg.CO2.ToString("F0")} ppm";
            lb_pm10.Text = $"{avg.PM10.ToString("F0")} μg/m³";
            lb_pm25.Text = $"{avg.PM25.ToString("F0")} μg/m³";

            var settings = SettingsData.Load().Alerts;

            ApplyGrade(lb_tem_grade, pb_tem_grade, GetGrade(avg.Temp, settings.Temperature));

            ApplyGrade(lb_hum_grade, pb_hum_grade, GetGrade(avg.Hum, settings.Humidity));

            ApplyGrade(lb_oxy_grade, pb_oxy_grade, GetGrade(avg.O2, settings.Oxygen));

            ApplyGrade(lb_co2_grade, pb_co2_grade, GetGrade(avg.CO2, settings.CO2));

            ApplyGrade(lb_pm10_grade, pb_pm10_grade, GetGrade(avg.PM10, settings.PM10));

            ApplyGrade(lb_pm25_grade, pb_pm25_grade, GetGrade(avg.PM25, settings.PM25));
        }

        private Image GetGradeImage(AirGrade grade)
        {
            switch (grade)
            {
                case AirGrade.Good:
                    return Properties.Resources.good;

                case AirGrade.Normal:
                    return Properties.Resources.normal;

                case AirGrade.Bad:
                    return Properties.Resources.bad;

                case AirGrade.VeryBad:
                    return Properties.Resources.verybad;

                default:
                    return null;
            }
        }

        private void SetValueVisible(bool visible)
        {
            // 값 Label
            lb_temp.Visible = visible;
            lb_hum.Visible = visible;
            lb_oxy.Visible = visible;
            lb_co2.Visible = visible;
            lb_pm10.Visible = visible;
            lb_pm25.Visible = visible;

            // 등급 Label
            lb_tem_grade.Visible = visible;
            lb_hum_grade.Visible = visible;
            lb_oxy_grade.Visible = visible;
            lb_co2_grade.Visible = visible;
            lb_pm10_grade.Visible = visible;
            lb_pm25_grade.Visible = visible;

            // 등급 이미지
            pb_tem_grade.Visible = visible;
            pb_hum_grade.Visible = visible;
            pb_oxy_grade.Visible = visible;
            pb_co2_grade.Visible = visible;
            pb_pm10_grade.Visible = visible;
            pb_pm25_grade.Visible = visible;
        }
    }
}
