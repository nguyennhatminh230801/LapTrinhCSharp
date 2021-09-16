using System;
using System.Text;

namespace TongChuoi
{
    class TongChuoi
    {
        static void Main(string[] args)
        {
            //Tieng Viet
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập N: ");
                    Int32 n = Int32.Parse(Console.ReadLine());

                    Int32 tong1 = 0;
                    float tong2 = 0;

                    for (Int32 i = 1; i <= n; i++)
                    {
                        tong1 += i;
                        tong2 += (1 / (float)i);
                    }

                    Console.WriteLine("Tổng 1: {0}" +
                                      "\nTổng 2: {1}", tong1, tong2);
                    break;
                }
                catch (FormatException) //Không thể Parse số
                {
                    Console.WriteLine("Số bạn nhập vào không đúng!!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine("Kết thúc chương trình");
            Console.ReadKey(true);
        }
    }
}
