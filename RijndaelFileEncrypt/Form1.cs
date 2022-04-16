﻿using RijndaelFileEncrypt.Function;
using RijndaelFileEncrypt.Models;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RijndaelFileEncrypt
{
    public partial class Form1 : Form
    {
        FormVariable m_Form = new FormVariable();
        public Form1()
        {
            InitializeComponent();
        }

        private async void EncryptBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog OldDoc = new OpenFileDialog();
            OldDoc.InitialDirectory = @".\";
            OldDoc.Filter = "加密 (*.*)|*.*";
            OldDoc.Title = "加密";
            OldDoc.RestoreDirectory = true;
            Thread thrStart = null;
            m_Form.DocSize = 0;
            m_Form.Unit = null;
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                progressBar1.Maximum = 100;
                progressBar2.Maximum = 200;
                m_Form.DocSize = fInfo.Length;
                FormVariable.FileSize = fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();

                FormVariable.DoubleEncDec = DoubleEncDec.Checked;

                await Task.Run(() =>
                {
                    FormVariable.OldDocStr = OldDoc.FileName;
                    FormVariable.NewDocStr = $@"{FormVariable.OldDocStr}{m_Form.EncDecFilenameExtension}";

                    Crypt Crypt = new Crypt();
                    thrStart = new Thread(Crypt.Encrypt);
                    thrStart.Start(); 
                });
            }
        }

        private async void DecryptBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog OldDoc = new OpenFileDialog();
            OldDoc.InitialDirectory = @".\";
            OldDoc.Filter = "解密 (*.*)|*.*";
            OldDoc.Title = "解密";
            OldDoc.RestoreDirectory = true;
            Thread thrStart = null;
            m_Form.DocSize = 0;
            m_Form.Unit = null;
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                progressBar1.Maximum = (int)fInfo.Length;
                progressBar2.Maximum = (int)fInfo.Length;
                m_Form.DocSize = fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();

                FormVariable.DoubleEncDec = DoubleEncDec.Checked;

                await Task.Run(() =>
                {
                    FormVariable.OldDocStr = OldDoc.FileName;
                    FormVariable.NewDocStr = $@"{FormVariable.OldDocStr.Replace(m_Form.EncDecFilenameExtension,"")}";

                    Crypt Crypt = new Crypt();
                    thrStart = new Thread(Crypt.Decrypt);
                    thrStart.Start();
                });
            }
        }

        public void Progress()
        {
            if (progressBar1.Maximum > FormVariable.Size)
            {
                Label_DocSize.Text = $@"{m_Form.Progress:.00} {m_Form.UnitDoc} / {m_Form.DocSize:.00} {m_Form.Unit}";
                progressBar1.Value = (int)FormVariable.Size;
            }
        }

        private void FormatBytes(long bytes)
        {
            string[] Suffix = { "byte", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                dblSByte = bytes / 1024.0;

            dblSByte *= 100;
            dblSByte = (double)(int)dblSByte / 100;

            if (m_Form.DocSize != 0 && m_Form.Unit == null)
            {
                m_Form.DocSize = dblSByte;
                m_Form.Unit = Suffix[i];
            }
            else
            {
                m_Form.Progress = dblSByte;
                m_Form.UnitDoc = Suffix[i];
            }
        }

        private void memoryrelease_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void Monitor_Tick(object sender, EventArgs e)
        {
            if (FormVariable.Size > 0)
            {
                FormatBytes(FormVariable.Size);
                Progress();
            }
            else
            {
                FormatBytes(progressBar1.Maximum);
                Label_DocSize.Text = $@"{m_Form.Progress:.00} {m_Form.UnitDoc} / {m_Form.DocSize:.00} {m_Form.Unit}";
                progressBar1.Value = progressBar1.Maximum;
                Monitor.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Monitor.Stop();

            comboBox_Core.Items.Add("請選擇");
            comboBox_Core.Items.Add("單核心　　　(加密慢)");
            comboBox_Core.Items.Add("多核心　　　(加密快)");

            comboBox_EncDecFunction.Items.Add("請選擇");
            comboBox_EncDecFunction.Items.Add("硬碟加密　　(加密慢)");
            comboBox_EncDecFunction.Items.Add("記憶體加密　(加密快)");

            comboBox_Core.SelectedIndex = 1;
            comboBox_EncDecFunction.SelectedIndex = 1;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
單核心加密：加密速度慢但不影響電腦效能
多核心加密：加密速度快但嚴重影響電腦效能

以上選項如果沒有使用雙重加密只透過Rijndael加密都不會吃效能

記憶體加密：加密速度極快，使用記憶體進行加密速度極快
　磁碟加密：加密速度極慢，透過實體應碟加密(暫存空間)


雙重加密：
透過自定義byte 1~255 共2類 每類共256組密碼
先將檔案透過第一類KEY進行記憶體或磁碟
記憶體將存至記憶體，磁碟將存至(暫存空間)
然後將加密後的檔案，透過Rijndael進行加密
加密後透過第二類KEY進行加密，共加密3次。

沒有雙重加密的話僅透過Rijndael進行加密加密。

有雙重加密的檔案，只能用雙重解密否則無法解密
請妥善保管雙重加密KEY，遺失任何密鑰將無法解密
順序錯誤或任一組KEY錯誤都無法解密。
", "說明", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void comboBox_Core_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormVariable.Core = comboBox_Core.SelectedIndex;
        }

        private void comboBox_EncDecFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormVariable.EncDecFunction = comboBox_EncDecFunction.SelectedIndex;
        }
    }
}
