using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            TASDiskInfo diskInfo = new TASDiskInfo();
            diskInfo.DiskInfo();
            TASFileInfo fileInfo = new TASFileInfo();
            fileInfo.FileData(@"C:\Users\HP\Desktop\laba 13\laba 13\Class1.cs");
            TASDirInfo dirInfo = new TASDirInfo();           
            dirInfo.DirInfo(@"C:\Users\HP\Desktop");
            TASFileManager fileManager = new TASFileManager();
            fileManager.FileManager("С:");
            TASLog.SearchByString("FileInfo:");
        }
    }
}