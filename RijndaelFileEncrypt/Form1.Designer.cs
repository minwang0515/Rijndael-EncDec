namespace RijndaelFileEncrypt
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.But_Encrypt = new System.Windows.Forms.Button();
            this.But_Decrypt = new System.Windows.Forms.Button();
            this.MemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.MemoryTimerLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.Label_DocSize = new System.Windows.Forms.Label();
            this.comboBox_EncDecFunction = new System.Windows.Forms.ComboBox();
            this.comboBox_Core = new System.Windows.Forms.ComboBox();
            this.PictureBox_Help = new System.Windows.Forms.PictureBox();
            this.DoubleEncDec = new System.Windows.Forms.CheckBox();
            this.Monitor = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Help)).BeginInit();
            this.SuspendLayout();
            // 
            // But_Encrypt
            // 
            this.But_Encrypt.Location = new System.Drawing.Point(12, 12);
            this.But_Encrypt.Name = "But_Encrypt";
            this.But_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.But_Encrypt.TabIndex = 0;
            this.But_Encrypt.Text = "加密";
            this.But_Encrypt.UseVisualStyleBackColor = true;
            this.But_Encrypt.Click += new System.EventHandler(this.EncryptBut_Click);
            // 
            // But_Decrypt
            // 
            this.But_Decrypt.Location = new System.Drawing.Point(12, 41);
            this.But_Decrypt.Name = "But_Decrypt";
            this.But_Decrypt.Size = new System.Drawing.Size(75, 23);
            this.But_Decrypt.TabIndex = 1;
            this.But_Decrypt.Text = "解密";
            this.But_Decrypt.UseVisualStyleBackColor = true;
            this.But_Decrypt.Click += new System.EventHandler(this.DecryptBut_Click);
            // 
            // MemoryTimer
            // 
            this.MemoryTimer.Enabled = true;
            this.MemoryTimer.Interval = 1000;
            this.MemoryTimer.Tick += new System.EventHandler(this.memoryrelease_Tick);
            // 
            // MemoryTimerLabel
            // 
            this.MemoryTimerLabel.AutoSize = true;
            this.MemoryTimerLabel.Location = new System.Drawing.Point(262, 147);
            this.MemoryTimerLabel.Name = "MemoryTimerLabel";
            this.MemoryTimerLabel.Size = new System.Drawing.Size(95, 12);
            this.MemoryTimerLabel.TabIndex = 2;
            this.MemoryTimerLabel.Text = "記憶體使用量：0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 70);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(385, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 99);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(385, 23);
            this.progressBar2.TabIndex = 4;
            // 
            // Label_DocSize
            // 
            this.Label_DocSize.AutoSize = true;
            this.Label_DocSize.Location = new System.Drawing.Point(12, 147);
            this.Label_DocSize.Name = "Label_DocSize";
            this.Label_DocSize.Size = new System.Drawing.Size(66, 12);
            this.Label_DocSize.TabIndex = 5;
            this.Label_DocSize.Text = "0 byte/0 byte";
            this.Label_DocSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_EncDecFunction
            // 
            this.comboBox_EncDecFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EncDecFunction.FormattingEnabled = true;
            this.comboBox_EncDecFunction.Location = new System.Drawing.Point(248, 38);
            this.comboBox_EncDecFunction.Name = "comboBox_EncDecFunction";
            this.comboBox_EncDecFunction.Size = new System.Drawing.Size(149, 20);
            this.comboBox_EncDecFunction.TabIndex = 6;
            this.comboBox_EncDecFunction.SelectedIndexChanged += new System.EventHandler(this.comboBox_EncDecFunction_SelectedIndexChanged);
            // 
            // comboBox_Core
            // 
            this.comboBox_Core.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Core.FormattingEnabled = true;
            this.comboBox_Core.Location = new System.Drawing.Point(248, 12);
            this.comboBox_Core.Name = "comboBox_Core";
            this.comboBox_Core.Size = new System.Drawing.Size(149, 20);
            this.comboBox_Core.TabIndex = 7;
            this.comboBox_Core.SelectedIndexChanged += new System.EventHandler(this.comboBox_Core_SelectedIndexChanged);
            // 
            // PictureBox_Help
            // 
            this.PictureBox_Help.Image = global::RijndaelFileEncrypt.Properties.Resources.question;
            this.PictureBox_Help.Location = new System.Drawing.Point(363, 128);
            this.PictureBox_Help.Name = "PictureBox_Help";
            this.PictureBox_Help.Size = new System.Drawing.Size(34, 31);
            this.PictureBox_Help.TabIndex = 8;
            this.PictureBox_Help.TabStop = false;
            this.PictureBox_Help.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DoubleEncDec
            // 
            this.DoubleEncDec.AutoSize = true;
            this.DoubleEncDec.Checked = true;
            this.DoubleEncDec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DoubleEncDec.Location = new System.Drawing.Point(94, 47);
            this.DoubleEncDec.Name = "DoubleEncDec";
            this.DoubleEncDec.Size = new System.Drawing.Size(72, 16);
            this.DoubleEncDec.TabIndex = 9;
            this.DoubleEncDec.Text = "雙重加密";
            this.DoubleEncDec.UseVisualStyleBackColor = true;
            // 
            // Monitor
            // 
            this.Monitor.Enabled = true;
            this.Monitor.Interval = 1;
            this.Monitor.Tick += new System.EventHandler(this.Monitor_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 167);
            this.Controls.Add(this.DoubleEncDec);
            this.Controls.Add(this.PictureBox_Help);
            this.Controls.Add(this.comboBox_Core);
            this.Controls.Add(this.comboBox_EncDecFunction);
            this.Controls.Add(this.Label_DocSize);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.MemoryTimerLabel);
            this.Controls.Add(this.But_Decrypt);
            this.Controls.Add(this.But_Encrypt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "檔案加密";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button But_Encrypt;
        private System.Windows.Forms.Button But_Decrypt;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.Label MemoryTimerLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label Label_DocSize;
        private System.Windows.Forms.ComboBox comboBox_EncDecFunction;
        private System.Windows.Forms.ComboBox comboBox_Core;
        private System.Windows.Forms.PictureBox PictureBox_Help;
        private System.Windows.Forms.CheckBox DoubleEncDec;
        private System.Windows.Forms.Timer Monitor;
    }
}

