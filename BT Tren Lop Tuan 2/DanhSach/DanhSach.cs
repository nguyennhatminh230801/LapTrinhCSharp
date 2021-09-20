using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanhSach
{
    class DanhSach
    {
        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            bool[] isPrime = Enumerable.Repeat(true, (int)1e4 + 5).ToArray();

            isPrime[0] = false;
            isPrime[1] = false;

            for (int i = 2; i * i <= (int)1e4; i++)
            {
                if (isPrime[i] == true)
                {
                    for (int p = i * i; p <= (int)1e4; p += i)
                    {
                        isPrime[p] = false;
                    }
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Nhập số lượng: ");
                    int n = int.Parse(Console.ReadLine());

                    List<int> array1 = new List<int>();

                    do
                    {
                        Console.Write("Nhập dãy số (trên cùng 1 dòng): ");
                        array1 = Console.ReadLine().Trim().Split(" ")
                            .Where(element => element.All(Char.IsDigit) && !String.IsNullOrWhiteSpace(element))
                            .Select(element => int.Parse(element)).ToList();
                    } while (array1.Count != n);

                    string DaySoLe = string.Join(",", array1 .Where(element => element % 2 == 1)
                        .Select(element => element.ToString())
                    );

                    string DaySoChan = string.Join(",", array1
                        .Where(element => element % 2 == 0)
                        .Select(element => element.ToString())
                    );

                    string DaySoNguyenTo = string.Join(",", array1
                        .Where(element => isPrime[element] == true)
                        .Select(element => element.ToString())
                    );

                    Console.WriteLine("Các số lẻ trong mảng: {0}", DaySoLe);
                    Console.WriteLine("Các số chẵn trong mảng: {0}", DaySoChan);
                    Console.WriteLine("Các số nguyên tố trong mảng: {0}", DaySoNguyenTo);
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
    }
}
