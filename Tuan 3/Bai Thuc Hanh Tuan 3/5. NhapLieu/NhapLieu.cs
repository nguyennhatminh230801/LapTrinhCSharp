using System;
using System.Text;

namespace _5._NhapLieu
{
    class NhapLieu
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    //Nhập While
                    int number = 0;

                    while (number < 1 || number > 100)
                    {
                        Console.Write("Nhập số: ");
                        number = int.Parse(Console.ReadLine());

                        if (number < 1 || number > 100)
                        {
                            Console.WriteLine("Yêu cầu nhập lại!!!");
                        }
                    }

                    Console.WriteLine("Số bạn vừa nhập: {0}", number);

                    //Nhập do...while
                    int number1 = 0;

                    do
                    {
                        Console.Write("Nhập số: ");
                        number1 = int.Parse(Console.ReadLine());

                        if (number1 < 1 || number1 > 100)
                        {
                            Console.WriteLine("Yêu cầu nhập lại!!!");
                        }
                    } while (number1 < 1 || number1 > 100);

                    Console.WriteLine("Số bạn vừa nhập: {0}", number1);
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
