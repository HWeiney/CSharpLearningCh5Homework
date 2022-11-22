using System;
using System.Collections.Generic;
/*
1. 编写一个学生类，使用List<T>泛型集合，实现下面几个功能：
(1)增加一个学生
(2)修改一个指定学号的学生
(3)删除一个学生
(4)查询一个指定学号的学生
(5)遍历所有学生
编写测试类，测试以上所有功能。
*/
namespace Project01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("20软一：202100838\n--------------------------");
            List<Student> list = new Student().initStu_list();
            // (2)修改一个指定学号的学生
            // 测试修改学号为1002的学生信息:1002->1005
            Student edit_stu = list.Find((Student) => Student.Sno == 1002);
            edit_stu.Sno = 1005;
            edit_stu.printInfo();   // 输出更改后的信息
            // (3)删除一个学生
            Console.WriteLine("--------------------------\n删除第三个学生前的集合数据：");
            foreach(var stu in list)
            {
                stu.printInfo();
            }
            list.RemoveAt(2);
            Console.WriteLine("--------------------------\n删除第三个学生后的集合数据：");
            foreach (var stu in list)
            {
                stu.printInfo();
            }
            Console.WriteLine("--------------------------\n查询学号为1001的学生数据：");
            // (4)查询一个指定学号的学生->查询学号为1001的学生
            Student query_stu = list.Find((Student) => Student.Sno == 1001);
            query_stu.printInfo();
            Console.WriteLine("--------------------------\n遍历所有学生数据：");
            // (5)遍历所有学生
            foreach (var stu in list)
            {
                stu.printInfo();
            }
        }
    }
}
