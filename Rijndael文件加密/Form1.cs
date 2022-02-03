using EncDec;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Rijndael文件加密
{
    public partial class Form1 : Form
    {
        EncDeca m_EncDec = new EncDeca();
        public Form1()
        {
            InitializeComponent();
        }

        private async void EncryptBut_Click(object sender, EventArgs e)
        {
            EncDeca m_EncDec = new EncDeca();
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
                await Task.Run(() => m_EncDec.Encrypt(OldDoc.FileName, $@"{folderPath}\{Path.GetFileName(OldDoc.FileName)}"));
            }
            GC.Collect();
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
                {
                    Directory.CreateDirectory(folderPath);
                }
                await Task.Run(() => m_EncDec.Decrypt(OldDoc.FileName, $@"{folderPath}\{Path.GetFileName(OldDoc.FileName)}"));
            }
            GC.Collect();
        }
    }
}
