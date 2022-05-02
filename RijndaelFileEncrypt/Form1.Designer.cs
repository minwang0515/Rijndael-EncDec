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
            this.Button_Encrypt = new System.Windows.Forms.Button();
            this.Button_Decrypt = new System.Windows.Forms.Button();
            this.MemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.Label_Memory = new System.Windows.Forms.Label();
            this.ProgressBar_Total = new System.Windows.Forms.ProgressBar();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Label_DocSize = new System.Windows.Forms.Label();
            this.comboBox_EncDecFunction = new System.Windows.Forms.ComboBox();
            this.comboBox_Core = new System.Windows.Forms.ComboBox();
            this.PictureBox_Help = new System.Windows.Forms.PictureBox();
            this.CheckBox_DoubleEncDec = new System.Windows.Forms.CheckBox();
            this.Monitor = new System.Windows.Forms.Timer(this.components);
            this.Label_Total = new System.Windows.Forms.Label();
            this.Label_ProgressBar = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Help)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Encrypt
            // 
            this.Button_Encrypt.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Encrypt.Location = new System.Drawing.Point(12, 12);
            this.Button_Encrypt.Name = "Button_Encrypt";
            this.Button_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.Button_Encrypt.TabIndex = 13;
            this.Button_Encrypt.Text = "加密";
            this.Button_Encrypt.UseVisualStyleBackColor = true;
            this.Button_Encrypt.Click += new System.EventHandler(this.EncryptBut_Click);
            // 
            // Button_Decrypt
            // 
            this.Button_Decrypt.BackColor = System.Drawing.SystemColors.Control;
            this.Button_Decrypt.Location = new System.Drawing.Point(12, 41);
            this.Button_Decrypt.Name = "Button_Decrypt";
            this.Button_Decrypt.Size = new System.Drawing.Size(75, 23);
            this.Button_Decrypt.TabIndex = 1;
            this.Button_Decrypt.Text = "解密";
            this.Button_Decrypt.UseVisualStyleBackColor = true;
            this.Button_Decrypt.Click += new System.EventHandler(this.DecryptBut_Click);
            // 
            // MemoryTimer
            // 
            this.MemoryTimer.Enabled = true;
            this.MemoryTimer.Interval = 500;
            this.MemoryTimer.Tick += new System.EventHandler(this.Memoryrelease_Tick);
            // 
            // Label_Memory
            // 
            this.Label_Memory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label_Memory.Location = new System.Drawing.Point(10, 138);
            this.Label_Memory.Name = "Label_Memory";
            this.Label_Memory.Size = new System.Drawing.Size(151, 59);
            this.Label_Memory.TabIndex = 11;
            this.Label_Memory.Text = "記憶體 讀取中...";
            // 
            // ProgressBar_Total
            // 
            this.ProgressBar_Total.Location = new System.Drawing.Point(11, 119);
            this.ProgressBar_Total.MarqueeAnimationSpeed = 1;
            this.ProgressBar_Total.Maximum = 10000;
            this.ProgressBar_Total.Name = "ProgressBar_Total";
            this.ProgressBar_Total.Size = new System.Drawing.Size(410, 16);
            this.ProgressBar_Total.TabIndex = 9;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 85);
            this.ProgressBar.MarqueeAnimationSpeed = 1;
            this.ProgressBar.Maximum = 10000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(410, 16);
            this.ProgressBar.TabIndex = 6;
            // 
            // Label_DocSize
            // 
            this.Label_DocSize.BackColor = System.Drawing.Color.Transparent;
            this.Label_DocSize.Location = new System.Drawing.Point(12, 138);
            this.Label_DocSize.Name = "Label_DocSize";
            this.Label_DocSize.Size = new System.Drawing.Size(411, 12);
            this.Label_DocSize.TabIndex = 12;
            this.Label_DocSize.Text = "0 byte / 0 byte";
            this.Label_DocSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_EncDecFunction
            // 
            this.comboBox_EncDecFunction.BackColor = System.Drawing.Color.White;
            this.comboBox_EncDecFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EncDecFunction.ForeColor = System.Drawing.Color.Black;
            this.comboBox_EncDecFunction.FormattingEnabled = true;
            this.comboBox_EncDecFunction.Location = new System.Drawing.Point(272, 38);
            this.comboBox_EncDecFunction.Name = "comboBox_EncDecFunction";
            this.comboBox_EncDecFunction.Size = new System.Drawing.Size(149, 20);
            this.comboBox_EncDecFunction.TabIndex = 3;
            this.comboBox_EncDecFunction.SelectedIndexChanged += new System.EventHandler(this.comboBox_EncDecFunction_SelectedIndexChanged);
            // 
            // comboBox_Core
            // 
            this.comboBox_Core.BackColor = System.Drawing.Color.White;
            this.comboBox_Core.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Core.ForeColor = System.Drawing.Color.Black;
            this.comboBox_Core.FormattingEnabled = true;
            this.comboBox_Core.Location = new System.Drawing.Point(272, 12);
            this.comboBox_Core.Name = "comboBox_Core";
            this.comboBox_Core.Size = new System.Drawing.Size(149, 20);
            this.comboBox_Core.TabIndex = 2;
            this.comboBox_Core.SelectedIndexChanged += new System.EventHandler(this.comboBox_Core_SelectedIndexChanged);
            // 
            // PictureBox_Help
            // 
            this.PictureBox_Help.Image = global::RijndaelFileEncrypt.Properties.Resources.question;
            this.PictureBox_Help.Location = new System.Drawing.Point(386, 168);
            this.PictureBox_Help.Name = "PictureBox_Help";
            this.PictureBox_Help.Size = new System.Drawing.Size(35, 36);
            this.PictureBox_Help.TabIndex = 8;
            this.PictureBox_Help.TabStop = false;
            this.PictureBox_Help.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CheckBox_DoubleEncDec
            // 
            this.CheckBox_DoubleEncDec.AutoSize = true;
            this.CheckBox_DoubleEncDec.Checked = true;
            this.CheckBox_DoubleEncDec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_DoubleEncDec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CheckBox_DoubleEncDec.Location = new System.Drawing.Point(349, 64);
            this.CheckBox_DoubleEncDec.Name = "CheckBox_DoubleEncDec";
            this.CheckBox_DoubleEncDec.Size = new System.Drawing.Size(72, 16);
            this.CheckBox_DoubleEncDec.TabIndex = 4;
            this.CheckBox_DoubleEncDec.Text = "雙重加密";
            this.CheckBox_DoubleEncDec.UseVisualStyleBackColor = true;
            // 
            // Monitor
            // 
            this.Monitor.Enabled = true;
            this.Monitor.Interval = 1;
            this.Monitor.Tick += new System.EventHandler(this.Monitor_Tick);
            // 
            // Label_Total
            // 
            this.Label_Total.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_Total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label_Total.Location = new System.Drawing.Point(373, 138);
            this.Label_Total.Name = "Label_Total";
            this.Label_Total.Size = new System.Drawing.Size(50, 12);
            this.Label_Total.TabIndex = 10;
            this.Label_Total.Text = "0.00%";
            this.Label_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label_ProgressBar
            // 
            this.Label_ProgressBar.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label_ProgressBar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label_ProgressBar.Location = new System.Drawing.Point(375, 104);
            this.Label_ProgressBar.Name = "Label_ProgressBar";
            this.Label_ProgressBar.Size = new System.Drawing.Size(50, 12);
            this.Label_ProgressBar.TabIndex = 7;
            this.Label_ProgressBar.Text = "0.00%";
            this.Label_ProgressBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label.Location = new System.Drawing.Point(338, 104);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(29, 12);
            this.Label.TabIndex = 5;
            this.Label.Text = "進度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(326, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "總進度";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(433, 206);
            this.Controls.Add(this.Label_ProgressBar);
            this.Controls.Add(this.Label_Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label_Memory);
            this.Controls.Add(this.Label_DocSize);
            this.Controls.Add(this.CheckBox_DoubleEncDec);
            this.Controls.Add(this.PictureBox_Help);
            this.Controls.Add(this.comboBox_Core);
            this.Controls.Add(this.comboBox_EncDecFunction);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ProgressBar_Total);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.Button_Decrypt);
            this.Controls.Add(this.Button_Encrypt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "檔案加解密工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Help)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Encrypt;
        private System.Windows.Forms.Button Button_Decrypt;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.Label Label_Memory;
        private System.Windows.Forms.ProgressBar ProgressBar_Total;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label Label_DocSize;
        private System.Windows.Forms.ComboBox comboBox_EncDecFunction;
        private System.Windows.Forms.ComboBox comboBox_Core;
        private System.Windows.Forms.PictureBox PictureBox_Help;
        private System.Windows.Forms.CheckBox CheckBox_DoubleEncDec;
        private System.Windows.Forms.Timer Monitor;
        private System.Windows.Forms.Label Label_Total;
        private System.Windows.Forms.Label Label_ProgressBar;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Label label1;
    }
}

