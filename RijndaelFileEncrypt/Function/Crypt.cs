using RijndaelFileEncrypt.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RijndaelFileEncrypt.Function
{
    public class Crypt : FormVariable
    {
        Form1 form = new Form1();
        public async void Encrypt()
        {
            await Task.Run(() =>
            {
                try
                {
                    RijndaelManaged Rijndael;
                    Rijndael = new RijndaelManaged();
                    Rijndael.BlockSize = 256;
                    ICryptoTransform Encrypt = Rijndael.CreateEncryptor(RijndaelKey.RijndaelKey, RijndaelKey.RijndaelVector);

                    byte[] Rijndaebyte;
                    byte[] Oldsrc = null;
                    FileStream src = null;

                    string Pathtemp = $@"{Directory.GetCurrentDirectory()}\Temp";
                    string docPathtemp = $@"{Pathtemp}\temp";
                    if (!Directory.Exists(Pathtemp))
                        Directory.CreateDirectory(Pathtemp);

                    if (DoubleEncDec)//雙層加密
                    {
                        if (EncDecFunction == 1)
                        {
                            //磁碟加密
                            src = new FileStream(OldDocStr, FileMode.Open);

                            OutTempFile = new FileStream(docPathtemp, FileMode.Create);
                            int i = 0;
                            while ((i = src.ReadByte()) != -1)
                            {
                                OutTempFile.WriteByte((byte)MinEn(i, Dockey.OneDockey[(byte)TotalSize]));
                                TotalSize++;
                                Size++;
                            }
                            OutTempFile.Close();
                            src.Close();
                            src = new FileStream(docPathtemp, FileMode.Open);
                        }
                        else
                        {
                            //記憶體加密
                            Oldsrc = File.ReadAllBytes(OldDocStr);

                            if (Core == 1)
                            {
                                //單核心
                                for (Size = 0; Size < Oldsrc.Length; Size++)
                                {
                                    Oldsrc[Size] = (byte)MinEn(Oldsrc[Size], Dockey.OneDockey[(byte)Size]);
                                    TotalSize++;
                                }
                            }
                            else if (Core == 2)
                            {
                                //多核心
                                Parallel.For(0, Oldsrc.Length, i =>
                                    Oldsrc[i] = (byte)MinEn(Oldsrc[i], Dockey.OneDockey[(byte)i]));
                            }
                        }

                        if (EncDecFunction == 1)
                        {
                            //磁碟加密

                            RijndaelDoc = new CryptoStream(src, Encrypt, CryptoStreamMode.Read);
                            OutFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            Thread.Sleep(500);
                            Size = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                OutFile.WriteByte((byte)MinEn(j, Dockey.TwoDockey[(byte)Size]));
                                TotalSize++;
                                Size++;
                                
                            }
                            MonitorTime = false;
                        }
                        else if (EncDecFunction == 2)
                        {
                            //記憶體加密
                            Rijndaebyte = PerformCryptography(Encrypt, Oldsrc);
                            if (Core == 1)
                            {
                                //單核心
                                for (Size = 0; Size < Rijndaebyte.Length; Size++)
                                {
                                    Rijndaebyte[Size] = (byte)MinEn(Rijndaebyte[Size], Dockey.TwoDockey[(byte)Size]);
                                    TotalSize++;
                                }
                            }
                            else if (Core == 2)
                            {
                                //多核心
                                Parallel.For(0, Rijndaebyte.Length, i =>
                                    Rijndaebyte[i] = (byte)MinEn(Rijndaebyte[i], Dockey.TwoDockey[(byte)i]));
                            }
                            MonitorTime = false;
                            using (OutFile = new FileStream(NewDocStr, FileMode.Create))
                                OutFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    else //單層加密
                    {
                        if (EncDecFunction == 1)
                        {
                            //磁碟加密
                            src = new FileStream(OldDocStr, FileMode.Open);
                            RijndaelDoc = new CryptoStream(src, Encrypt, CryptoStreamMode.Read);
                            OutFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                OutFile.WriteByte((byte)j);
                                TotalSize += 1 * 2;
                                Size++;
                            }
                            MonitorTime = false;
                        }
                        else if (EncDecFunction == 2)
                        {
                            //記憶體加密
                            Oldsrc = File.ReadAllBytes(OldDocStr);
                            Rijndaebyte = PerformCryptography(Encrypt, Oldsrc);

                            using (OutFile = new FileStream(NewDocStr, FileMode.Create))
                                OutFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    Oldsrc = new byte[0];
                    Rijndaebyte = new byte[0];
                    Rijndael.Clear();
                    Encrypt = null;
                    RijndaelDoc.Close();
                    RijndaelDoc = null;
                    OutFile.Close();
                    OutFile = null;
                    Directory.Delete(Pathtemp, true);
                    Size = 0;
                    TotalSize = 0;
                    MessageBox.Show("加密成功", "加密", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    OutFile.Close();
                    OutFile = null;
                    MessageBox.Show(ex.ToString(), "發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        public async void Decrypt()
        {
            await Task.Run(() =>
            {
                try
                {
                    RijndaelManaged Rijndael;
                    Rijndael = new RijndaelManaged();
                    Rijndael.BlockSize = 256;
                    ICryptoTransform Decryptor = Rijndael.CreateDecryptor(RijndaelKey.RijndaelKey, RijndaelKey.RijndaelVector);

                    byte[] Rijndaebyte;
                    byte[] Oldsrc = null;
                    FileStream src = null;

                    string Pathtemp = $@"{Directory.GetCurrentDirectory()}\Temp";
                    string docPathtemp = $@"{Pathtemp}\temp";
                    if (!Directory.Exists(Pathtemp))
                        Directory.CreateDirectory(Pathtemp);

                    if (DoubleEncDec)//雙層解密
                    {
                        if (EncDecFunction == 1)//磁碟解密
                        {
                            src = new FileStream(OldDocStr, FileMode.Open);

                            OutTempFile = new FileStream(docPathtemp, FileMode.Create);
                            int i = 0;
                            while ((i = src.ReadByte()) != -1)
                            {
                                OutTempFile.WriteByte((byte)MinEn(i, Dockey.TwoDockey[(byte)Size]));
                                TotalSize++;
                                Size++;
                            }
                            OutTempFile.Close();
                            src.Close();
                            src = new FileStream(docPathtemp, FileMode.Open);
                        }
                        else//記憶體解密
                        {
                            Oldsrc = File.ReadAllBytes(OldDocStr);

                            if (Core == 1)
                            {
                                //單核心
                                for (Size = 0; Size < Oldsrc.Length; Size++)
                                {
                                    Oldsrc[Size] = (byte)MinEn(Oldsrc[Size], Dockey.TwoDockey[(byte)Size]);
                                    TotalSize++;
                                }
                            }
                            else if (Core == 2)
                            {
                                //多核心
                                Parallel.For(0, Oldsrc.Length, i =>
                                        Oldsrc[i] = (byte)MinEn(Oldsrc[i], Dockey.TwoDockey[(byte)i]));
                            }
                        }

                        if (EncDecFunction == 1)//磁碟解密
                        {
                            RijndaelDoc = new CryptoStream(src, Decryptor, CryptoStreamMode.Read);
                            OutFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            Size = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                OutFile.WriteByte((byte)MinEn(j, Dockey.OneDockey[(byte)Size]));
                                TotalSize++;
                                Size++;
                            }
                            MonitorTime = false;
                        }
                        else if (EncDecFunction == 2)//記憶體解密
                        {
                            Rijndaebyte = PerformCryptography(Decryptor, Oldsrc);
                            if (Core == 1)//單核心
                            {
                                for (Size = 0; Size < Rijndaebyte.Length; Size++)
                                {
                                    Rijndaebyte[Size] = (byte)MinEn(Rijndaebyte[Size], Dockey.OneDockey[(byte)Size]);
                                    TotalSize++;
                                }
                            }
                            else if (Core == 2)//多核心
                            {
                                Parallel.For(0, Rijndaebyte.Length, i =>
                                        Rijndaebyte[i] = (byte)MinEn(Rijndaebyte[i], Dockey.OneDockey[(byte)i]));
                            }
                            MonitorTime = false;
                            using (OutFile = new FileStream(NewDocStr, FileMode.Create))
                                OutFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    else //單層解密
                    {
                        if (EncDecFunction == 1)
                        {
                            //磁碟解密
                            src = new FileStream(OldDocStr, FileMode.Open);
                            RijndaelDoc = new CryptoStream(src, Decryptor, CryptoStreamMode.Read);
                            OutFile = new FileStream(NewDocStr, FileMode.Create);
                            int j = 0;
                            while ((j = RijndaelDoc.ReadByte()) != -1)
                            {
                                OutFile.WriteByte((byte)j);
                                TotalSize += 1 * 2;
                                Size++;
                            }
                            MonitorTime = false;
                        }
                        else if (EncDecFunction == 2)
                        {
                            //記憶體解密
                            Oldsrc = File.ReadAllBytes(OldDocStr);
                            Rijndaebyte = PerformCryptography(Decryptor, Oldsrc);

                            using (OutFile = new FileStream(NewDocStr, FileMode.Create))
                                OutFile.Write(Rijndaebyte, 0, Rijndaebyte.Length);
                        }
                    }
                    Oldsrc = new byte[0];
                    Rijndaebyte = new byte[0];
                    Rijndael.Clear();
                    Decryptor = null;
                    RijndaelDoc.Close();
                    RijndaelDoc = null;
                    OutFile.Close();
                    OutFile = null;
                    Directory.Delete(Pathtemp, true);
                    Size = 0;
                    TotalSize = 0;
                    MessageBox.Show("解密成功", "解密", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    OutFile.Close();
                    OutFile = null;
                    MessageBox.Show(ex.ToString(), "發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }
        public int MinEn(int Oldsrc, int m_Enkey)
        {
            Oldsrc = ~Oldsrc;
            Oldsrc ^= m_Enkey;
            return Oldsrc;
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
    }
}