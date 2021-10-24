using System;
using System.Text;

namespace Bai_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Action<string, double> hienThi = (name, salary) =>
                    {
                        double res1;

                        if (salary < 5000000)
                        {
                            res1 = salary / 20;
                        }
                        else if (salary > 5000000 && salary <= 10000000)
                        {
                            res1 = (salary / 10) - 250000;
                        }
                        else
                        {
                            res1 = (salary / 5) - 750000;
                        }

                        Console.WriteLine($"Tên: {name}" +
                            $"\nThuế Phải Nộp: {res1}");
                    };

                    Console.Write("Nhập vào tên: ");
                    string name = Console.ReadLine();
                    Console.Write("Nhập vào số tiền: ");
                    double money = double.Parse(Console.ReadLine());

                    hienThi(name, money);
                    break;
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
