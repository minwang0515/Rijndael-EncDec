using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RijndaelFileEncrypt.Function
{
    public class GetMemory
    {
        public string StrGetTotalPhys => FormatSize(GetTotalPhys());
        public string StrGetUsedPhys => FormatSize(GetUsedPhys());
        public string StrGetUsage => GetUsage();
        public string StrGetForm => FormatSize(GetForm());
        #region 獲得記憶體信息API
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORY_INFO mi);

        //定義記憶體的信息結構
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength; //當前結構體大小
            public uint dwMemoryLoad; //當前記憶體使用率
            public ulong ullTotalPhys; //總計物理記憶體大小
            public ulong ullAvailPhys; //可用物理記憶體大小
            public ulong ullTotalPageFile; //總計交換文件大小
            public ulong ullAvailPageFile; //總計交換文件大小
            public ulong ullTotalVirtual; //總計虛擬記憶體大小
            public ulong ullAvailVirtual; //可用虛擬記憶體大小
            public ulong ullAvailExtendedVirtual; //保留 這個值始終為0
        }
        #endregion

        #region 格式化容量大小
        /// <summary>
        /// 格式化容量大小
        /// </summary>
        /// <param name="bytes">容量（B）</param>
        /// <returns>已格式化的容量</returns>
        private static string FormatSize(double bytes)
        {
            string[] Suffix = { "byte", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
                dblSByte = bytes / 1024.0;

            //為了精準到小數點後2位
            dblSByte *= 100;
            dblSByte = (double)(int)dblSByte / 100;

            return $"{dblSByte:.00} {Suffix[i]}";
        }
        #endregion

        #region 獲得當前記憶體使用情況
        /// <summary>
        /// 獲得當前記憶體使用情況
        /// </summary>
        /// <returns></returns>
        public static MEMORY_INFO GetMemoryStatus()
        {
            MEMORY_INFO mi = new MEMORY_INFO();
            mi.dwLength = (uint)Marshal.SizeOf(mi);
            GlobalMemoryStatusEx(ref mi);
            return mi;
        }
        #endregion

        #region 獲得當前可用物理記憶體大小
        /// <summary>
        /// 獲得當前可用物理記憶體大小
        /// </summary>
        /// <returns>當前可用物理記憶體（B）</returns>
        public static ulong GetAvailPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullAvailPhys;
        }
        #endregion

        #region 獲得當前已使用的記憶體大小
        /// <summary>
        /// 獲得當前已使用的記憶體大小
        /// </summary>
        /// <returns>已使用的記憶體大小（B）</returns>
        public static ulong GetUsedPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return (mi.ullTotalPhys - mi.ullAvailPhys);
        }
        #endregion

        #region 獲得當前總計物理記憶體大小
        /// <summary>
        /// 獲得當前總計物理記憶體大小
        /// </summary>
        /// <returns&amp;gt;總計物理記憶體大小（B）&amp;lt;/returns&amp;gt;
        public static ulong GetTotalPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullTotalPhys;
        }
        #endregion

        #region 獲得當前記憶體使用率
        public static string GetUsage()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return $@"{mi.dwMemoryLoad}%";
        }
        #endregion
        
        #region 獲得當前程式記憶體使用大小
        public static ulong GetForm()
        {
            PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", Process.GetCurrentProcess().ProcessName);
            return (ulong)pf1.NextValue();
        }
        #endregion
    }
}
