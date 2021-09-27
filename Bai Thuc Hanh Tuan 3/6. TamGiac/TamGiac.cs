using System;
using System.Text;

namespace _6._TamGiac
{
    class TamGiac
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
                    Console.Write("Nhập A: ");
                    float a = float.Parse(Console.ReadLine());
                    Console.Write("Nhập B: ");
                    float b = float.Parse(Console.ReadLine());
                    Console.Write("Nhập C: ");
                    float c = float.Parse(Console.ReadLine());

                    if (a + b > c && a + c > b && b + c > a)
                    {
                        float perimeter = a + b + c;
                        float halfP = perimeter / 2;

                        float area = (float)Math.Sqrt(halfP * (halfP - a) * (halfP - b) * (halfP - c));

                        Console.WriteLine("Diện tích là: {0}" +
                                          "\nChu vi là: {1}", area, perimeter);
                        break;
                    }
                    else
                    {
                        throw new Exception("Không thể tạo thành 1 tam giác");
                    }
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
        }
    }
}
