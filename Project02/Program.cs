using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Project01;
/*
使用上一题的学生集合，编写一个功能类完成一下功能：
1、使用json序列化学生集合，并保存在文件中。
2、使用反序列化技术，读取文件内容，并遍历显示。
编写一个测试类，测试该功能。
 */
namespace Project02
{
    class Program : Student
    {
        // 获取环境当前路径
        static string projPath = Environment.CurrentDirectory;
        static void SerializerJSON()
        {
            List<Student> stu_list = new Student().initStu_list();
            
            // 文件流初始化
            FileStream fs = new FileStream($@"{projPath}\stuList.json", FileMode.Create);
            // 操作对象
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            Utf8JsonWriter jw = new Utf8JsonWriter(fs);
            // json序列化学生集合
            JsonSerializer.Serialize(jw, stu_list, options);
            // 关闭文件流
            fs.Close();
        }
        static void DeSerializerJSON()
        {
            // 初始化文件流对象
            FileStream fs = new FileStream($@"{projPath}\stuList.json",
                FileMode.Open, FileAccess.Read);
            // 读取文件
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
            // 文件内容赋值给字符串
            String jsondata = sr.ReadToEnd();
            // 初始化一个空的列表对象
            List<Student> stu_list = new List<Student>();
            stu_list = (List<Student>)JsonSerializer.Deserialize(jsondata, 
                typeof(List<Student>));
            foreach(var stu in stu_list){
                stu.printInfo();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("20软一：202100838\n--------------------------");
            // 1、使用json序列化学生集合，并保存在文件中。
            Console.WriteLine("开始Json序列化...");
            SerializerJSON();
            Console.WriteLine("Json序列化结束！\n--------------------------");
            // 2、使用反序列化技术，读取文件内容，并遍历显示。
            Console.WriteLine("开始Json反序列化...");
            DeSerializerJSON();
            Console.WriteLine("Json反序列化结束！");
        }
    }
}
