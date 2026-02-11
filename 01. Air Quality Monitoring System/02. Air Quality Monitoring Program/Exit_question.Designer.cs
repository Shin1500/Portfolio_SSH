namespace Air_Quality_Monitoring
{
    partial class Exit_question
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exit_question));
            this.btn_no = new System.Windows.Forms.Button();
            this.btn_yes = new System.Windows.Forms.Button();
            this.lb_question = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_no
            // 
            this.btn_no.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_no.Location = new System.Drawing.Point(235, 109);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(217, 54);
            this.btn_no.TabIndex = 11;
            this.btn_no.Text = "No";
            this.btn_no.UseVisualStyleBackColor = true;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_yes
            // 
            this.btn_yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btn_yes.Location = new System.Drawing.Point(12, 109);
            this.btn_yes.Name = "btn_yes";
            this.btn_yes.Size = new System.Drawing.Size(217, 54);
            this.btn_yes.TabIndex = 10;
            this.btn_yes.Text = "Yes";
            this.btn_yes.UseVisualStyleBackColor = true;
            this.btn_yes.Click += new System.EventHandler(this.btn_yes_Click);
            // 
            // lb_question
            // 
            this.lb_question.AutoSize = true;
            this.lb_question.Font = new System.Drawing.Font("굴림", 25F);
            this.lb_question.Location = new System.Drawing.Point(24, 16);
            this.lb_question.Name = "lb_question";
            this.lb_question.Size = new System.Drawing.Size(447, 34);
            this.lb_question.TabIndex = 9;
            this.lb_question.Text = "Do you want Program Exit?";
            // 
            // Exit_question
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 180);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_yes);
            this.Controls.Add(this.lb_question);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Exit_question";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exit_question";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.Button btn_yes;
        private System.Windows.Forms.Label lb_question;
    }
}