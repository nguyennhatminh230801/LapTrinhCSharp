using System;
using System.Text;
using System.Collections.Generic;

namespace _3._Tinh_Toan
{
    class TinhToan
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<char> sequence = new List<char>(){ '+', '-', '*', '/'};

            while (true)
            {
                try
                {
                    Console.Write("Nhập A: ");
                    double a = double.Parse(Console.ReadLine().Trim());
                    Console.Write("Nhập B: ");
                    double b = double.Parse(Console.ReadLine().Trim());
                    Console.Write("Nhập ký tự (+ , - , * , /): ");
                    char c = char.Parse(Console.ReadLine().Trim());

                    if (!sequence.Contains(c))
                    {
                        throw new Exception("Không đúng định dạng!!!");
                    }

                    switch (c)
                    {
                        case '+':
                            Console.WriteLine("{0:F3} + {1:F3} = {2:F3}", a, b, a + b);
                            break;

                        case '-':
                            Console.WriteLine("{0:F3} - {1:F3} = {2:F3}", a, b, a - b);
                            break;

                        case '*':
                            Console.WriteLine("{0:F3} * {1:F3} = {2:F3}", a, b, a * b);
                            break;

                        case '/':
                            Console.WriteLine("{0:F3} / {1:F3} = {2:F3}", a, b, a / b);
                            break;
                    }
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
