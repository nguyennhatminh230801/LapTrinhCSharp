using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7._Mang
{
    class Mang
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
                    Console.WriteLine("Nhập mảng số nguyên trên cùng 1 dòng: ");
                    List<int> array1 = Console.ReadLine().Trim().Split(" ")
                        .Where(element => !String.IsNullOrWhiteSpace(element) && element != "-")
                        .Select(element => int.Parse(element))
                        .ToList();

                    Console.WriteLine("Tổng phần tử lẻ: {0}", array1.Where(element => element % 2 == 1).Sum());
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
        }
    }
}
