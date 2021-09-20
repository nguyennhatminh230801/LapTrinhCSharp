using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiaiThua
{
    class GiaiThua
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập N: ");
                    Int32 n = Int32.Parse(Console.ReadLine());

                    if (n <= 0)
                    {
                        throw new Exception("Mảng không thể bé hơn 0");
                    }
                    //lấp đầy mảng với 1
                    List<int> Factorial = Enumerable.Repeat(1, n + 1).ToList();
                    
                    for(int i = 1; i <= n; i++)
                    {
                        Factorial[i] = Factorial[i - 1] * i;
                    }

                    Console.WriteLine("Số fibonacci thứ {0} là: {1}", n, Factorial[n]);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn phải nhập vào dạng số");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
