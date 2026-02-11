using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_EX
{
    public partial class Main : Form
    {
        #region 프로그램 버전
        // 초기 클라이언트 프로그램 생성(디자인폼 구성) - v1.0.0   // 2026-01-22

        // 프로그램 버전관리 추가
        //string m_Title = "Client Program Version 1.0.1";    // 2026-01-22

        // 클라이언트 프로그램 초안 구성 (클라이언트 드라이브 + 서버와 연결까지)
        //string m_Title = "Client Program Version 1.0.2";    // 2026-01-26

        // 클라이언트 드라이브 클래스의 Host를 IP로 수정
        //string m_Title = "Client Program Version 1.0.3";    // 2026-01-28

        // 로그폴더 및 파일 생성 후 출력 및 저장 추가
        //string m_Title = "Client Program Version 1.0.4";    // 2026-01-28

        // IP주소 및 Port번호가 비어있는 상태에서 연결시도 시 경고문구 로그 및 메시지박스 출력 추가
        // 메시지창 비어있는 상태에서 전송 시 경고문구 로그 및 메시지박스 출력 추가
        //string m_Title = "Client Program Version 1.0.5";    // 2026-01-29

        // ClientDrive 이벤트 구분 및 드라이브 내 코드 수정
        //string m_Title = "Client Program Version 1.0.6";    // 2026-01-29

        // ClientDrive의 s_Log -> c_Log 로 함수명 수정
        //string m_Title = "Client Program Version 1.0.6.1";  // 2026-01-29

        // 체크박스1,2 추가
        // Config.INI 파일(설정파일) 추가
        //string m_Title = "Client Program Version 1.0.7";    // 2026-01-30
        #endregion

        // 체크여부에 따른 CheckBox 활성/비활성화 추가
        // 연결여부에 따른 TextBox 활성/비활성화 추가
        string m_Title = "Client Program Version 1.0.8";    // 2026-02-02

        private ClientDrive client1 = new ClientDrive();

        private int cb1;

        private string m_sCurrentFilePath;

        public Main()
        {
            InitializeComponent();

            client1.OnStatusChanged += Client1_OnStatusChanged;
            client1.OnMessageReceived += Client1_OnMessageReceived;
            client1.OnLog += (msg) => MessageDisplay($"[Client1] {msg}");

            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

            tb_msg1.KeyDown += Tb_msg1_KeyDown;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = m_Title;

            LogFile.GetInstance().InitFolder();

            Config_Load();
            CB_Load();

            Client1_OnStatusChanged(client1.IsConnected ? ConnectionStatus.Connected : ConnectionStatus.Disconnected);

            UpdateClient1Controls();

            MessageDisplay("Client Program Start");
        }

        private void btn_con1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (!client1.IsConnected)
                {
                    if (string.IsNullOrWhiteSpace(tb_ip1.Text))
                    {
                        MessageDisplay("IP주소를 입력해주세요.");
                        MessageBox.Show(this, "IP주소를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    if (string.IsNullOrWhiteSpace(tb_port1.Text))
                    {
                        MessageDisplay("Port번호를 입력해주세요.");
                        MessageBox.Show(this, "Port번호를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return;
                    }

                    string ip = tb_ip1.Text.Trim();
                    int port = int.Parse(tb_port1.Text.Trim());

                    client1.Connect(ip, port);
                }
                else
                {
                    client1.Disconnect();
                }
            }
            else
            {
                MessageDisplay("클라이언트1 체크를 확인해주세요.");
                MessageBox.Show(this, "클라이언트1 체크를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btn_send1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (client1.IsConnected)
                {
                    string msg = tb_msg1.Text;

                    if (!string.IsNullOrEmpty(msg))
                    {
                        client1.SendMessage(msg);
                        MessageDisplay($"송신: {msg}");
                        tb_msg1.Clear();
                    }
                    else
                    {
                        MessageDisplay("메시지를 입력해주세요.");
                        MessageBox.Show(this, "메시지를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageDisplay("클라이언트1 체크를 확인해주세요.");
                MessageBox.Show(this, "클라이언트1 체크를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void Tb_msg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_send1_Click(sender, e);
            }
        }

        private void Client1_OnStatusChanged(ConnectionStatus status)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Client1_OnStatusChanged(status)));

                return;
            }

            switch (status)
            {
                case ConnectionStatus.Connecting:
                    btn_con1.Text = "CONNECTING...";
                    tb_ip1.Enabled = true;
                    tb_port1.Enabled = true;
                    btn_con1.Enabled = true;
                    btn_con1.BackColor = Color.LightYellow;
                    lb_color.ForeColor = Color.Red;
                    tb_msg1.Enabled = false;
                    btn_send1.Enabled = false;
                    break;

                case ConnectionStatus.Connected:
                    btn_con1.Text = "DISCONNECT";
                    tb_ip1.Enabled = false;
                    tb_port1.Enabled = false;
                    btn_con1.Enabled = true;
                    btn_con1.BackColor = Color.LightGreen;
                    lb_color.ForeColor = Color.Blue;
                    tb_msg1.Enabled = true;
                    btn_send1.Enabled = true;
                    break;

                case ConnectionStatus.Disconnecting:
                    btn_con1.Text = "DISCONNECTING...";
                    tb_ip1.Enabled = false;
                    tb_port1.Enabled = false;
                    btn_con1.Enabled = true;
                    btn_con1.BackColor = Color.LightYellow;
                    lb_color.ForeColor = Color.Blue;
                    tb_msg1.Enabled = true;
                    btn_send1.Enabled = true;
                    break;

                case ConnectionStatus.Disconnected:
                    btn_con1.Text = "CONNECT";
                    tb_ip1.Enabled = true;
                    tb_port1.Enabled = true;
                    btn_con1.Enabled = true;
                    btn_con1.BackColor = Color.LightPink;
                    lb_color.ForeColor = Color.Red;
                    tb_msg1.Enabled = false;
                    btn_send1.Enabled = false;
                    break;
                case ConnectionStatus.Error:
                    btn_con1.Text = "CONNECT";
                    tb_ip1.Enabled = true;
                    tb_port1.Enabled = true;
                    btn_con1.Enabled = true;
                    btn_con1.BackColor = Color.LightPink;
                    lb_color.ForeColor = Color.Red;
                    tb_msg1.Enabled = false;
                    btn_send1.Enabled = false;
                    break;
            }

            UpdateClient1Controls();
        }

        private void Client1_OnMessageReceived(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Client1_OnMessageReceived(msg)));

                return;
            }

            MessageDisplay($"수신: {msg}");
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClient1Controls();
        }

        private void UpdateClient1Controls()
        {
            bool isChecked = checkBox1.Checked;
            bool isConnected = client1.IsConnected;

            btn_con1.Enabled = isChecked;
            btn_send1.Enabled = isChecked;

            if (isChecked)
            {
                if (isConnected)
                {
                    tb_ip1.Enabled = false;
                    tb_port1.Enabled = false;
                    tb_msg1.Enabled = true;
                }
                else
                {
                    tb_ip1.Enabled = true;
                    tb_port1.Enabled = true;
                    tb_msg1.Enabled = false;
                }
            }
            else
            {
                tb_ip1.Enabled = false;
                tb_port1.Enabled = false;
                tb_msg1.Enabled = false;
            }
        }

        public void MessageDisplay(string sMsg)
        {
            this.Invoke(new Action(delegate ()
            {
                listBox_log.BeginUpdate();
                if (listBox_log.Items.Count > 2000)
                {
                    listBox_log.Items.Clear();
                }
                
                listBox_log.Items.Add(sMsg);
                listBox_log.SelectedIndex = listBox_log.Items.Count - 1;
                listBox_log.EndUpdate();
            }));

            LogFile.GetInstance().WriteLog(sMsg);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listBox_log.Items.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (client1.IsConnected)
                {
                    client1.Disconnect();
                }
                
                CB_Save();
                Config_Save();

                LogFile.GetInstance().CloseLog();
            }
            catch { }

            base.OnFormClosing(e);
        }

        private void CB_Save()
        {
            if (checkBox1.Checked == true)
            {
                cb1 = 1;
            }
            else
            {
                cb1 = 0;
            }
        }

        private void CB_Load()
        {
            if (cb1 == 1)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        private void Config_Save()
        {
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            m_sCurrentFilePath = fi.Directory.FullName.ToString();
            string sIniFileName = m_sCurrentFilePath + "\\CONFIG.INI";
            IniFile ini = new IniFile(sIniFileName);

            ini.IniWriteValue("CheckBox1", "Enable", cb1.ToString());

            ini.IniWriteValue("Client1", "IP1", tb_ip1.Text);
            ini.IniWriteValue("Client1", "PORT1", tb_port1.Text);
        }

        private void Config_Load()
        {
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            m_sCurrentFilePath = fi.Directory.FullName.ToString();
            string sIniFileName = m_sCurrentFilePath + "\\CONFIG.INI";
            IniFile ini = new IniFile(sIniFileName);

            cb1 = ini.IniReadValue_Safe("CheckBox1", "Enable", 0);

            tb_ip1.Text = ini.IniReadValue_Safe("Client1", "IP1", "");
            tb_port1.Text = ini.IniReadValue_Safe("Client1", "PORT1", "");
        }
    }
}
