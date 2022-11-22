using ClassLibraryForProj04;
using System;
using System.Reflection;
/*
使用反射技术实现：
1、新建一个类库IMath，包含数学计算接口（加减乘除）
2、新建一个类库Math，实现Imath类库中的接口->见ClassLibraryForProj04类库
3、新建一个控制台应用程序，引用Imath类库，使用反射技术实现基于Imath接口的编程。
 */
namespace Project04
{
    class Program
    {
        //默认加载根目录下面DLL
        public static Assembly ass = Assembly.Load("ClassLibraryForProj04");
        public static void getModules()
        {
            Console.WriteLine("获取所有模块");
            foreach (var item in ass.GetModules())
            {
                Console.WriteLine(item.FullyQualifiedName);
            }
        }
        public static void getTypes()
        {
            Console.WriteLine("-------------------------\n获取属性, 方法, 字段");
            foreach (var item in ass.GetTypes())
            {
                //获取DLL中所有的命名空间
                Console.WriteLine("-------------------------\n" + item.FullName);
                foreach (var sub in item.GetProperties()) //公开属性
                {
                    Console.WriteLine(item.Name + "公开属性:" + sub.Name);
                }
                foreach (var sub in item.GetMethods()) //公开方法
                {
                    Console.WriteLine(item.Name + "公开方法:" + sub.Name);
                }
                foreach (var sub in item.GetFields()) //公开字段
                {
                    Console.WriteLine(item.Name + "公开字段:" + sub.Name);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("20软一：202100838\n--------------------------");
            
            getModules(); // 获取DLL下所有模块

            getTypes(); // 获取属性, 方法, 字段

            // 3、新建一个控制台应用程序，引用Imath类库，使用反射技术实现基于Imath接口的编程。
            Console.WriteLine("------------------------\n用反射技术实现基于Imath接口的编程");

            // 获取指定实现接口的类，该名称可以在接口文档指定
            Type t1 = ass.GetType("ClassLibraryForProj04.Math");

            // 使用Activator.CreateInstance调用实现类生成接口实例。
            IMath m = (IMath)Activator.CreateInstance(t1);
            Console.WriteLine("加："+m.add(1, 2).ToString());
            Console.WriteLine("减："+m.subtract(5, 3).ToString());
            Console.WriteLine("乘："+m.multiply(4, 5).ToString());
            Console.WriteLine("除："+m.divide(9, 3).ToString());
        }
    }
}
