using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _2._TachDay
{
    class TachDay
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập dãy số trên cùng 1 dòng: ");
                    List<int> array1 = Console.ReadLine().Trim().Split(" ")
                        .Select(element => int.Parse(element)).ToList();

                    Console.WriteLine("Dãy chẵn gồm: {0}", string.Join(",", array1.Where(element => element % 2 == 0)
                        .Select(element => element.ToString()).ToArray()));
                    Console.WriteLine("Dãy lẻ gồm: {0}", string.Join(",", array1.Where(element => element % 2 == 1)
                        .Select(element => element.ToString()).ToArray()));
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
