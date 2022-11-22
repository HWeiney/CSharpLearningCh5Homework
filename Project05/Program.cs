using System;
using System.Threading.Tasks;

namespace Project05
{
    public class Calculate {
        public int a {set;get; }
        public int b {set;get; }
        public double result_a { set; get; } 
        public double result_b { set; get; } 
        public Calculate(int a, int b)
        {
            this.a = a;
            this.b = b;
            this.result_a = a;
            this.result_b = b;
        }
        public async Task printResult()
        {
            Task task0 = cal01();
            Task task1 = cal02();
            await task0;
            await task1;
        }
        public async Task cal01()
        {
            double[] array = new double[100];
            array[0] = a;
            for (int i = 1; i < 58; i++) 
            {
                array[i] = array[i - 1] * a;
            }
            for(int j = 0; j < 58; j++)
            {
                Console.WriteLine("a^{0}={1:F0}", j+1, array[j]);
                await Task.Delay(100);
            }
            result_a = array[57];

        }
        public async Task cal02()
        {
            double[] array = new double[100];
            array[0] = b;
            for (int i = 1; i < 50; i++)
            {
                array[i] = array[i - 1] * b;
            }
            for (int j = 0; j < 50; j++)
            {
                Console.WriteLine("b^{0}={1:F0}", j + 1, array[j]);
                await Task.Delay(100);
            }
            result_b = array[49];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------202100838--------------");
            Console.WriteLine("计算a^58+b^50，a和b均在1-10内：");
            Console.Write("请输入a：");
            int a = int.Parse(Console.ReadLine());
            Console.Write("请输入b：");
            int b = int.Parse(Console.ReadLine());
            Calculate cal = new Calculate(a, b);
            cal.printResult().Wait();
            Console.WriteLine("------------202100838--------------");
            Console.WriteLine("a^58+b^50 = {0:F0} + {1:F0} = {2:F0}", cal.result_a,cal.result_b,cal.result_a+cal.result_b);
        }
    }
}
