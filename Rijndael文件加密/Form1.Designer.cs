namespace Rijndael文件加密
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
            this.EncryptBut = new System.Windows.Forms.Button();
            this.DecryptBut = new System.Windows.Forms.Button();
            this.MemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.MemoryTimerLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label_DocSize = new System.Windows.Forms.Label();
            this.Monitor = new System.Windows.Forms.Timer(this.components);
            this.comboBox_EncDecFunction = new System.Windows.Forms.ComboBox();
            this.comboBox_Core = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DoubleEncDec = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // EncryptBut
            // 
            this.EncryptBut.Location = new System.Drawing.Point(12, 12);
            this.EncryptBut.Name = "EncryptBut";
            this.EncryptBut.Size = new System.Drawing.Size(75, 23);
            this.EncryptBut.TabIndex = 0;
            this.EncryptBut.Text = "加密";
            this.EncryptBut.UseVisualStyleBackColor = true;
            this.EncryptBut.Click += new System.EventHandler(this.EncryptBut_Click);
            // 
            // DecryptBut
            // 
            this.DecryptBut.Location = new System.Drawing.Point(12, 41);
            this.DecryptBut.Name = "DecryptBut";
            this.DecryptBut.Size = new System.Drawing.Size(75, 23);
            this.DecryptBut.TabIndex = 1;
            this.DecryptBut.Text = "解密";
            this.DecryptBut.UseVisualStyleBackColor = true;
            this.DecryptBut.Click += new System.EventHandler(this.DecryptBut_Click);
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
            // label_DocSize
            // 
            this.label_DocSize.AutoSize = true;
            this.label_DocSize.Location = new System.Drawing.Point(12, 147);
            this.label_DocSize.Name = "label_DocSize";
            this.label_DocSize.Size = new System.Drawing.Size(20, 12);
            this.label_DocSize.TabIndex = 5;
            this.label_DocSize.Text = "0/0";
            this.label_DocSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Monitor
            // 
            this.Monitor.Enabled = true;
            this.Monitor.Interval = 1;
            this.Monitor.Tick += new System.EventHandler(this.Monitor_Tick);
            // 
            // comboBox_EncDecFunction
            // 
            this.comboBox_EncDecFunction.FormattingEnabled = true;
            this.comboBox_EncDecFunction.Location = new System.Drawing.Point(248, 38);
            this.comboBox_EncDecFunction.Name = "comboBox_EncDecFunction";
            this.comboBox_EncDecFunction.Size = new System.Drawing.Size(149, 20);
            this.comboBox_EncDecFunction.TabIndex = 6;
            this.comboBox_EncDecFunction.SelectedIndexChanged += new System.EventHandler(this.comboBox_EncDecFunction_SelectedIndexChanged);
            // 
            // comboBox_Core
            // 
            this.comboBox_Core.FormattingEnabled = true;
            this.comboBox_Core.Location = new System.Drawing.Point(248, 12);
            this.comboBox_Core.Name = "comboBox_Core";
            this.comboBox_Core.Size = new System.Drawing.Size(149, 20);
            this.comboBox_Core.TabIndex = 7;
            this.comboBox_Core.SelectedIndexChanged += new System.EventHandler(this.comboBox_Core_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rijndael文件加密.Properties.Resources.question;
            this.pictureBox1.Location = new System.Drawing.Point(363, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 31);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 167);
            this.Controls.Add(this.DoubleEncDec);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox_Core);
            this.Controls.Add(this.comboBox_EncDecFunction);
            this.Controls.Add(this.label_DocSize);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.MemoryTimerLabel);
            this.Controls.Add(this.DecryptBut);
            this.Controls.Add(this.EncryptBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "檔案加密";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncryptBut;
        private System.Windows.Forms.Button DecryptBut;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.Label MemoryTimerLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label_DocSize;
        private System.Windows.Forms.Timer Monitor;
        private System.Windows.Forms.ComboBox comboBox_EncDecFunction;
        private System.Windows.Forms.ComboBox comboBox_Core;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox DoubleEncDec;
    }
}

