namespace lab2
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
            this.pbFeed = new System.Windows.Forms.PictureBox();
            this.cbxWebcams = new System.Windows.Forms.ComboBox();
            this.lblWebcam = new System.Windows.Forms.Label();
            this.btnSaveSnapshot = new System.Windows.Forms.Button();
            this.rbNormalMode = new System.Windows.Forms.RadioButton();
            this.rbThresolding = new System.Windows.Forms.RadioButton();
            this.rbGrayscale = new System.Windows.Forms.RadioButton();
            this.rbConvolution = new System.Windows.Forms.RadioButton();
            this.rbRedChannel = new System.Windows.Forms.RadioButton();
            this.rbGreenChannel = new System.Windows.Forms.RadioButton();
            this.rbBlueChannel = new System.Windows.Forms.RadioButton();
            this.btnStartRecording = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chbBoostSaturation = new System.Windows.Forms.CheckBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAttachAudio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFeed
            // 
            this.pbFeed.Location = new System.Drawing.Point(9, 9);
            this.pbFeed.Margin = new System.Windows.Forms.Padding(0);
            this.pbFeed.Name = "pbFeed";
            this.pbFeed.Size = new System.Drawing.Size(960, 500);
            this.pbFeed.TabIndex = 0;
            this.pbFeed.TabStop = false;
            // 
            // cbxWebcams
            // 
            this.cbxWebcams.FormattingEnabled = true;
            this.cbxWebcams.Location = new System.Drawing.Point(972, 29);
            this.cbxWebcams.MaximumSize = new System.Drawing.Size(256, 0);
            this.cbxWebcams.Name = "cbxWebcams";
            this.cbxWebcams.Size = new System.Drawing.Size(185, 24);
            this.cbxWebcams.TabIndex = 1;
            // 
            // lblWebcam
            // 
            this.lblWebcam.AutoSize = true;
            this.lblWebcam.Location = new System.Drawing.Point(972, 9);
            this.lblWebcam.Name = "lblWebcam";
            this.lblWebcam.Size = new System.Drawing.Size(67, 17);
            this.lblWebcam.TabIndex = 2;
            this.lblWebcam.Text = "Webcam:";
            // 
            // btnSaveSnapshot
            // 
            this.btnSaveSnapshot.Location = new System.Drawing.Point(975, 265);
            this.btnSaveSnapshot.Name = "btnSaveSnapshot";
            this.btnSaveSnapshot.Size = new System.Drawing.Size(182, 32);
            this.btnSaveSnapshot.TabIndex = 3;
            this.btnSaveSnapshot.Text = "Take snapshot";
            this.btnSaveSnapshot.UseVisualStyleBackColor = true;
            // 
            // rbNormalMode
            // 
            this.rbNormalMode.AutoSize = true;
            this.rbNormalMode.Location = new System.Drawing.Point(975, 76);
            this.rbNormalMode.Name = "rbNormalMode";
            this.rbNormalMode.Size = new System.Drawing.Size(113, 21);
            this.rbNormalMode.TabIndex = 4;
            this.rbNormalMode.TabStop = true;
            this.rbNormalMode.Text = "Normal mode";
            this.rbNormalMode.UseVisualStyleBackColor = true;
            // 
            // rbThresolding
            // 
            this.rbThresolding.AutoSize = true;
            this.rbThresolding.Location = new System.Drawing.Point(975, 103);
            this.rbThresolding.Name = "rbThresolding";
            this.rbThresolding.Size = new System.Drawing.Size(104, 21);
            this.rbThresolding.TabIndex = 5;
            this.rbThresolding.TabStop = true;
            this.rbThresolding.Text = "Thresolding";
            this.rbThresolding.UseVisualStyleBackColor = true;
            // 
            // rbGrayscale
            // 
            this.rbGrayscale.AutoSize = true;
            this.rbGrayscale.Location = new System.Drawing.Point(975, 130);
            this.rbGrayscale.Name = "rbGrayscale";
            this.rbGrayscale.Size = new System.Drawing.Size(93, 21);
            this.rbGrayscale.TabIndex = 6;
            this.rbGrayscale.TabStop = true;
            this.rbGrayscale.Text = "Grayscale";
            this.rbGrayscale.UseVisualStyleBackColor = true;
            // 
            // rbConvolution
            // 
            this.rbConvolution.AutoSize = true;
            this.rbConvolution.Location = new System.Drawing.Point(975, 157);
            this.rbConvolution.Name = "rbConvolution";
            this.rbConvolution.Size = new System.Drawing.Size(124, 21);
            this.rbConvolution.TabIndex = 7;
            this.rbConvolution.TabStop = true;
            this.rbConvolution.Text = "Edge detection";
            this.rbConvolution.UseVisualStyleBackColor = true;
            // 
            // rbRedChannel
            // 
            this.rbRedChannel.AutoSize = true;
            this.rbRedChannel.Location = new System.Drawing.Point(975, 184);
            this.rbRedChannel.Name = "rbRedChannel";
            this.rbRedChannel.Size = new System.Drawing.Size(109, 21);
            this.rbRedChannel.TabIndex = 8;
            this.rbRedChannel.TabStop = true;
            this.rbRedChannel.Text = "Red channel";
            this.rbRedChannel.UseVisualStyleBackColor = true;
            // 
            // rbGreenChannel
            // 
            this.rbGreenChannel.AutoSize = true;
            this.rbGreenChannel.Location = new System.Drawing.Point(975, 211);
            this.rbGreenChannel.Name = "rbGreenChannel";
            this.rbGreenChannel.Size = new System.Drawing.Size(123, 21);
            this.rbGreenChannel.TabIndex = 9;
            this.rbGreenChannel.TabStop = true;
            this.rbGreenChannel.Text = "Green channel";
            this.rbGreenChannel.UseVisualStyleBackColor = true;
            // 
            // rbBlueChannel
            // 
            this.rbBlueChannel.AutoSize = true;
            this.rbBlueChannel.Location = new System.Drawing.Point(975, 238);
            this.rbBlueChannel.Name = "rbBlueChannel";
            this.rbBlueChannel.Size = new System.Drawing.Size(111, 21);
            this.rbBlueChannel.TabIndex = 10;
            this.rbBlueChannel.TabStop = true;
            this.rbBlueChannel.Text = "Blue channel";
            this.rbBlueChannel.UseVisualStyleBackColor = true;
            // 
            // btnStartRecording
            // 
            this.btnStartRecording.Location = new System.Drawing.Point(975, 477);
            this.btnStartRecording.Name = "btnStartRecording";
            this.btnStartRecording.Size = new System.Drawing.Size(90, 32);
            this.btnStartRecording.TabIndex = 11;
            this.btnStartRecording.Text = "Start";
            this.btnStartRecording.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(972, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Photo:";
            // 
            // chbBoostSaturation
            // 
            this.chbBoostSaturation.AutoSize = true;
            this.chbBoostSaturation.Location = new System.Drawing.Point(975, 409);
            this.chbBoostSaturation.Name = "chbBoostSaturation";
            this.chbBoostSaturation.Size = new System.Drawing.Size(133, 21);
            this.chbBoostSaturation.TabIndex = 17;
            this.chbBoostSaturation.Text = "Boost saturation";
            this.chbBoostSaturation.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(1067, 477);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(90, 32);
            this.btnPause.TabIndex = 18;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(972, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Video:";
            // 
            // btnAttachAudio
            // 
            this.btnAttachAudio.Location = new System.Drawing.Point(975, 439);
            this.btnAttachAudio.Name = "btnAttachAudio";
            this.btnAttachAudio.Size = new System.Drawing.Size(182, 32);
            this.btnAttachAudio.TabIndex = 20;
            this.btnAttachAudio.Text = "Attach audio";
            this.btnAttachAudio.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 516);
            this.Controls.Add(this.btnAttachAudio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.chbBoostSaturation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartRecording);
            this.Controls.Add(this.rbBlueChannel);
            this.Controls.Add(this.rbGreenChannel);
            this.Controls.Add(this.rbRedChannel);
            this.Controls.Add(this.rbConvolution);
            this.Controls.Add(this.rbGrayscale);
            this.Controls.Add(this.rbThresolding);
            this.Controls.Add(this.rbNormalMode);
            this.Controls.Add(this.btnSaveSnapshot);
            this.Controls.Add(this.lblWebcam);
            this.Controls.Add(this.cbxWebcams);
            this.Controls.Add(this.pbFeed);
            this.Name = "MainForm";
            this.Text = "Video recorder";
            ((System.ComponentModel.ISupportInitialize)(this.pbFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFeed;
        private System.Windows.Forms.ComboBox cbxWebcams;
        private System.Windows.Forms.Label lblWebcam;
        private System.Windows.Forms.Button btnSaveSnapshot;
        private System.Windows.Forms.RadioButton rbNormalMode;
        private System.Windows.Forms.RadioButton rbThresolding;
        private System.Windows.Forms.RadioButton rbGrayscale;
        private System.Windows.Forms.RadioButton rbConvolution;
        private System.Windows.Forms.RadioButton rbRedChannel;
        private System.Windows.Forms.RadioButton rbGreenChannel;
        private System.Windows.Forms.RadioButton rbBlueChannel;
        private System.Windows.Forms.Button btnStartRecording;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbBoostSaturation;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAttachAudio;
    }
}

