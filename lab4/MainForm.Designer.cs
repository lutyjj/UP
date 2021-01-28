
namespace lab3
{
    partial class MainForm
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
            this.cbxDevices = new System.Windows.Forms.ComboBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.btnPair = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblMac = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarSend = new System.Windows.Forms.ProgressBar();
            this.btnScan = new System.Windows.Forms.Button();
            this.lblAdapter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxDevices
            // 
            this.cbxDevices.FormattingEnabled = true;
            this.cbxDevices.Location = new System.Drawing.Point(15, 29);
            this.cbxDevices.Name = "cbxDevices";
            this.cbxDevices.Size = new System.Drawing.Size(223, 24);
            this.cbxDevices.TabIndex = 0;
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(12, 9);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(55, 17);
            this.lblDevices.TabIndex = 1;
            this.lblDevices.Text = "Device:";
            // 
            // btnPair
            // 
            this.btnPair.Location = new System.Drawing.Point(15, 59);
            this.btnPair.Name = "btnPair";
            this.btnPair.Size = new System.Drawing.Size(75, 23);
            this.btnPair.TabIndex = 2;
            this.btnPair.Text = "Pair";
            this.btnPair.UseVisualStyleBackColor = true;
            this.btnPair.Click += new System.EventHandler(this.btnPair_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(15, 88);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(96, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(112, 17);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: unknown";
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Location = new System.Drawing.Point(96, 91);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(101, 17);
            this.lblMac.TabIndex = 5;
            this.lblMac.Text = "MAC: unknown";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 134);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(425, 276);
            this.txtLog.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log:";
            // 
            // progressBarSend
            // 
            this.progressBarSend.Location = new System.Drawing.Point(15, 416);
            this.progressBarSend.Name = "progressBarSend";
            this.progressBarSend.Size = new System.Drawing.Size(425, 23);
            this.progressBarSend.TabIndex = 8;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(327, 28);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(113, 24);
            this.btnScan.TabIndex = 9;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lblAdapter
            // 
            this.lblAdapter.AutoSize = true;
            this.lblAdapter.Location = new System.Drawing.Point(237, 91);
            this.lblAdapter.Name = "lblAdapter";
            this.lblAdapter.Size = new System.Drawing.Size(46, 17);
            this.lblAdapter.TabIndex = 10;
            this.lblAdapter.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 450);
            this.Controls.Add(this.lblAdapter);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.progressBarSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblMac);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnPair);
            this.Controls.Add(this.lblDevices);
            this.Controls.Add(this.cbxDevices);
            this.Name = "MainForm";
            this.Text = "Bluetooth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDevices;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Button btnPair;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarSend;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblAdapter;
    }
}

