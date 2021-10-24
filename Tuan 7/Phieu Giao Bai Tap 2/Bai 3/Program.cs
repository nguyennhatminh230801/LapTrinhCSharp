using System;
using System.Text;

namespace Bai_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Func<double, double> TinhHoaHong = Solve;

            Console.Write("Nhập vào số tiền: ");
            Console.WriteLine($"Số tiền hưởng là : {TinhHoaHong(double.Parse(Console.ReadLine()))}");
        }

        public static double Solve(double money)
        {
            if (money < 1000)
            {
                return 0;
            }
            else if (money >= 1000 && money <= 3000)
            {
                return money / 20d;
            }
            else
            {
                return money / 10d;
            }
        }
    }
}
