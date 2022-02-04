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
            this.DecryptBut.Location = new System.Drawing.Point(199, 12);
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
            this.MemoryTimerLabel.Location = new System.Drawing.Point(179, 109);
            this.MemoryTimerLabel.Name = "MemoryTimerLabel";
            this.MemoryTimerLabel.Size = new System.Drawing.Size(95, 12);
            this.MemoryTimerLabel.TabIndex = 2;
            this.MemoryTimerLabel.Text = "記憶體使用量：0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 70);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(262, 23);
            this.progressBar2.TabIndex = 4;
            // 
            // label_DocSize
            // 
            this.label_DocSize.AutoSize = true;
            this.label_DocSize.Location = new System.Drawing.Point(12, 109);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 130);
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
    }
}

