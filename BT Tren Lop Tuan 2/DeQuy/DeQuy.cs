using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DeQuy
{
    class DeQuy
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

                    List<Int64> fibonacci, factorial;

                    fibonacci = Enumerable.Repeat((Int64)0, n).ToList();
                    factorial = Enumerable.Repeat((Int64)0, n).ToList();

                    //Vì để Static nên các phương thức này không cần đối tượng để sử dụng
                    Fibonacci(ref fibonacci, n - 1);
                    GiaiThua(ref factorial, n - 1);

                    Console.WriteLine("Dãy fibonacci cần tìm là: {0}", 
                        string.Join(",", fibonacci.Select(phanTu => phanTu.ToString())));
                    Console.WriteLine("Số thứ {0} là: {1}", n, factorial[n - 1]);
                    break;
                }
                catch (FormatException)
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

        public static Int64 Fibonacci(ref List<Int64> fibonacci, int n)
        {
            if(fibonacci[n] != 0)
            {
                return fibonacci[n];
            }

            if(n < 2)
            {
                fibonacci[n] = n;
                return fibonacci[n];
            }
            else
            {
                fibonacci[n] = Fibonacci(ref fibonacci,n - 1) + Fibonacci(ref fibonacci, n - 2);
                return fibonacci[n];
            }
        }

        public static Int64 GiaiThua(ref List<Int64> factorial, int n)
        {
            if(factorial[n] != 0)
            {
                return factorial[n];
            }

            if(n != 0)
            {
                factorial[n] = (n + 1) * GiaiThua(ref factorial, n - 1);
                return factorial[n];
            }
            else
            {
                factorial[0] = 1;
                return factorial[0];
            }
        }
    }
}
