namespace Air_Quality_Monitoring
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lb_text = new System.Windows.Forms.ToolStripLabel();
            this.lb_con_image = new System.Windows.Forms.ToolStripLabel();
            this.btn_Connect = new System.Windows.Forms.ToolStripButton();
            this.btn_Start = new System.Windows.Forms.ToolStripButton();
            this.btn_Refresh = new System.Windows.Forms.ToolStripButton();
            this.btn_Setting = new System.Windows.Forms.ToolStripButton();
            this.btn_Exit = new System.Windows.Forms.ToolStripButton();
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_datetime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_updateTime = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_text,
            this.lb_con_image,
            this.btn_Connect,
            this.btn_Start,
            this.btn_Refresh,
            this.btn_Setting,
            this.btn_Exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(848, 41);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lb_text
            // 
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(59, 38);
            this.lb_text.Text = "연결 상태";
            // 
            // lb_con_image
            // 
            this.lb_con_image.AutoSize = false;
            this.lb_con_image.AutoToolTip = true;
            this.lb_con_image.Image = global::Air_Quality_Monitoring.Properties.Resources.Disconnect;
            this.lb_con_image.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lb_con_image.Name = "lb_con_image";
            this.lb_con_image.Size = new System.Drawing.Size(35, 38);
            // 
            // btn_Connect
            // 
            this.btn_Connect.AutoSize = false;
            this.btn_Connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Connect.Image = global::Air_Quality_Monitoring.Properties.Resources.Connect;
            this.btn_Connect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 38);
            this.btn_Connect.Text = "CONNECT";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.AutoSize = false;
            this.btn_Start.Image = global::Air_Quality_Monitoring.Properties.Resources.Start;
            this.btn_Start.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(100, 38);
            this.btn_Start.Text = "START";
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.AutoSize = false;
            this.btn_Refresh.Image = global::Air_Quality_Monitoring.Properties.Resources.Refresh;
            this.btn_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(100, 38);
            this.btn_Refresh.Text = "REFRESH";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Setting
            // 
            this.btn_Setting.AutoSize = false;
            this.btn_Setting.Image = global::Air_Quality_Monitoring.Properties.Resources.Setting;
            this.btn_Setting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Setting.Name = "btn_Setting";
            this.btn_Setting.Size = new System.Drawing.Size(100, 38);
            this.btn_Setting.Text = "SETTING";
            this.btn_Setting.Click += new System.EventHandler(this.btn_Setting_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.AutoSize = false;
            this.btn_Exit.Image = global::Air_Quality_Monitoring.Properties.Resources.Exit;
            this.btn_Exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 38);
            this.btn_Exit.Text = "EXIT";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // listBox_log
            // 
            this.listBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.ItemHeight = 12;
            this.listBox_log.Location = new System.Drawing.Point(558, 451);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new System.Drawing.Size(278, 112);
            this.listBox_log.TabIndex = 1;
            this.listBox_log.Visible = false;
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.Location = new System.Drawing.Point(761, 569);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Visible = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "수신 테스트용";
            this.label1.Visible = false;
            // 
            // lb_datetime
            // 
            this.lb_datetime.AutoSize = true;
            this.lb_datetime.Location = new System.Drawing.Point(26, 72);
            this.lb_datetime.Name = "lb_datetime";
            this.lb_datetime.Size = new System.Drawing.Size(57, 12);
            this.lb_datetime.TabIndex = 4;
            this.lb_datetime.Text = "현재 시간";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(28, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 510);
            this.panel1.TabIndex = 5;
            // 
            // lb_updateTime
            // 
            this.lb_updateTime.AutoSize = true;
            this.lb_updateTime.Location = new System.Drawing.Point(219, 599);
            this.lb_updateTime.Name = "lb_updateTime";
            this.lb_updateTime.Size = new System.Drawing.Size(81, 12);
            this.lb_updateTime.TabIndex = 6;
            this.lb_updateTime.Text = "업데이트 시간";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 623);
            this.Controls.Add(this.lb_updateTime);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_datetime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.listBox_log);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air Quality Monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_Setting;
        private System.Windows.Forms.ToolStripButton btn_Connect;
        private System.Windows.Forms.ToolStripButton btn_Start;
        private System.Windows.Forms.ToolStripButton btn_Refresh;
        private System.Windows.Forms.ToolStripButton btn_Exit;
        private System.Windows.Forms.ToolStripLabel lb_con_image;
        private System.Windows.Forms.ToolStripLabel lb_text;
        private System.Windows.Forms.ListBox listBox_log;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_datetime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_updateTime;
    }
}

