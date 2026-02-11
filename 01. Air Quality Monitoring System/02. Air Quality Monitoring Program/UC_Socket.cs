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
    public partial class UC_Socket : UserControl
    {
        // 네트워크 설정 폼

        public UC_Socket()
        {
            InitializeComponent();

            UI_Color();
        }

        private void UI_Color()
        {
            pn_network.BackColor = Color.White;
            pn_network.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pn_network);

            lb_network.ForeColor = Color.FromArgb(74, 144, 226);

            lb_ip.ForeColor = Color.FromArgb(80, 80, 80);
            lb_port.ForeColor = lb_ip.ForeColor;
        }

        public string ServerIP => tb_ip.Text;

        public int ServerPort
        {
            get
            {
                int port;

                return int.TryParse(tb_port.Text, out port) ? port : 0;
            }
        }

        public void LoadSettings(SettingsData data)
        {
            tb_ip.Text = data.ServerIP;
            tb_port.Text = data.ServerPort.ToString();
        }
    }
}
