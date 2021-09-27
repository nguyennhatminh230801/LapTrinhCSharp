using System;
using System.Text;

namespace HelloWorld
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.WriteLine("Hãy nhập vào 2 số: ");
                    Console.Write("a = ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("b = ");
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn không được nhập sai kiểu số!!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }
    }
}
