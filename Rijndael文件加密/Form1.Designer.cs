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
            this.memoryrelease = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            this.DecryptBut.Location = new System.Drawing.Point(164, 12);
            this.DecryptBut.Name = "DecryptBut";
            this.DecryptBut.Size = new System.Drawing.Size(75, 23);
            this.DecryptBut.TabIndex = 1;
            this.DecryptBut.Text = "解密";
            this.DecryptBut.UseVisualStyleBackColor = true;
            this.DecryptBut.Click += new System.EventHandler(this.DecryptBut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 103);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecryptBut);
            this.Controls.Add(this.EncryptBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "檔案加密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncryptBut;
        private System.Windows.Forms.Button DecryptBut;
        private System.Windows.Forms.Timer memoryrelease;
        private System.Windows.Forms.Label label1;
    }
}

