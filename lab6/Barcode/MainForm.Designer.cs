
namespace Barcode
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
            this.QRPb = new System.Windows.Forms.PictureBox();
            this.barcodePb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stringTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.encodeBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.decodedStringTextBox = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnSaveBarcode = new System.Windows.Forms.Button();
            this.btnSaveQR = new System.Windows.Forms.Button();
            this.btnSaveMultToPdf = new System.Windows.Forms.Button();
            this.btnSaveToPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QRPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePb)).BeginInit();
            this.SuspendLayout();
            // 
            // QRPb
            // 
            this.QRPb.Location = new System.Drawing.Point(403, 97);
            this.QRPb.Name = "QRPb";
            this.QRPb.Size = new System.Drawing.Size(320, 320);
            this.QRPb.TabIndex = 0;
            this.QRPb.TabStop = false;
            // 
            // barcodePb
            // 
            this.barcodePb.Location = new System.Drawing.Point(15, 97);
            this.barcodePb.Name = "barcodePb";
            this.barcodePb.Size = new System.Drawing.Size(320, 320);
            this.barcodePb.TabIndex = 1;
            this.barcodePb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barcode:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "QR:";
            // 
            // stringTextBox
            // 
            this.stringTextBox.Location = new System.Drawing.Point(15, 29);
            this.stringTextBox.Name = "stringTextBox";
            this.stringTextBox.Size = new System.Drawing.Size(242, 22);
            this.stringTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "String to encode:";
            // 
            // encodeBtn
            // 
            this.encodeBtn.Location = new System.Drawing.Point(263, 28);
            this.encodeBtn.Name = "encodeBtn";
            this.encodeBtn.Size = new System.Drawing.Size(72, 24);
            this.encodeBtn.TabIndex = 6;
            this.encodeBtn.Text = "Encode";
            this.encodeBtn.UseVisualStyleBackColor = true;
            this.encodeBtn.Click += new System.EventHandler(this.encodeBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Decoded string:";
            // 
            // decodedStringTextBox
            // 
            this.decodedStringTextBox.Enabled = false;
            this.decodedStringTextBox.Location = new System.Drawing.Point(403, 30);
            this.decodedStringTextBox.Name = "decodedStringTextBox";
            this.decodedStringTextBox.ReadOnly = true;
            this.decodedStringTextBox.Size = new System.Drawing.Size(242, 22);
            this.decodedStringTextBox.TabIndex = 8;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(651, 30);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(72, 24);
            this.btnDecode.TabIndex = 10;
            this.btnDecode.Text = "Decode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecodeBarcode_click);
            // 
            // btnSaveBarcode
            // 
            this.btnSaveBarcode.Location = new System.Drawing.Point(15, 425);
            this.btnSaveBarcode.Name = "btnSaveBarcode";
            this.btnSaveBarcode.Size = new System.Drawing.Size(150, 24);
            this.btnSaveBarcode.TabIndex = 11;
            this.btnSaveBarcode.Text = "Save Barcode";
            this.btnSaveBarcode.UseVisualStyleBackColor = true;
            this.btnSaveBarcode.Click += new System.EventHandler(this.btnSaveBarcode_click);
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.Location = new System.Drawing.Point(403, 425);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(150, 24);
            this.btnSaveQR.TabIndex = 12;
            this.btnSaveQR.Text = "Save QR";
            this.btnSaveQR.UseVisualStyleBackColor = true;
            this.btnSaveQR.Click += new System.EventHandler(this.btnSaveQR_Click);
            // 
            // btnSaveMultToPdf
            // 
            this.btnSaveMultToPdf.Location = new System.Drawing.Point(175, 455);
            this.btnSaveMultToPdf.Name = "btnSaveMultToPdf";
            this.btnSaveMultToPdf.Size = new System.Drawing.Size(160, 24);
            this.btnSaveMultToPdf.TabIndex = 13;
            this.btnSaveMultToPdf.Text = "Save multiple to PDF";
            this.btnSaveMultToPdf.UseVisualStyleBackColor = true;
            this.btnSaveMultToPdf.Click += new System.EventHandler(this.btnSaveMultToPdf_Click);
            // 
            // btnSaveToPdf
            // 
            this.btnSaveToPdf.Location = new System.Drawing.Point(175, 425);
            this.btnSaveToPdf.Name = "btnSaveToPdf";
            this.btnSaveToPdf.Size = new System.Drawing.Size(160, 24);
            this.btnSaveToPdf.TabIndex = 14;
            this.btnSaveToPdf.Text = "Save single to PDF";
            this.btnSaveToPdf.UseVisualStyleBackColor = true;
            this.btnSaveToPdf.Click += new System.EventHandler(this.btnSaveToPdf_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 490);
            this.Controls.Add(this.btnSaveToPdf);
            this.Controls.Add(this.btnSaveMultToPdf);
            this.Controls.Add(this.btnSaveQR);
            this.Controls.Add(this.btnSaveBarcode);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.decodedStringTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.encodeBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stringTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barcodePb);
            this.Controls.Add(this.QRPb);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.QRPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodePb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QRPb;
        private System.Windows.Forms.PictureBox barcodePb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stringTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button encodeBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox decodedStringTextBox;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnSaveBarcode;
        private System.Windows.Forms.Button btnSaveQR;
        private System.Windows.Forms.Button btnSaveMultToPdf;
        private System.Windows.Forms.Button btnSaveToPdf;
    }
}

