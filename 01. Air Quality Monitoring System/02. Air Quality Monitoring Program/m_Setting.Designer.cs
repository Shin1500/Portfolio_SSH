namespace Air_Quality_Monitoring
{
    partial class m_Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_network = new System.Windows.Forms.Button();
            this.btn_alert = new System.Windows.Forms.Button();
            this.m_panel = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_network
            // 
            this.btn_network.Location = new System.Drawing.Point(25, 22);
            this.btn_network.Name = "btn_network";
            this.btn_network.Size = new System.Drawing.Size(75, 30);
            this.btn_network.TabIndex = 0;
            this.btn_network.Text = "통신";
            this.btn_network.UseVisualStyleBackColor = true;
            this.btn_network.Click += new System.EventHandler(this.btn_network_Click);
            // 
            // btn_alert
            // 
            this.btn_alert.Location = new System.Drawing.Point(106, 22);
            this.btn_alert.Name = "btn_alert";
            this.btn_alert.Size = new System.Drawing.Size(75, 30);
            this.btn_alert.TabIndex = 1;
            this.btn_alert.Text = "임계값";
            this.btn_alert.UseVisualStyleBackColor = true;
            this.btn_alert.Click += new System.EventHandler(this.btn_alert_Click);
            // 
            // m_panel
            // 
            this.m_panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panel.Location = new System.Drawing.Point(25, 58);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(863, 505);
            this.m_panel.TabIndex = 4;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_save.Location = new System.Drawing.Point(130, 569);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(200, 44);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_close.Location = new System.Drawing.Point(566, 569);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(200, 44);
            this.btn_close.TabIndex = 6;
            this.btn_close.Text = "CLOSE";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // m_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 625);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.m_panel);
            this.Controls.Add(this.btn_alert);
            this.Controls.Add(this.btn_network);
            this.Name = "m_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "m_Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_network;
        private System.Windows.Forms.Button btn_alert;
        private System.Windows.Forms.Panel m_panel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_close;
    }
}