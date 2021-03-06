using RijndaelFileEncrypt.Function;
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
                ProgressBar_Total.Value = 0;
                ProgressBar.Value = 0;
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                m_Form.DocSize = fInfo.Length;
                FormVariable.FileSize = fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();
                ElementEnabled(false);
                FormVariable.MonitorTime = true;

                FormVariable.DoubleEncDec = CheckBox_DoubleEncDec.Checked;

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
            OldDoc.Filter = $"專屬加密檔案 (*{m_Form.EncDecFilenameExtension}*)|*{m_Form.EncDecFilenameExtension}*|所有檔案 (*.*)|*.*";
            OldDoc.Title = "解密";
            OldDoc.RestoreDirectory = true;
            Thread thrStart = null;
            m_Form.DocSize = 0;
            m_Form.Unit = null;
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                FormVariable.FileSize = fInfo.Length;
                m_Form.DocSize = fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();
                ElementEnabled(false);
                FormVariable.MonitorTime = true;

                FormVariable.DoubleEncDec = CheckBox_DoubleEncDec.Checked;

                await Task.Run(() =>
                {
                    FormVariable.OldDocStr = OldDoc.FileName;
                    FormVariable.NewDocStr = $@"{FormVariable.OldDocStr.Replace(m_Form.EncDecFilenameExtension, "")}";

                    Crypt Crypt = new Crypt();
                    thrStart = new Thread(Crypt.Decrypt);
                    thrStart.Start();
                });
            }
        }

        private void ElementEnabled(bool Enabled)
        {
            Button_Encrypt.Enabled = Enabled;
            Button_Decrypt.Enabled = Enabled;
            comboBox_Core.Enabled = Enabled;
            CheckBox_DoubleEncDec.Enabled = Enabled;
            comboBox_EncDecFunction.Enabled = Enabled;
        }

        private void Progress()
        {
            double Ppercent = (double)FormVariable.Size / (double)FormVariable.FileSize * 100;
            double PpercentTotal =  (double)FormVariable.TotalSize / ((double)FormVariable.FileSize *2) * 100;
            if (Ppercent <= ProgressBar_Total.Maximum)
            {
                string strTemp;
                string strTemp2;
                if (m_Form.Progress.ToString(".00") == ".00")
                    strTemp = m_Form.Progress.ToString();
                else
                    strTemp = m_Form.Progress.ToString(".00");

                Label_DocSize.Text = $@"{strTemp} {m_Form.UnitDoc} / {m_Form.DocSize:.00} {m_Form.Unit}";

                if (Ppercent < 1)
                    strTemp = $"0{TwoDecimalPlaces(Ppercent):.00}%";
                else
                    strTemp = $"{TwoDecimalPlaces(Ppercent):.00}%";

                if(PpercentTotal < 1)
                    strTemp2 = $"0{TwoDecimalPlaces(PpercentTotal):.00}%";
                else
                    strTemp2 = $"{TwoDecimalPlaces(PpercentTotal):.00}%";

                Label_ProgressBar.Text = strTemp;
                Label_Total.Text = strTemp2;
               
                ProgressBar.Value = (int)Ppercent * ProgressBar.Maximum / 100;
                ProgressBar_Total.Value = (int)PpercentTotal * ProgressBar_Total.Maximum / 100;
            }
        }

        private double TwoDecimalPlaces(double Twodouble)
        {
            Twodouble *= 100;
            Twodouble = (double)(int)Twodouble / 100;
            return Twodouble;
        }

        private void FormatBytes(long bytes)
        {
            string[] Suffix = { "byte", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                dblSByte = bytes / 1024.0;

            //為了精準到小數點後2位
            dblSByte = TwoDecimalPlaces(dblSByte);

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

        private async void Memoryrelease_Tick(object sender, EventArgs e)
        {
            await GetStrMemory();
            GC.Collect();
        }

        private async Task GetStrMemory()
        {
            GetMemory memory = new GetMemory();
            string StrGetUsedPhys = null;
            string StrGetTotalPhys = null;
            string StrGetUsage = null;
            string StrGetForm = null;
            await Task.Run(() =>
            {
                StrGetUsedPhys = memory.StrGetUsedPhys;
                StrGetTotalPhys = memory.StrGetTotalPhys;
                StrGetUsage = memory.StrGetUsage;
                StrGetForm = memory.StrGetForm;
            });
            Label_Memory.Text = $"記憶體\r\n總容量：{StrGetTotalPhys}\r\n使用中：{StrGetUsedPhys}\r\n程式記憶體：{StrGetForm}\r\n總使用率：{StrGetUsage}";
        }

        private void Monitor_Tick(object sender, EventArgs e)
        {
            if (FormVariable.MonitorTime)
            {
                FormatBytes(FormVariable.Size);
                Progress();
            }
            else
            {
                Monitor.Stop();
                ElementEnabled(true);
                FormatBytes(FormVariable.FileSize);
                Label_DocSize.Text = $@"{m_Form.Progress:.00} {m_Form.UnitDoc} / {m_Form.DocSize:.00} {m_Form.Unit}";
                Label_Total.Text = "100.00%";
                Label_ProgressBar.Text = "100.00%";
                ProgressBar_Total.Value = ProgressBar_Total.Maximum;
                ProgressBar.Value = ProgressBar.Maximum;
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
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
            await GetStrMemory();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
單核心加密：加密速度慢但不影響電腦效能
多核心加密：加密速度快但嚴重影響電腦效能

以上選項如果只透過Rijndael加密都不會吃效能

記憶體加密：加密速度極快，使用記憶體進行加密速度極快
磁碟加密：加密速度極慢，透過實體應碟加密(暫存空間)

硬碟加密僅會以單核心效能運作

雙層加密：
透過自定義byte 1~255 共2類 每類共256組密碼
先將檔案透過第一類KEY進行記憶體或磁碟
記憶體將存至記憶體，磁碟將存至(暫存空間)
然後將加密後的檔案，透過Rijndael進行加密
加密後透過第二類KEY進行加密，共加密3次。

沒有雙層加密的話僅透過Rijndael進行加密加密。

雙層加密的檔案只能透過雙層解密
單層加密的檔案也是只能夠過單層解密

請妥善保管雙重加密KEY，遺失任何密鑰將無法解密
順序錯誤或任一組KEY錯誤都無法解密。

如果要更改密鑰可用 密鑰產生工具.html
此工具會自動產生256組不重複的密鑰，
產生後會自動複製，然後直接把密鑰，貼到
RijndaelFileEncrypt\Models\Key.cs
更改密鑰前，請確保透過此工具加密的檔
案已經解密，密鑰遺失將無法解密。
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
