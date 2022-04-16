namespace MEMORY
{
    public class MEMORY_INFO
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
}
