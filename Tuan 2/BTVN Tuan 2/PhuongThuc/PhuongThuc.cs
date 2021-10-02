using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhuongThuc
{
    class PhuongThuc
    {
            
        static void Main(string[] args)
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

                    List<int> array1;

                    do
                    {
                        Console.Write("Nhập dãy số(trên cùng 1 chiều): ");
                        array1 = Console.ReadLine().Trim().Split(" ").Select(elem => int.Parse(elem)).ToList();
                    } while (array1.Count != n);

                    string check1 = string.Join(",", array1.Where(elem => isPrime[elem] == true)
                        .Select(elem => elem.ToString()).ToArray());

                    Console.WriteLine("Dãy số nguyên tố: {0}", check1);
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
