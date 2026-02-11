namespace Air_Quality_Monitoring
{
    partial class UC_Socket
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pn_network = new System.Windows.Forms.Panel();
            this.lb_network = new System.Windows.Forms.Label();
            this.lb_ip = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.tb_ip = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.pn_network.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_network
            // 
            this.pn_network.Controls.Add(this.tb_port);
            this.pn_network.Controls.Add(this.tb_ip);
            this.pn_network.Controls.Add(this.lb_port);
            this.pn_network.Controls.Add(this.lb_ip);
            this.pn_network.Controls.Add(this.lb_network);
            this.pn_network.Location = new System.Drawing.Point(16, 16);
            this.pn_network.Name = "pn_network";
            this.pn_network.Size = new System.Drawing.Size(264, 245);
            this.pn_network.TabIndex = 0;
            // 
            // lb_network
            // 
            this.lb_network.AutoSize = true;
            this.lb_network.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_network.Location = new System.Drawing.Point(70, 51);
            this.lb_network.Name = "lb_network";
            this.lb_network.Size = new System.Drawing.Size(133, 25);
            this.lb_network.TabIndex = 0;
            this.lb_network.Text = "네트워크 설정";
            // 
            // lb_ip
            // 
            this.lb_ip.AutoSize = true;
            this.lb_ip.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_ip.Location = new System.Drawing.Point(67, 119);
            this.lb_ip.Name = "lb_ip";
            this.lb_ip.Size = new System.Drawing.Size(24, 15);
            this.lb_ip.TabIndex = 1;
            this.lb_ip.Text = "IP :";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_port.Location = new System.Drawing.Point(45, 168);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(43, 15);
            this.lb_port.TabIndex = 2;
            this.lb_port.Text = "PORT :";
            // 
            // tb_ip
            // 
            this.tb_ip.Location = new System.Drawing.Point(97, 115);
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.Size = new System.Drawing.Size(100, 21);
            this.tb_ip.TabIndex = 3;
            this.tb_ip.Text = "192.168.0.130";
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(97, 163);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(64, 21);
            this.tb_port.TabIndex = 4;
            this.tb_port.Text = "6000";
            // 
            // UC_Socket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_network);
            this.Name = "UC_Socket";
            this.Size = new System.Drawing.Size(308, 283);
            this.pn_network.ResumeLayout(false);
            this.pn_network.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_network;
        private System.Windows.Forms.Label lb_network;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_ip;
        private System.Windows.Forms.TextBox tb_ip;
        private System.Windows.Forms.TextBox tb_port;
    }
}
