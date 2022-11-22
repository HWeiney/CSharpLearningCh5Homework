using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryForProj04
{
    public class Math : IMath
    {
        // 加
        public int add(int a, int b)
        {
            return a + b;
        }
        // 除
        public int divide(int a, int b)
        {
            return a / b;
        }
        // 乘
        public int multiply(int a, int b)
        {
            return a * b;
        }
        // 减
        public int subtract(int a, int b)
        {
            return a - b;
        }
    }
}
