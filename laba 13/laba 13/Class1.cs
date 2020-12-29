using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class TASLog
    {
        public const string sourceFile = @"C:\Users\HP\Desktop\laba 13\laba 13\a.txt";        
        static TASLog() 
        {
            using (StreamWriter w = new StreamWriter(sourceFile, false)) { }
        }
        public static void WriteLine(string str)
        {
            try
            {
                using (StreamWriter w = new StreamWriter(sourceFile, true))
                {
                    w.WriteLine(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public static void SearchByString(string str)
        {
            using (StreamReader sr = new StreamReader(sourceFile, false))
            {
                while (!sr.EndOfStream)
                {
                    if (sr.ReadLine().StartsWith(str))
                        Console.WriteLine(sr.ReadLine());
                }
            }
        }
    }
    public class TASDiskInfo
    {
        public void DiskInfo()
        {
            TASLog.WriteLine("Информация о диске:");
            DriveInfo[] drives = DriveInfo.GetDrives(); 
            foreach (DriveInfo drive in drives)
            {
                TASLog.WriteLine("\tИмя: " + drive.Name);
                TASLog.WriteLine("\tТип: " + drive.DriveType);
                if (drive.IsReady)
                {
                    TASLog.WriteLine("\tФайловая система: " + drive.DriveFormat);
                    TASLog.WriteLine($"\tОбъем свободного места: всего - {drive.TotalFreeSpace / 1000 / 1000 / 1000} GB, доступно - { drive.AvailableFreeSpace / 1024 / 1024 / 1024} GB");
                    TASLog.WriteLine($"\tОбщий размер: {drive.TotalSize / 1024 / 1024 / 1024} GB");
                    TASLog.WriteLine("\tМетка тома диска: " + drive.VolumeLabel);
                }
                TASLog.WriteLine("");
            }
        }
    }
    public class TASFileInfo
    {
        public void FileData(string path)
        {
            TASLog.WriteLine("Информация о файле:");
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                TASLog.WriteLine($"\tПолный путь: {fileInf.DirectoryName}");
                TASLog.WriteLine($"\tИмя: {fileInf.Name}");
                TASLog.WriteLine($"\tОбъем: {fileInf.Length}\n\tРасширение: {fileInf.Extension}\n\tДата создания: {fileInf.CreationTime}");
            }
            else
            {
                TASLog.WriteLine("Такого файла не существует");
            }
        }
    }
    public class TASDirInfo
    {
        public void DirInfo(string dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            TASLog.WriteLine("\nИнформация о директории:");
            TASLog.WriteLine($"\tКоличество файлов: {dirInfo.GetFiles().Count()}");
            TASLog.WriteLine($"\tДата создания: {dirInfo.CreationTime}");
            TASLog.WriteLine($"\tПодкаталоги: {dirInfo.GetDirectories("*", SearchOption.AllDirectories).Count()}");
            TASLog.WriteLine($"\tParents: {dirInfo.Parent}");
        }
    }
    public class TASFileManager
    {
        public void FileManager(string path)
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(path);
                DirectoryInfo dirInfo = Directory.CreateDirectory(driveInfo.Name + "ALIInspect");
                using (StreamWriter writer = File.CreateText(dirInfo.FullName + "\\alidirinfo.txt"))
                {
                    writer.WriteLine("Информация");
                }
                File.Copy(dirInfo.FullName + "\\alidirinfo.txt", dirInfo.FullName + "\\copied.txt");
                File.Delete(dirInfo.FullName + "\\alidirinfo.txt"); 

                DirectoryInfo dirInfo1 = Directory.CreateDirectory(driveInfo.Name + "ALIFiles");
                DirectoryInfo currentDirectory = new DirectoryInfo("./");
                foreach (var item in currentDirectory.GetFiles())
                    item.CopyTo(dirInfo1.FullName + "\\" + item.Name, true);
                dirInfo1.MoveTo(dirInfo.FullName + "\\" + dirInfo1.Name);

                DirectoryInfo dirInfo2 = new DirectoryInfo(dirInfo.FullName + "\\" + dirInfo1.Name);
                ZipFile.CreateFromDirectory(dirInfo2.FullName, dirInfo.FullName + "\\arhive.zip");

                DirectoryInfo exInfo = Directory.CreateDirectory(dirInfo.FullName + "\\Ezvlechen");
                using (ZipArchive arch = ZipFile.OpenRead(dirInfo.FullName + "\\arhive.zip"))
                {
                    foreach (ZipArchiveEntry entry in arch.Entries)
                    {
                        entry.ExtractToFile(exInfo.FullName + "\\Ezvlechen_" + entry.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}