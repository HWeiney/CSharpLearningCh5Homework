using System;
using System.Collections.Generic;
using System.Text;

namespace Project01
{
    public class Student
    {
        private int sno;    // 学号
        private String sname;  // 姓名
        public Student() { }
        public Student(int sno, String sname)
        {
            this.sno = sno;
            this.sname = sname;
        }
        public int Sno
        {
            set { this.sno = value; }
            get { return this.sno; }
        }
        public String Sname
        {
            set { this.sname = value; }
            get { return this.sname; }
        }
        public List<Student> initStu_list()
        {
            // 初始化一些学生对象
            Student stu1 = new Student(1001, "han");
            Student stu2 = new Student(1002, "weiney");
            Student stu3 = new Student(1003, "20ruanyi");
            // 初始化List集合
            List<Student> list = new List<Student>();
            // (1)增加一个学生
            list.Add(stu1);

            list.Add(stu2);
            list.Add(stu3);
            return list;
        }
        public void printInfo()
        {
            Console.WriteLine("[{\"Sno\":"+this.sno+","+this.sname+":\"han\"}]");
        }
    }
}
