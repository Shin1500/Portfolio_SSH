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

namespace Air_Quality_Monitoring
{
    public partial class Main : Form
    {
        #region 프로그램 버전
        //string m_Title = "Air Quality Monitoring Program Version 1.0.0"; // 초기버전
        //string m_Title = "Air Quality Monitoring Program Version 1.0.1"; // 로그파일 생성 및 저장 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.2"; // 프로그램 종료확인 문구창 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.2.1"; // 프로그램 종료확인 문구창 수정 (Exit버튼 -> FormClosing)
        //string m_Title = "Air Quality Monitoring Program Version 1.0.3"; // 클라이언트 클래스 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.4"; // 설정 창 UI구성
        //string m_Title = "Air Quality Monitoring Program Version 1.0.4.1"; // 설정 창 띄우기 + 설정 창에서 close 기능 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.4.2"; // 통신설정 UI구성
        //string m_Title = "Air Quality Monitoring Program Version 1.0.4.2.1"; // 통신설정 기능구현(통신연결)
        //string m_Title = "Air Quality Monitoring Program Version 1.0.4.2.2"; // 통신연결-해제 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.5"; // 메인폼에 데이터수신 테스트용 리스트박스 및 Clear버튼 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.6"; // 서버로부터 더미데이터 수신 후 평균값 csv파일로 저장
        //string m_Title = "Air Quality Monitoring Program Version 1.0.7"; // 메인화면 UI구성
        //string m_Title = "Air Quality Monitoring Program Version 1.0.7.1"; // 메인UI라벨문구 수정
        //string m_Title = "Air Quality Monitoring Program Version 1.0.7.2"; // 메인폼에 업데이트시간 라벨추가+IndexGrade 폼에 등급라벨 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.8"; // 임계값 설정 UI구성 및 설정 기능구현
        //string m_Title = "Air Quality Monitoring Program Version 1.0.9"; // 메인폼 UI에 값 표현
        //string m_Title = "Air Quality Monitoring Program Version 1.0.9.1"; // 지수등급에 따른 라벨 텍스트 및 색상변경
        //string m_Title = "Air Quality Monitoring Program Version 1.0.10"; // 서버연결 끊어질 시 메시지박스 출력
        //string m_Title = "Air Quality Monitoring Program Version 1.0.11"; // 메인폼에 업데이트 시간 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.11.1"; // 메인폼에 지수등급 아이콘 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.11.2"; // 첫데이터 표현 뒤 1분마다 갱신으로 수정
        //string m_Title = "Air Quality Monitoring Program Version 1.0.11.3"; // UI라벨 위치수정 및 invisible 처리추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.11.3"; // IndexGrade 폼 크기 수정
        //string m_Title = "Air Quality Monitoring Program Version 1.0.12"; // 새로고침 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.13"; // csv파일관련 수정
        //string m_Title = "Air Quality Monitoring Program Version 1.0.14"; // 초기 json파일 생성 추가
        //string m_Title = "Air Quality Monitoring Program Version 1.0.15"; // 서버연결 후 Start 중 서버 끊어졌을 때 Stop에서 Start로 라벨문구 변경
        //string m_Title = "Air Quality Monitoring Program Version 1.0.16"; // 폼 사이즈 동적(반응형)으로 수정
        #endregion

        string m_Title = "Air Quality Monitoring Program Version 1.0.17";

        public Main()
        {
            InitializeComponent();

            client.OnStatusChanged += UpdateConnectionStatus;

            client.OnMessageReceived += HandleServerMessage;

            indexgrade = new IndexGrade();
            indexgrade.Dock = DockStyle.Fill;

            this.KeyPreview = true;
            this.KeyDown += Main_KeyDown;

            panel1.Controls.Add(indexgrade);
        }

        private SettingsData setting;
        private void Main_Load(object sender, EventArgs e)
        {
            setting = SettingsData.Load();

            UpdateDateTime();

            this.Text = m_Title;

            LogFile.GetInstance().InitFolder();

            MessageDisplay("Program Open");
        }

        private bool isRunning = false;

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

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel == true)
            {
                return;
            }

            Exit_question exitQuestion = new Exit_question();

            DialogResult dlg = exitQuestion.ShowDialog();

