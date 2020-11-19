namespace lab1
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
            this.stopRecordingBtn = new System.Windows.Forms.Button();
            this.startRecordingBtn = new System.Windows.Forms.Button();
            this.inputCbx = new System.Windows.Forms.ComboBox();
            this.inputLabel = new System.Windows.Forms.Label();
            this.startPlayingBtn = new System.Windows.Forms.Button();
            this.stopPlayingBtn = new System.Windows.Forms.Button();
            this.startMixBtn = new System.Windows.Forms.Button();
            this.stopMixBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stopRecordingBtn
            // 
            this.stopRecordingBtn.Location = new System.Drawing.Point(184, 58);
            this.stopRecordingBtn.Name = "stopRecordingBtn";
            this.stopRecordingBtn.Size = new System.Drawing.Size(166, 35);
            this.stopRecordingBtn.TabIndex = 1;
            this.stopRecordingBtn.Text = "Stop recording";
            this.stopRecordingBtn.UseVisualStyleBackColor = true;
            // 
            // startRecordingBtn
            // 
            this.startRecordingBtn.Location = new System.Drawing.Point(12, 59);
            this.startRecordingBtn.Name = "startRecordingBtn";
            this.startRecordingBtn.Size = new System.Drawing.Size(166, 34);
            this.startRecordingBtn.TabIndex = 2;
            this.startRecordingBtn.Text = "Record audio";
            this.startRecordingBtn.UseVisualStyleBackColor = true;
            // 
            // inputCbx
            // 
            this.inputCbx.FormattingEnabled = true;
            this.inputCbx.Location = new System.Drawing.Point(12, 29);
            this.inputCbx.Name = "inputCbx";
            this.inputCbx.Size = new System.Drawing.Size(338, 24);
            this.inputCbx.TabIndex = 4;
            // 
            // inputLabel
            // 
            this.inputLabel.AutoSize = true;
            this.inputLabel.Location = new System.Drawing.Point(9, 9);
            this.inputLabel.Name = "inputLabel";
            this.inputLabel.Size = new System.Drawing.Size(88, 17);
            this.inputLabel.TabIndex = 5;
            this.inputLabel.Text = "Input device:";
            // 
            // startPlayingBtn
            // 
            this.startPlayingBtn.Location = new System.Drawing.Point(12, 99);
            this.startPlayingBtn.Name = "startPlayingBtn";
            this.startPlayingBtn.Size = new System.Drawing.Size(166, 34);
            this.startPlayingBtn.TabIndex = 6;
            this.startPlayingBtn.Text = "Play audio";
            this.startPlayingBtn.UseVisualStyleBackColor = true;
            // 
            // stopPlayingBtn
            // 
            this.stopPlayingBtn.Location = new System.Drawing.Point(184, 99);
            this.stopPlayingBtn.Name = "stopPlayingBtn";
            this.stopPlayingBtn.Size = new System.Drawing.Size(166, 34);
            this.stopPlayingBtn.TabIndex = 7;
            this.stopPlayingBtn.Text = "Stop audio";
            this.stopPlayingBtn.UseVisualStyleBackColor = true;
            // 
            // startMixBtn
            // 
            this.startMixBtn.Location = new System.Drawing.Point(12, 139);
            this.startMixBtn.Name = "startMixBtn";
            this.startMixBtn.Size = new System.Drawing.Size(166, 35);
            this.startMixBtn.TabIndex = 8;
            this.startMixBtn.Text = "Play mix";
            this.startMixBtn.UseVisualStyleBackColor = true;
            // 
            // stopMixBtn
            // 
            this.stopMixBtn.Location = new System.Drawing.Point(184, 139);
            this.stopMixBtn.Name = "stopMixBtn";
            this.stopMixBtn.Size = new System.Drawing.Size(166, 35);
            this.stopMixBtn.TabIndex = 9;
            this.stopMixBtn.Text = "Stop mix";
            this.stopMixBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 186);
            this.Controls.Add(this.stopMixBtn);
            this.Controls.Add(this.startMixBtn);
            this.Controls.Add(this.stopPlayingBtn);
            this.Controls.Add(this.startPlayingBtn);
            this.Controls.Add(this.inputLabel);
            this.Controls.Add(this.inputCbx);
            this.Controls.Add(this.startRecordingBtn);
            this.Controls.Add(this.stopRecordingBtn);
            this.Name = "MainForm";
            this.Text = "Audio recording";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stopRecordingBtn;
        private System.Windows.Forms.Button startRecordingBtn;
        private System.Windows.Forms.ComboBox inputCbx;
        private System.Windows.Forms.Label inputLabel;
        private System.Windows.Forms.Button startPlayingBtn;
        private System.Windows.Forms.Button stopPlayingBtn;
        private System.Windows.Forms.Button startMixBtn;
        private System.Windows.Forms.Button stopMixBtn;
    }
}

