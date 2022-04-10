
namespace BidBot
{
    partial class frmSettings
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
            this.txtURLtoRoster = new System.Windows.Forms.TextBox();
            this.lblURLtoRoster = new System.Windows.Forms.Label();
            this.lblPathToLog = new System.Windows.Forms.Label();
            this.txtPathToEQLog = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathToRoster = new System.Windows.Forms.TextBox();
            this.chbPaySecondBid = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtURLtoRoster
            // 
            this.txtURLtoRoster.Location = new System.Drawing.Point(12, 44);
            this.txtURLtoRoster.Name = "txtURLtoRoster";
            this.txtURLtoRoster.Size = new System.Drawing.Size(272, 23);
            this.txtURLtoRoster.TabIndex = 0;
            // 
            // lblURLtoRoster
            // 
            this.lblURLtoRoster.AutoSize = true;
            this.lblURLtoRoster.Location = new System.Drawing.Point(10, 22);
            this.lblURLtoRoster.Name = "lblURLtoRoster";
            this.lblURLtoRoster.Size = new System.Drawing.Size(78, 15);
            this.lblURLtoRoster.TabIndex = 1;
            this.lblURLtoRoster.Text = "URL to Roster";
            // 
            // lblPathToLog
            // 
            this.lblPathToLog.AutoSize = true;
            this.lblPathToLog.Location = new System.Drawing.Point(10, 128);
            this.lblPathToLog.Name = "lblPathToLog";
            this.lblPathToLog.Size = new System.Drawing.Size(86, 15);
            this.lblPathToLog.TabIndex = 3;
            this.lblPathToLog.Text = "Path to EQ Log";
            // 
            // txtPathToEQLog
            // 
            this.txtPathToEQLog.Location = new System.Drawing.Point(12, 150);
            this.txtPathToEQLog.Name = "txtPathToEQLog";
            this.txtPathToEQLog.Size = new System.Drawing.Size(272, 23);
            this.txtPathToEQLog.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(385, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(304, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Path to Roster";
            // 
            // txtPathToRoster
            // 
            this.txtPathToRoster.Location = new System.Drawing.Point(12, 97);
            this.txtPathToRoster.Name = "txtPathToRoster";
            this.txtPathToRoster.Size = new System.Drawing.Size(272, 23);
            this.txtPathToRoster.TabIndex = 6;
            // 
            // chbPaySecondBid
            // 
            this.chbPaySecondBid.AutoSize = true;
            this.chbPaySecondBid.Location = new System.Drawing.Point(308, 47);
            this.chbPaySecondBid.Name = "chbPaySecondBid";
            this.chbPaySecondBid.Size = new System.Drawing.Size(136, 19);
            this.chbPaySecondBid.TabIndex = 8;
            this.chbPaySecondBid.Text = "Pay Second Bid Price";
            this.chbPaySecondBid.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 220);
            this.Controls.Add(this.chbPaySecondBid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathToRoster);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPathToLog);
            this.Controls.Add(this.txtPathToEQLog);
            this.Controls.Add(this.lblURLtoRoster);
            this.Controls.Add(this.txtURLtoRoster);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtURLtoRoster;
        private System.Windows.Forms.Label lblURLtoRoster;
        private System.Windows.Forms.Label lblPathToLog;
        private System.Windows.Forms.TextBox txtPathToEQLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathToRoster;
        private System.Windows.Forms.CheckBox chbPaySecondBid;
    }
}