            if (dlg == DialogResult.Yes)
            {
                MessageDisplay("Program Exit");

                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                bool isVisible = listBox_log.Visible;

                label1.Visible = !isVisible;
                listBox_log.Visible = !isVisible;
                btn_clear.Visible = !isVisible;
            }
        }
        
        private void btn_Setting_Click(object sender, EventArgs e)
        {
            m_Setting settingForm = new m_Setting(setting);

            settingForm.ShowDialog();
        }

        private Client client = new Client();
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                client.Disconnect();
            }
            else
            {
                if (string.IsNullOrEmpty(setting.ServerIP) || setting.ServerPort == 0)
                {
                    MessageBox.Show("IP 또는 Port 설정이 잘못되었습니다.");

                    return;
                }

                client.Connect(setting.ServerIP, setting.ServerPort);
            }
        }

        private void UpdateConnectionStatus(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateConnectionStatus(msg)));
                return;
            }

            MessageDisplay(msg);

            if (msg.Contains("연결 실패"))
            {
                MessageBox.Show(this, msg, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            if (client.IsConnected)
            {
                btn_Connect.Text = "DISCONNECT";
                btn_Connect.ForeColor = Color.Blue;
                lb_con_image.Image = Properties.Resources.Connect;
            }
            else
            {
                btn_Connect.Text = "CONNECT";
                btn_Connect.ForeColor = Color.Red;
                lb_con_image.Image = Properties.Resources.Disconnect;

                if (isRunning)
                {
                    StopStartSwap();
                }

                if (msg == "서버 연결 종료")
                {
                    MessageBox.Show(this, "서버 연결이 종료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listBox_log.Items.Clear();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (!client.IsConnected)
            {
                MessageBox.Show("서버에 연결되어 있지 않습니다.");

                return;
            }

            if (!isRunning)
            {
                isRunning = true;

                DataDisplayed = false;
                buffer.Clear();
                lastSaveTime = DateTime.Now;

                btn_Start.Text = "STOP";
                btn_Start.Image = Properties.Resources.Stop;

                client.SendMessage("KICK");
                MessageDisplay("[송신] KICK");
            }
            else
            {
                isRunning = false;
                btn_Start.Text = "START";
                btn_Start.Image = Properties.Resources.Start;

                client.SendMessage("STOP");
                MessageDisplay("[송신] STOP");
            }
        }

        private void HandleServerMessage(string msg)
        {
            MessageDisplay($"[수신] {msg}");

            if (msg == "ACK")
            {
                client.SendMessage("Get_Data");
                MessageDisplay("[송신] Get_Data");
            }
            else if (msg == "STOP_ACK")
            {
                MessageDisplay("서버 데이터 송신 중지 확인");
            }
            else if (msg.StartsWith("DATA") && isRunning)
            {
                ProcessSensorData(msg);
            }
        }

        class SensorData
        {
            public DateTime Time;
            public double Temp, Hum, O2, CO2, PM10, PM25;
        }

        List<SensorData> buffer = new List<SensorData>();
        DateTime lastSaveTime = DateTime.Now;

        private void ProcessSensorData(string msg)
        {
            var sp = msg.Split(',');

            var data = new SensorData
            {
                Time = DateTime.Now,
                Temp = double.Parse(sp[2]),
                Hum = double.Parse(sp[3]),
                O2 = double.Parse(sp[4]),
                CO2 = double.Parse(sp[5]),
                PM10 = double.Parse(sp[6]),
                PM25 = double.Parse(sp[7])
            };

            buffer.Add(data);

            if (!DataDisplayed)
            {
                var instant = new DataAverage
                {
                    Temp = data.Temp,
                    Hum = data.Hum,
                    O2 = data.O2,
                    CO2 = data.CO2,
                    PM10 = data.PM10,
                    PM25 = data.PM25
                };

                indexgrade.UpdateAverage(instant);
                UpdateLastUpdateTime(DateTime.Now);

                DataDisplayed = true;
                lastDisplayedTime = DateTime.Now;
                lastSaveTime = DateTime.Now;

                return;
            }

            if ((DateTime.Now - lastSaveTime).TotalMinutes >= 1)
            {
                SaveAverage();
                buffer.Clear();
                lastSaveTime = DateTime.Now;
            }
        }

        private void SaveAverage()
        {
            if (buffer.Count == 0)
            {
                return;
            }

            var avg = new DataAverage
            {
                Temp = buffer.Average(x => x.Temp),
                Hum = buffer.Average(x => x.Hum),
                O2 = buffer.Average(x => x.O2),
                CO2 = buffer.Average(x => x.CO2),
                PM10 = buffer.Average(x => x.PM10),
                PM25 = buffer.Average(x => x.PM25)
            };

            DateTime updateTime = DateTime.Now;

            indexgrade.UpdateAverage(avg);

            UpdateLastUpdateTime(updateTime);

            lastDisplayedTime = updateTime;

            string dataDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data");

            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            string path = Path.Combine(dataDir,$"Data_{DateTime.Now:yyyyMMdd}.csv");

            bool newFile = !File.Exists(path);

            using (var sw = new StreamWriter(path, true))
            {
                if (newFile)
                {
                    sw.WriteLine("Time,Temp,Hum,O2,CO2,PM10,PM2.5");
                }

                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},{avg.Temp:F1},{avg.Hum:F1},{avg.O2:F1},{avg.CO2:F0},{avg.PM10:F0},{avg.PM25:F0}");
            }

            MessageDisplay("1분 평균 데이터 CSV 저장 완료");
        }

        private void UpdateDateTime()
        {
            lb_datetime.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private IndexGrade indexgrade;

        private void UpdateLastUpdateTime(DateTime time)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateLastUpdateTime(time)));
                return;
            }

            lb_updateTime.Text = $"{time:yyyy-MM-dd HH:mm} 업데이트";
        }

        private bool DataDisplayed = false;

        private DateTime lastDisplayedTime = DateTime.MinValue;

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                MessageBox.Show("데이터 수신 중이 아닙니다.");

                return;
            }

            var refreshData = buffer.Where(x => x.Time > lastDisplayedTime).ToList();

            if (refreshData.Count == 0)
            {
                MessageDisplay("새로 평균낼 데이터가 없습니다.");

                return;
            }

            var avg = new DataAverage
            {
                Temp = refreshData.Average(x => x.Temp),
                Hum = refreshData.Average(x => x.Hum),
                O2 = refreshData.Average(x => x.O2),
                CO2 = refreshData.Average(x => x.CO2),
                PM10 = refreshData.Average(x => x.PM10),
                PM25 = refreshData.Average(x => x.PM25)
            };

            DateTime refreshTime = DateTime.Now;

            indexgrade.UpdateAverage(avg);
            UpdateLastUpdateTime(refreshTime);

            lastDisplayedTime = refreshTime;

            MessageDisplay("REFRESH 평균값 UI 반영 완료");
        }

        private void StopStartSwap()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(StopStartSwap));

                return;
            }

            isRunning = false;

            btn_Start.Text = "START";
            btn_Start.Image = Properties.Resources.Start;

            MessageDisplay("서버 연결 끊김으로 데이터 수신 중지");
        }
    }
}
