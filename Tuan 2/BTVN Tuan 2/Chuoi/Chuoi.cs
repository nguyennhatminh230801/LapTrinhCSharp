using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chuoi
{
    class Chuoi
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập Chuỗi:");
                    string s = Console.ReadLine();

                    Console.WriteLine("Các chữ: ");
                    foreach (var item in s)
                    {
                        Console.WriteLine(item);
                    }

                    string[] array1 = s.Split(" ");

                    Console.WriteLine("Các từ: ");
                    foreach (var item in array1)
                    {
                        Console.WriteLine(item);
                    }

                    HashSet<char> set1 = new HashSet<char>(s.ToCharArray());
                    
                    Console.WriteLine("Số lần xuất hiện các ký tự: ");
                    foreach (var item in set1)
                    {
                        int count1 = s.Count(element => element == item);
                        Console.WriteLine("{0} : {1}", item, count1);
                    }

                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn phải nhập dạng số!!!");
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
