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
        RijndaelKey m_RijndaelKey = new RijndaelKey();
        Dockey m_Dockey = new Dockey();
        public delegate void DelShowMessage();
        public string m_Name { get; set; }

        string OldDocStr = null;
        string NewDocStr = null;
        string unit = null;
        string unitDoc = null;
        long size = 0;
        double nDocSize = 0;
        double nProgress = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public void Progress()
        {
            if (InvokeRequired)
            {
                DelShowMessage del = new DelShowMessage(Progress);
                Invoke(del, $@"{nProgress:.00} {unitDoc} / {nDocSize:.00} {unit}"); //{DocTotalSize / 1024} KB");
            }
            else
            {
                label_DocSize.Text = $@"{nProgress:.00} {unitDoc} / {nDocSize:.00} {unit}"; //{DocTotalSize/1024} KB";
                progressBar1.Value = (int)size;
                //progressBar1.Value = i;
            }
        }

        public int MinEn(int ii, int Oldsrc, int m_Enkey)
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
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {

                string folderPath = $@"{Environment.CurrentDirectory}\加密";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                FileInfo fInfo = new FileInfo(OldDoc.FileName);
                progressBar1.Maximum = (int)fInfo.Length;
                FormatBytes(fInfo.Length);
                Monitor.Start();

                await Task.Run(() =>
                {
                    OldDocStr = OldDoc.FileName;
                    NewDocStr = $@"{folderPath}\{Path.GetFileName(OldDoc.FileName)}";
                    Thread thrStart = new Thread(Encrypt);
                    thrStart.Start();
                    GC.Collect();
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

        private async void DecryptBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog OldDoc = new OpenFileDialog();
            OldDoc.InitialDirectory = @".\";
            OldDoc.Filter = "解密 (*.*)|*.*";
            OldDoc.Title = "解密";
            OldDoc.RestoreDirectory = true;
            if (OldDoc.ShowDialog() == DialogResult.OK)
            {
                string folderPath = $@"{Environment.CurrentDirectory}\解密";
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                await Task.Run(() => m_EncDec.Decrypt(OldDoc.FileName, $@"{folderPath}\{Path.GetFileName(OldDoc.FileName)}"));
            }
            GC.Collect();
        }

        private void memoryrelease_Tick(object sender, EventArgs e)
        {
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

                    RijndaelManaged Rijndael;
                    Rijndael = new RijndaelManaged();
                    Rijndael.BlockSize = 256;
                    ICryptoTransform Encrypt = Rijndael.CreateEncryptor(m_RijndaelKey.m_RijndaelKey, m_RijndaelKey.m_RijndaelVector);

                    byte[] Oldsrc = File.ReadAllBytes(OldDocStr);

                    DateTime aaa = DateTime.Now;
                    Parallel.For(0, Oldsrc.Length, i =>
                        {
                            Oldsrc[i] = (byte)MinEn(i, Oldsrc[i], m_Dockey.m_Dockey[(byte)i]);

                            //size++;
                            //Progress(i.ToString());
                            //m_time++;
                            //Progress(i.ToString());
                            //size++;
                            //if ((size / 1024) > 1024)//(Oldsrc.Length * 00.1))
                            //{

                            //    //Progress(i.ToString());
                            //    //size = 0;
                            //}
                        });


                    //for (int i = 0; i < Oldsrc.Length; i++)
                    //{
                    //    Oldsrc[i] = (byte)MinEn(i, Oldsrc[i], m_Dockey.m_Dockey[(byte)i]);
                    //    size++;
                    //    //Progress(i.ToString());
                    //    //m_time++;
                    //    //Progress(i.ToString());
                    //    //size++;
                    //    //if ((size / 1024) > 1024)//(Oldsrc.Length * 00.1))
                    //    //{

                    //    //    //Progress(i.ToString());
                    //    //    //size = 0;
                    //    //}
                    //}

                    MessageBox.Show((DateTime.Now - aaa).ToString());
                    //Progress(Oldsrc.Length.ToString());
                    


                    Stream Newsrc = new MemoryStream(Oldsrc);
                    CryptoStream RijndaelDoc = new CryptoStream(Newsrc, Encrypt, CryptoStreamMode.Read);
                    outFile = new FileStream(NewDocStr, FileMode.Create);
                    int j = 0;
                    byte k = 0;

                    while ((j = RijndaelDoc.ReadByte()) != -1)
                    {
                        outFile.WriteByte((byte)MinEn(k,j, m_Dockey.m_EnDockey[k]));
                        k++;
                    }
                    Newsrc.Close();
                    Oldsrc = new byte[0];
                    Rijndael.Clear();
                    Encrypt = null;
                    RijndaelDoc.Close();
                    RijndaelDoc = null;
                    outFile.Close();
                    outFile = null;
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

        public void Decrypt(string OldDoc, string NewDoc)
        {
            try
            {
                Dockey m_Dockey = new Dockey();
                RijndaelManaged Rijndael;
                Rijndael = new RijndaelManaged();
                Rijndael.BlockSize = 256;
                ICryptoTransform Decrypt = Rijndael.CreateDecryptor(m_RijndaelKey.m_RijndaelKey, m_RijndaelKey.m_RijndaelVector);

                byte[] Oldsrc = File.ReadAllBytes(OldDoc);
                for (int i = 0; i < Oldsrc.Length; i++)
                    Oldsrc[i] = (byte)MinEn(i, Oldsrc[i], m_Dockey.m_EnDockey[(byte)i]);

                Stream Newsrc = new MemoryStream(Oldsrc);
                CryptoStream RijndaelDoc = new CryptoStream(Newsrc, Decrypt, CryptoStreamMode.Read);
                outFile = new FileStream(NewDoc, FileMode.Create);
                int j = 0;
                byte k = 0;
                while ((j = RijndaelDoc.ReadByte()) != -1)
                {
                    outFile.WriteByte((byte)MinEn(k, j, m_Dockey.m_Dockey[k]));
                    k++;
                }
                Newsrc.Close();
                Oldsrc = new byte[0];
                Rijndael.Clear();
                Decrypt = null;
                RijndaelDoc.Close();
                RijndaelDoc = null;
                outFile.Close();
                outFile = null;
                MessageBox.Show("解密成功", "解密", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                outFile.Close();
                outFile = null;
                MessageBox.Show(ex.ToString(), "發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Monitor.Stop();
        }
    }
}
