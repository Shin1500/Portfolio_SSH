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
    public partial class m_Setting : Form
    {
        // 설정 폼

        private SettingsData settings;

        public m_Setting(SettingsData setting)
        {
            InitializeComponent();

            settings = setting;

            ShowControl(networkControl);

            networkControl.LoadSettings(settings);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private UC_Socket networkControl = new UC_Socket();
        private void btn_network_Click(object sender, EventArgs e)
        {
            m_panel.Controls.Clear();
            m_panel.Controls.Add(networkControl);
        }

        private void ShowControl(UserControl uc)
        {
            m_panel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            m_panel.Controls.Add(uc);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            settings.ServerIP = networkControl.ServerIP;
            settings.ServerPort = networkControl.ServerPort;

            settings.Alerts = AlertControl.GetSettings();

            settings.Save();
            MessageBox.Show("설정이 저장되었습니다.");
        }

        private UC_Alert AlertControl = new UC_Alert();

        private void btn_alert_Click(object sender, EventArgs e)
        {
            m_panel.Controls.Clear();
            m_panel.Controls.Add(AlertControl);

            var settings = SettingsData.Load();
            AlertControl.LoadSettings(settings.Alerts);
        }
    }
}
