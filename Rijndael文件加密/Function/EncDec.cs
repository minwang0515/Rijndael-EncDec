using key;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace EncDec
{
    internal class EncDeca
    {
        FileStream outFile = null;
        RijndaelKey m_RijndaelKey = new RijndaelKey();
        Dockey m_Dockey = new Dockey();
        public int MinEn(int Oldsrc, int m_Enkey)
        {
            Oldsrc = ~Oldsrc;
            Oldsrc ^= m_Enkey;
            return Oldsrc;
        }
        public void Encrypt(string OldDoc, string NewDoc)
        {
            try
            {
                RijndaelManaged Rijndael;
                Rijndael = new RijndaelManaged();
                Rijndael.BlockSize = 256;
                ICryptoTransform Encrypt = Rijndael.CreateEncryptor(m_RijndaelKey.m_RijndaelKey, m_RijndaelKey.m_RijndaelVector);

                byte[] Oldsrc = File.ReadAllBytes(OldDoc);
                for (int i = 0; i < Oldsrc.Length; i++)
                    Oldsrc[i] = (byte)MinEn(Oldsrc[i], m_Dockey.m_Dockey[(byte)i]);

                Stream Newsrc = new MemoryStream(Oldsrc);
                CryptoStream RijndaelDoc = new CryptoStream(Newsrc, Encrypt, CryptoStreamMode.Read);
                outFile = new FileStream(NewDoc, FileMode.Create);
                int j = 0;
                byte k = 0;
                while ((j = RijndaelDoc.ReadByte()) != -1)
                {
                    outFile.WriteByte((byte)MinEn(j, m_Dockey.m_EnDockey[k]));
                    k++;
                }
                m_RijndaelKey = null;
                m_Dockey = null;
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
        }

        public void Decrypt(string OldDoc, string NewDoc)
        {
            try
            {
                RijndaelKey m_RijndaelKey = new RijndaelKey();
                Dockey m_Dockey = new Dockey();
                RijndaelManaged Rijndael;
                Rijndael = new RijndaelManaged();
                Rijndael.BlockSize = 256;
                ICryptoTransform Decrypt = Rijndael.CreateDecryptor(m_RijndaelKey.m_RijndaelKey, m_RijndaelKey.m_RijndaelVector);

                byte[] Oldsrc = File.ReadAllBytes(OldDoc);
                for (int i = 0; i < Oldsrc.Length; i++)
                    Oldsrc[i] = (byte)MinEn(Oldsrc[i], m_Dockey.m_EnDockey[(byte)i]);

                Stream Newsrc = new MemoryStream(Oldsrc);
                CryptoStream RijndaelDoc = new CryptoStream(Newsrc, Decrypt, CryptoStreamMode.Read);
                outFile = new FileStream(NewDoc, FileMode.Create);
                int j = 0;
                byte k = 0;
                while ((j = RijndaelDoc.ReadByte()) != -1)
                {
                    outFile.WriteByte((byte)MinEn(j, m_Dockey.m_Dockey[k]));
                    k++;
                }
                m_RijndaelKey = null;
                m_Dockey = null;
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
    }
}
