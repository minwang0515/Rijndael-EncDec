using EncDec;
using key;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Rijndael文件加密
{
    public partial class Form1 : Form
    {
        EncDeca m_EncDec = new EncDeca();
        FileStream outFile = null;
        FileStream outTempFile = null;
        RijndaelKey m_RijndaelKey = new RijndaelKey();
        Dockey m_Dockey = new Dockey();
        //public delegate void DelShowMessage();
        public string m_Name { get; set; }

        string OldDocStr = null;
        string NewDocStr = null;
        string unit = null;
        string unitDoc = null;
        int size = 0;
        double nDocSize = 0;
        double nProgress = 0;
        double dDocSize = 0;
        int RijndaeEn = 0;
        CryptoStream RijndaelDoc;
        int nCore = 0;
        int nEncDecFunction = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void Progress()
        {
            //if (InvokeRequired)
            //{
            //    //DelShowMessage del = new DelShowMessage(Progress);
            //    //Invoke(del, $@"{nProgress:.00} {unitDoc} / {nDocSize:.00} {unit}"); //{DocTotalSize / 1024} KB");
            //}
            //else
            //{
            //    label_DocSize.Text = $@"{nProgress:.00} {unitDoc} / {nDocSize:.00} {unit}"; //{DocTotalSize/1024} KB";
            //    progressBar1.Value = (int)size;
            //    //progressBar1.Value = i;
            //}
            if (progressBar1.Maximum > size)
            {
                label_DocSize.Text = $@"{nProgress:.00} {unitDoc} / {nDocSize:.00} {unit}"; //{DocTotalSize/1024} KB";
                progressBar1.Value = size;
            }
            //if (RijndaeEn > 0 && progressBar2.Maximum > RijndaeEn + size)
            //    progressBar2.Value = size;
            //else if (RijndaeEn <= 0)
            //    progressBar2.Value = size;
        }

        public int MinEn(int Oldsrc, int m_Enkey)
        {
            Oldsrc = ~Oldsrc;
            Oldsrc ^= m_Enkey;
            return Oldsrc;
        }
        private async void EncryptBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog OldDoc = new OpenFileDialog();
            OldDoc.InitialDirectory = @".\";
            OldDoc.Filter = "加密 (*.*)|*.*";
            OldDoc.Title = "加密";
            OldDoc.RestoreDirectory = true;
            Thread thrStart = null;
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {

                string folderPath = $@"{Environment.CurrentDirectory}\加密";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                progressBar1.Maximum = (int)fInfo.Length;
                progressBar2.Maximum = (int)fInfo.Length;
                dDocSize = (int)fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();

                await Task.Run(() =>
                {
                    OldDocStr = OldDoc.FileName;
                    NewDocStr = $@"{folderPath}\{Path.GetFileName(OldDoc.FileName)}";
                    thrStart = new Thread(Encrypt);
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
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {

                string folderPath = $@"{Environment.CurrentDirectory}\解密";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                progressBar1.Maximum = (int)fInfo.Length;
                progressBar2.Maximum = (int)fInfo.Length;
                dDocSize = (int)fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();

                await Task.Run(() =>
                {
                    OldDocStr = OldDoc.FileName;
                    NewDocStr = $@"{folderPath}\{Path.GetFileName(OldDoc.FileName)}";
                    thrStart = new Thread(Decrypt);
                    thrStart.Start();
                });
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

            if (nDocSize == 0 && unit == null)
            {
                nDocSize = dblSByte;
                unit = Suffix[i];
            }
            else
            {
                nProgress = dblSByte;
                unitDoc = Suffix[i];
            }
        }

        private void memoryrelease_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            //progressBar1.PerformStep();
            //記憶體使用量
            //MemoryTimerLabel.Text = (Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024).ToString();
        }

        private void Monitor_Tick(object sender, EventArgs e)
        {
            if (size > 0)
            {
                FormatBytes(size);
                Progress();
            }
        }
        public async void Encrypt()
        {
            await Task.Run(() =>
            {
                
                try
                {
                    DateTime aaa = DateTime.Now;
                    RijndaelManaged Rijndael;
                    Rijndael = new RijndaelManaged();
                    Rijndael.BlockSize = 256;
                    ICryptoTransform Encrypt = Rijndael.CreateEncryptor(m_RijndaelKey.m_RijndaelKey, m_RijndaelKey.m_RijndaelVector);

                    byte[] Rijndaebyte;
                    byte[] Oldsrc = null;
                    FileStream src = null;

                    string Pathtemp = $@"{Directory.GetCurrentDirectory()}\Temp";
                    string docPathtemp = $@"{Pathtemp}\temp";
                    if (!Directory.Exists(Pathtemp))
                        Directory.CreateDirectory(Pathtemp);

                    if (DoubleEncDec.Checked)//雙層加密
                    {
                        if (nEncDecFunction == 1)
                        {
                            //磁碟加密
                            src = new FileStream(OldDocStr, FileMode.Open);

                            outTempFile = new FileStream(docPathtemp, FileMode.Create);
                            int i = 0;
                            while ((i = src.ReadByte()) != -1)
                            {
                                outTempFile.WriteByte((byte)MinEn(i, m_Dockey.m_Dockey[(byte)size]));
                                size++;
                            }
                            outTempFile.Close();
                            src.Close();
                            src = new FileStream(docPathtemp, FileMode.Open);
                        }
                        else
                        {
                            //記憶體加密
                            Oldsrc = File.ReadAllBytes(OldDocStr);

                            if (nCore == 1)
                            {
                                //單核心
                                for (size = 0; size < Oldsrc.Length; size++)
                                    Oldsrc[size] = (byte)MinEn(Oldsrc[size], m_Dockey.m_Dockey[(byte)size]);
                            }
                            else if (nCore == 2)
                            {
                                //多核心
                                Parallel.For(0, Oldsrc.Length, i =>
                                    Oldsrc[i] = (byte)MinEn(Oldsrc[i], m_Dockey.m_Dockey[(byte)i]));
                            }
                        }

                        size = 0;
                        RijndaeEn = (int)dDocSize;

                        if (nEncDecFunction == 1)
                        {
                            //磁碟加密

                            RijndaelDoc = new CryptoStream(src, Encrypt, CryptoStreamMode.Read);
                            outFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                outFile.WriteByte((byte)MinEn(j, m_Dockey.m_EnDockey[(byte)size]));
                                size++;
                            }
                        }
                        else if (nEncDecFunction == 2)
                        {
                            //記憶體加密
                            Rijndaebyte = PerformCryptography(Encrypt, Oldsrc);
                            if (nCore == 1)
                            {
                                //單核心
                                for (size = 0; size < Rijndaebyte.Length; size++)
                                    Rijndaebyte[size] = (byte)MinEn(Rijndaebyte[size], m_Dockey.m_EnDockey[(byte)size]);
                            }
                            else if (nCore == 2)
                            {
                                //多核心
                                Parallel.For(0, Rijndaebyte.Length, i =>
                                    Rijndaebyte[i] = (byte)MinEn(Rijndaebyte[i], m_Dockey.m_EnDockey[(byte)i]));
                            }
                            using (outFile = new FileStream(NewDocStr, FileMode.Create))
                                outFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    else //單層加密
                    {
                        if (nEncDecFunction == 1)
                        {
                            //磁碟加密
                            src = new FileStream(OldDocStr, FileMode.Open);
                            RijndaelDoc = new CryptoStream(src, Encrypt, CryptoStreamMode.Read);
                            outFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                outFile.WriteByte((byte)j);
                                size++;
                            }
                        }
                        else if (nEncDecFunction == 2)
                        {
                            //記憶體加密
                            Oldsrc = File.ReadAllBytes(OldDocStr);
                            Rijndaebyte = PerformCryptography(Encrypt, Oldsrc);

                            using (outFile = new FileStream(NewDocStr, FileMode.Create))
                                outFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    Oldsrc = new byte[0];
                    Rijndaebyte = new byte[0];
                    Rijndael.Clear();
                    Encrypt = null;
                    RijndaelDoc.Close();
                    RijndaelDoc = null;
                    outFile.Close();
                    outFile = null;
                    Directory.Delete(Pathtemp, true);
                    MessageBox.Show((DateTime.Now - aaa).ToString(), "加密", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("加密成功", "加密", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    outFile.Close();
                    outFile = null;
                    MessageBox.Show(ex.ToString(), "發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Monitor.Stop();
                size = 0;
                
            });
        }

        private byte[] PerformCryptography(ICryptoTransform cryptoTransform, byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (RijndaelDoc = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    RijndaelDoc.Write(data, 0, data.Length);
                    RijndaelDoc.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
        public async void Decrypt()
        {
            await Task.Run(() =>
            {

                try
                {
                    DateTime aaa = DateTime.Now;
                    RijndaelManaged Rijndael;
                    Rijndael = new RijndaelManaged();
                    Rijndael.BlockSize = 256;
                    ICryptoTransform Decryptor = Rijndael.CreateDecryptor(m_RijndaelKey.m_RijndaelKey, m_RijndaelKey.m_RijndaelVector);

                    byte[] Rijndaebyte;
                    byte[] Oldsrc = null;
                    FileStream src = null;

                    string Pathtemp = $@"{Directory.GetCurrentDirectory()}\Temp";
                    string docPathtemp = $@"{Pathtemp}\temp";
                    if (!Directory.Exists(Pathtemp))
                        Directory.CreateDirectory(Pathtemp);

                    if (DoubleEncDec.Checked)//雙層加密
                    {
                        if (nEncDecFunction == 1)
                        {
                            //磁碟解密
                            src = new FileStream(OldDocStr, FileMode.Open);

                            outTempFile = new FileStream(docPathtemp, FileMode.Create);
                            int i = 0;
                            while ((i = src.ReadByte()) != -1)
                            {
                                outTempFile.WriteByte((byte)MinEn(i, m_Dockey.m_EnDockey[(byte)size]));
                                size++;
                            }
                            outTempFile.Close();
                            src.Close();
                            src = new FileStream(docPathtemp, FileMode.Open);
                        }
                        else
                        {
                            //記憶體解密
                            Oldsrc = File.ReadAllBytes(OldDocStr);

                            if (nCore == 1)
                            {
                                //單核心
                                for (size = 0; size < Oldsrc.Length; size++)
                                    Oldsrc[size] = (byte)MinEn(Oldsrc[size], m_Dockey.m_EnDockey[(byte)size]);
                            }
                            else if (nCore == 2)
                            {
                                //多核心
                                Parallel.For(0, Oldsrc.Length, i =>
                                    Oldsrc[i] = (byte)MinEn(Oldsrc[i], m_Dockey.m_EnDockey[(byte)i]));
                            }
                        }

                        size = 0;
                        RijndaeEn = (int)dDocSize;

                        if (nEncDecFunction == 1)
                        {
                            //磁碟解密

                            RijndaelDoc = new CryptoStream(src, Decryptor, CryptoStreamMode.Read);
                            outFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                outFile.WriteByte((byte)MinEn(j, m_Dockey.m_Dockey[(byte)size]));
                                size++;
                            }
                        }
                        else if (nEncDecFunction == 2)
                        {
                            //記憶體解密
                            Rijndaebyte = PerformCryptography(Decryptor, Oldsrc);
                            if (nCore == 1)
                            {
                                //單核心
                                for (size = 0; size < Rijndaebyte.Length; size++)
                                    Rijndaebyte[size] = (byte)MinEn(Rijndaebyte[size], m_Dockey.m_Dockey[(byte)size]);
                            }
                            else if (nCore == 2)
                            {
                                //多核心
                                Parallel.For(0, Rijndaebyte.Length, i =>
                                    Rijndaebyte[i] = (byte)MinEn(Rijndaebyte[i], m_Dockey.m_Dockey[(byte)i]));
                            }
                            using (outFile = new FileStream(NewDocStr, FileMode.Create))
                                outFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    else //單層解密
                    {
                        if (nEncDecFunction == 1)
                        {
                            //磁碟解密
                            src = new FileStream(OldDocStr, FileMode.Open);
                            RijndaelDoc = new CryptoStream(src, Decryptor, CryptoStreamMode.Read);
                            outFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                outFile.WriteByte((byte)j);
                                size++;
                            }
                        }
                        else if (nEncDecFunction == 2)
                        {
                            //記憶體解密
                            Oldsrc = File.ReadAllBytes(OldDocStr);
                            Rijndaebyte = PerformCryptography(Decryptor, Oldsrc);

                            using (outFile = new FileStream(NewDocStr, FileMode.Create))
                                outFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    Oldsrc = new byte[0];
                    Rijndaebyte = new byte[0];
                    Rijndael.Clear();
                    Decryptor = null;
                    RijndaelDoc.Close();
                    RijndaelDoc = null;
                    outFile.Close();
                    outFile = null;
                    Directory.Delete(Pathtemp, true);
                    MessageBox.Show((DateTime.Now - aaa).ToString(), "解密", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("解密成功", "解密", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    outFile.Close();
                    outFile = null;
                    MessageBox.Show(ex.ToString(), "發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Monitor.Stop();
                size = 0;

            });
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
            nCore = comboBox_Core.SelectedIndex;
        }

        private void comboBox_EncDecFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            nEncDecFunction = comboBox_EncDecFunction.SelectedIndex;
        }
    }
}
