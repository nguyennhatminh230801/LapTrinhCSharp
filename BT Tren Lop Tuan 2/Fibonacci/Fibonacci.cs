using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Fibonacci
{
    class Fibonacci
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

                    if(n <= 0)
                    {
                        throw new Exception("Mảng không thể bé hơn 0");
                    }
                    //lấp đầy mảng với 0
                    List<int> Fibonacci = Enumerable.Repeat(0, n).ToList();

                    Fibonacci[1] = 1;

                    if (n > 2)
                    {
                        for (int i = 2; i < n; i++)
                        {
                            Fibonacci[i] = Fibonacci[i - 1] + Fibonacci[i - 2];
                        } 
                    }

                    Console.Write("Dãy fibonacci cần tìm là: {0}", string.Join(",", Fibonacci.Select(phanTu => phanTu.ToString())));
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Bạn phải nhập vào dạng số!!");
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
