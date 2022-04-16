using MEMORY;
using System;
using System.Runtime.InteropServices;

namespace RijndaelFileEncrypt.Function
{
    public class GetMemory : MEMORY_INFO
    {
        //static void Main(string[] args)
        //{
        //    //Console.WriteLine("總記憶體：" + FormatSize(GetTotalPhys()));
        //    //Console.WriteLine("已使用：" + FormatSize(GetUsedPhys()));
        //    //Console.WriteLine("可使用：" + FormatSize(GetAvailPhys()));
        //    //Console.ReadKey();
        //}

        #region 獲得記憶體信息API
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORY_INFO mi);

        //定義記憶體的信息結構
        
        #endregion

        #region 格式化容量大小
        /// <summary>
        /// 格式化容量大小
        /// </summary>
        /// <param name="Size">容量（B）</param>
        /// <returns>已格式化的容量</returns>
        private static string FormatSize(double Size)
        {
            double d = (double)Size;
            int i = 0;
            while ((d > 1024) && (i < 5))
            {
                d /= 1024;
                i++;
            }
            string[] Unit = { "B", "KB", "MB", "GB", "TB" };
            return (string.Format("{0} {1}", Math.Round(d, 2), Unit[i]));
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
            mi.dwLength = (uint)System.Runtime.InteropServices.Marshal.SizeOf(mi);
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
    }
}
