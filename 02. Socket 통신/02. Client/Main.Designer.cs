namespace Client_EX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lb_ip1 = new System.Windows.Forms.Label();
            this.lb_port1 = new System.Windows.Forms.Label();
            this.tb_ip1 = new System.Windows.Forms.TextBox();
            this.tb_port1 = new System.Windows.Forms.TextBox();
            this.tb_msg1 = new System.Windows.Forms.TextBox();
            this.btn_con1 = new System.Windows.Forms.Button();
            this.btn_send1 = new System.Windows.Forms.Button();
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.gb_client1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lb_ClientProgram = new System.Windows.Forms.Label();
            this.lb_msg = new System.Windows.Forms.Label();
            this.lb_color = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.gb_client1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_ip1
            // 
            this.lb_ip1.AutoSize = true;
            this.lb_ip1.Location = new System.Drawing.Point(4, 34);
            this.lb_ip1.Name = "lb_ip1";
            this.lb_ip1.Size = new System.Drawing.Size(24, 12);
            this.lb_ip1.TabIndex = 0;
            this.lb_ip1.Text = "IP :";
            // 
            // lb_port1
            // 
            this.lb_port1.AutoSize = true;
            this.lb_port1.Location = new System.Drawing.Point(4, 63);
            this.lb_port1.Name = "lb_port1";
            this.lb_port1.Size = new System.Drawing.Size(46, 12);
            this.lb_port1.TabIndex = 1;
            this.lb_port1.Text = "PORT :";
            // 
            // tb_ip1
            // 
            this.tb_ip1.Location = new System.Drawing.Point(78, 31);
            this.tb_ip1.Name = "tb_ip1";
            this.tb_ip1.Size = new System.Drawing.Size(100, 21);
            this.tb_ip1.TabIndex = 2;
            // 
            // tb_port1
            // 
            this.tb_port1.Location = new System.Drawing.Point(78, 60);
            this.tb_port1.Name = "tb_port1";
            this.tb_port1.Size = new System.Drawing.Size(67, 21);
            this.tb_port1.TabIndex = 3;
            // 
            // tb_msg1
            // 
            this.tb_msg1.Location = new System.Drawing.Point(76, 87);
            this.tb_msg1.Name = "tb_msg1";
            this.tb_msg1.Size = new System.Drawing.Size(173, 21);
            this.tb_msg1.TabIndex = 4;
            // 
            // btn_con1
            // 
            this.btn_con1.Location = new System.Drawing.Point(6, 131);
            this.btn_con1.Name = "btn_con1";
            this.btn_con1.Size = new System.Drawing.Size(111, 25);
            this.btn_con1.TabIndex = 5;
            this.btn_con1.Text = "CONNECT";
            this.btn_con1.UseVisualStyleBackColor = true;
            this.btn_con1.Click += new System.EventHandler(this.btn_con1_Click);
            // 
            // btn_send1
            // 
            this.btn_send1.Location = new System.Drawing.Point(144, 131);
            this.btn_send1.Name = "btn_send1";
            this.btn_send1.Size = new System.Drawing.Size(110, 25);
            this.btn_send1.TabIndex = 6;
            this.btn_send1.Text = "Send";
            this.btn_send1.UseVisualStyleBackColor = true;
            this.btn_send1.Click += new System.EventHandler(this.btn_send1_Click);
            // 
            // listBox_log
            // 
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.ItemHeight = 12;
            this.listBox_log.Location = new System.Drawing.Point(288, 55);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new System.Drawing.Size(262, 208);
            this.listBox_log.TabIndex = 14;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(475, 269);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 15;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(60, 301);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(427, 36);
            this.btn_close.TabIndex = 16;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // gb_client1
            // 
            this.gb_client1.Controls.Add(this.lb_color);
            this.gb_client1.Controls.Add(this.lb_status);
            this.gb_client1.Controls.Add(this.lb_msg);
            this.gb_client1.Controls.Add(this.checkBox1);
            this.gb_client1.Controls.Add(this.tb_port1);
            this.gb_client1.Controls.Add(this.lb_ip1);
            this.gb_client1.Controls.Add(this.lb_port1);
            this.gb_client1.Controls.Add(this.tb_ip1);
            this.gb_client1.Controls.Add(this.tb_msg1);
            this.gb_client1.Controls.Add(this.btn_con1);
            this.gb_client1.Controls.Add(this.btn_send1);
            this.gb_client1.Location = new System.Drawing.Point(21, 55);
            this.gb_client1.Name = "gb_client1";
            this.gb_client1.Size = new System.Drawing.Size(261, 211);
            this.gb_client1.TabIndex = 17;
            this.gb_client1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Client1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lb_ClientProgram
            // 
            this.lb_ClientProgram.AutoSize = true;
            this.lb_ClientProgram.Location = new System.Drawing.Point(19, 23);
            this.lb_ClientProgram.Name = "lb_ClientProgram";
            this.lb_ClientProgram.Size = new System.Drawing.Size(89, 12);
            this.lb_ClientProgram.TabIndex = 19;
            this.lb_ClientProgram.Text = "Client Program";
            // 
            // lb_msg
            // 
            this.lb_msg.AutoSize = true;
            this.lb_msg.Location = new System.Drawing.Point(4, 91);
            this.lb_msg.Name = "lb_msg";
            this.lb_msg.Size = new System.Drawing.Size(66, 12);
            this.lb_msg.TabIndex = 7;
            this.lb_msg.Text = "Message :";
            // 
            // lb_color
            // 
            this.lb_color.AutoSize = true;
            this.lb_color.Location = new System.Drawing.Point(74, 182);
            this.lb_color.Name = "lb_color";
            this.lb_color.Size = new System.Drawing.Size(17, 12);
            this.lb_color.TabIndex = 17;
            this.lb_color.Text = "●";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_status.Location = new System.Drawing.Point(12, 182);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(62, 13);
            this.lb_status.TabIndex = 16;
            this.lb_status.Text = "Status :";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 356);
            this.Controls.Add(this.lb_ClientProgram);
            this.Controls.Add(this.gb_client1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.listBox_log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.gb_client1.ResumeLayout(false);
            this.gb_client1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_ip1;
        private System.Windows.Forms.Label lb_port1;
        private System.Windows.Forms.TextBox tb_ip1;
        private System.Windows.Forms.TextBox tb_port1;
        private System.Windows.Forms.TextBox tb_msg1;
        private System.Windows.Forms.Button btn_con1;
        private System.Windows.Forms.Button btn_send1;
        private System.Windows.Forms.ListBox listBox_log;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.GroupBox gb_client1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lb_ClientProgram;
        private System.Windows.Forms.Label lb_msg;
        private System.Windows.Forms.Label lb_color;
        private System.Windows.Forms.Label lb_status;
    }
}

