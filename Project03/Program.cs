using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Project03
{
    class Program
    {
        static String sourceFilePath = Path.GetFullPath("../../../../") + "源文件夹";  // 源文件夹路径
        static String desFilePath = Path.GetFullPath("../../../../") + "目标文件夹"; // 目标文件夹路径
        static int Tid = 0;
        public class CopyFile
        {
            public String getItem()
            {
                IEnumerable<String> files = Directory.EnumerateFileSystemEntries(sourceFilePath);
                if (files != null && files.Count() > 0)
                {
                    int count = 0;
                    foreach (var item in files)
                    {
                        count++;
                        if (count == Tid)
                        {
                            //如果是文件
                            var fileExist = File.Exists(item);
                            if (fileExist)
                            {
                                return item;
                            }
                        }
                    }
                }
                return null;
            }
            public void threadmethod()
            {
                String item = getItem();
                if(item != null)
                {
                    string desPath = Path.Combine(desFilePath, Path.GetFileName(item));
                    //复制文件到指定目录下
                    try
                    {
                        File.Copy(item, desPath, true);
                    }
                    catch
                    {

                    }
                    Console.WriteLine("--->该进程文件拷贝完成...");
                }
                else
                {
                    Console.WriteLine("--->此进程未拷贝文件...");
                }
                
            }
        }
        
        // 移动文件夹里的内容
        
        static void Main(string[] args)
        {
            Console.WriteLine("------------202100838-------------");
            //在该解决方案中创建一个目标文件夹，用来存放粘贴的内容
            string sPath = Path.GetFullPath("../../../../")+"目标文件夹";
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);//创建路径
            }
            IEnumerable<String> files = Directory.EnumerateFileSystemEntries(sourceFilePath);
            int count_thread = files.Count();
            CopyFile copyFile = new CopyFile();
            ThreadStart threadStart = new ThreadStart(copyFile.threadmethod);
            for(int i = 0; i < count_thread; i++)
            {
                Tid++;
                Thread thread = new Thread(threadStart);
                thread.Start();
            }
        }
    }
}
