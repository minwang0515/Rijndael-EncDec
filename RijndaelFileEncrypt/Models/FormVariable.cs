﻿using key;
using System.IO;
using System.Security.Cryptography;

namespace RijndaelFileEncrypt.Models
{
    public class FormVariable
    {
        public FileStream OutFile { get; set; } = null;
        public FileStream OutTempFile { get; set; } = null;
        internal RijndaelKey RijndaelKey { get; set; } = new RijndaelKey();
        internal Dockey Dockey { get; set; } = new Dockey();
        public static string OldDocStr { get; set; } = null;
        public static string NewDocStr { get; set; } = null;
        public string Unit { get; set; } = null;
        public string UnitDoc { get; set; } = null;
        public static long Size { get; set; } = 0;
        public static long FileSize { get; set; } = 0;
        public double DocSize { get; set; } = 0;
        public double Progress { get; set; } = 0;
        public string EncDecFilenameExtension { get; set; } = ".minitplus";
        public CryptoStream RijndaelDoc { get; set; }
        public int RijndaeEn { get; set; } = 0;
        public static int Core { get; set; } = 0;
        public static int EncDecFunction { get; set; } = 0;
        public static bool DoubleEncDec { get; set; } = false;
    }
}
