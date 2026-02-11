using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_EX
{
    public partial class Main : Form
    {
        #region 프로그램 버전
        // 초기 서버 프로그램 생성 - v1.0.0   // 2026-01-06

        // 프로그램 버전관리 추가
        //string m_Title = "Server Program Version 1.0.1";    // 2026-01-06

        // 메인폼의 리스트뷰 속성 설정(로그문구 제대로 안나와서)
        //string m_Title = "Server Program Version 1.0.1.1";    // 2026-01-06

        // 로그출력 디자인폼 수정 (listView에서 listBox로 수정)
        // 로그폴더 및 파일 생성 후 출력 및 저장 추가
        //string m_Title = "Server Program Version 1.0.2";    // 2026-01-06

        // IP주소 및 Port번호가 비어있는 상태에서 연결시도 시 경고문구 로그 및 메시지박스 출력 추가
        //string m_Title = "Server Program Version 1.0.3";    // 2026-01-06

        // 전송버튼 눌렀을 때 서버실행여부에 따른 경고문구코드 위치수정 (메인폼에서 출력되게) (서버드라이브 --> 메인폼)
        // 메시지창 비어있는 상태에서 전송 시 경고문구 로그 및 메시지박스 출력 추가
        //string m_Title = "Server Program Version 1.0.4";    // 2026-01-07

        // 서버실행 후 클라이언트 접속여부에 따른 경고문구 출력 추가
        //string m_Title = "Server Program Version 1.0.5";    // 2026-01-07

        // 클라이언트 접속여부에 따라 버튼문구 및 색상변경 추가
        // 서버2 전송버튼 내 server1 -> server2로 수정
        // LogFile클래스 생성자의 접근제한자를 public에서 private으로 수정
        //string m_Title = "Server Program Version 1.0.6";    // 2026-01-07

        // 체크박스1,2 추가
        // Config.INI 파일 추가
        //string m_Title = "Server Program Version 1.0.7";    // 2026-01-12

        // FormClosing 이벤트속성 추가
        // 프로그램 실행종료 코드수정
        //string m_Title = "Server Program Version 1.0.8";    // 2026-01-13

        // Main 내 코드 순서 재배치
        //string m_Title = "Server Program Version 1.0.9";    // 2026-01-16

        // 현재 서버 연결상태에 따라 텍스트박스 디자인 변경으로 수정
        //string m_Title = "Server Program Version 1.0.10";   // 2026-01-19

        // 서버 연결 된 상태에서 프로그램 종료 시 예외발생 수정
        //string m_Title = "Server Program Version 1.0.11";   // 2026-01-19

        // Main폼 디자인 수정
        //string m_Title = "Server Program Version 1.0.12";   // 2026-01-19

        // 체크박스 체크여부에 따른 활성/비활성화 추가
        // 연결여부에 따른 TextBox 활성/비활성화 추가
        //string m_Title = "Server Program Version 1.0.13";   // 2026-01-23

        // Server1, Server2 송신 시 Enter Key로도 송신되도록 추가
        //string m_Title = "Server Program Version 1.0.14";    // 2026-01-26

        // Con1, Con2버튼 내 IP/Port 추출코드 수정
        // 프로그램 시작 시 Start 문구출력 추가
        //string m_Title = "Server Program Version 1.0.15";   // 2026-01-28

        // Con1버튼 내 port추출 코드 수정
        #endregion

        string m_Title = "Server Program Version 1.0.16";   // 2026-01-29

        private ServerDrive server1 = new ServerDrive();

        private int cb1;

        private string m_sCurrentFilePath;

        public Main()
        {
            InitializeComponent();

            server1.OnLog += MessageDisplay;
            server1.OnClientCountChanged += (count) => UpdateButtonText(btn_con1, server1);

            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;

            tb_msg1.KeyDown += Tb_msg1_KeyDown;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = m_Title;

            LogFile.GetInstance().InitFolder();

            // Config 설정 Load
            Config_Load();
            CB_Load();

            UpdateButtonText(btn_con1, server1);

            UpdateServer1Controls();

            MessageDisplay("Server Program Start");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            server1.Disconnect();

            // Config 설정 Save
            CB_Save();
            Config_Save();

            LogFile.GetInstance().CloseLog();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServer1Controls();
        }

        private void UpdateServer1Controls() // 체크여부, 연결여부에 따른 활성화/비활성화
        {
            bool isChecked = checkBox1.Checked;
            bool isConnected = server1.IsRunning;

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

        private void Tb_msg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_send1_Click(sender, e);
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

        private void UpdateButtonText(Button btn, ServerDrive server) // 연결상태에 따른 버튼Text문구 변경
        {
            if (this.InvokeRequired)
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                {
                    return;
                }

                try
                {
                    this.Invoke(new Action(() => UpdateButtonText(btn, server)));
                }
                catch (ObjectDisposedException)
                {
                    return;
                }

                return;
            }

            if (this.IsDisposed || !this.IsHandleCreated)
            {
                return;
            }

            if (!server.IsRunning)
            {
                btn.Text = "CONNECT";
                btn.BackColor = Color.LightPink;
                lb_color.ForeColor = Color.Red;

            }
            else
            {
                btn.Text = (server.ConnectedClientCount == 0) ? "Waiting..." : "DISCONNECT";
                btn.BackColor = (server.ConnectedClientCount == 0) ? Color.LightYellow : Color.LightGreen;
                lb_color.ForeColor = (server.ConnectedClientCount == 0) ? Color.Red : Color.Blue;
            }

            if (btn == btn_con1)
            {
                UpdateServer1Controls();
            }
        }

        private void btn_con1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (!server1.IsRunning)
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

                    server1.Connect(ip, port);
                }
                else
                {
                    server1.Disconnect();
                }

                UpdateButtonText(btn_con1, server1);
            }
            else
            {
                MessageDisplay("서버1 체크를 확인해주세요.");
                MessageBox.Show(this, "서버1 체크를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_send1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (!server1.IsRunning)
                {
                    MessageDisplay("서버 연결을 확인해주세요.");
                    MessageBox.Show(this, "서버 연결을 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                if (server1.ConnectedClientCount == 0)
                {
                    MessageDisplay("클라이언트가 접속되지 않았습니다.");
                    MessageBox.Show(this, "클라이언트가 접속되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                if (string.IsNullOrWhiteSpace(tb_msg1.Text))
                {
                    MessageDisplay("메시지를 입력해주세요.");
                    MessageBox.Show(this, "메시지를 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                server1.SendMessage(tb_msg1.Text);
                tb_msg1.Clear();
            }
            else
            {
                MessageDisplay("서버1 체크를 확인해주세요.");
                MessageBox.Show(this, "서버1 체크를 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listBox_log.Items.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Config_Save() // 체크박스 체크여부, IP, Port Save
        {
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            m_sCurrentFilePath = fi.Directory.FullName.ToString();
            string sIniFileName = m_sCurrentFilePath + "\\CONFIG.INI";
            IniFile ini = new IniFile(sIniFileName);

            ini.IniWriteValue("CheckBox1", "Enable", cb1.ToString());

            ini.IniWriteValue("Server1", "IP1", tb_ip1.Text);
            ini.IniWriteValue("Server1", "PORT1", tb_port1.Text);
        }

        private void Config_Load() // 체크박스 체크여부, IP, Port Load
        {
            FileInfo fi = new FileInfo(Application.ExecutablePath);
            m_sCurrentFilePath = fi.Directory.FullName.ToString();
            string sIniFileName = m_sCurrentFilePath + "\\CONFIG.INI";
            IniFile ini = new IniFile(sIniFileName);

            cb1 = ini.IniReadValue_Safe("CheckBox1", "Enable", 0);

            tb_ip1.Text = ini.IniReadValue_Safe("Server1", "IP1", "");
            tb_port1.Text = ini.IniReadValue_Safe("Server1", "PORT1", "");
        }
    }
}
