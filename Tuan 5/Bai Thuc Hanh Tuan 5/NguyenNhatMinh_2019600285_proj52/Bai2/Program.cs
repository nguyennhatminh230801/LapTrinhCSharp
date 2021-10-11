using System;
using System.Text;

namespace Bai2
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
                    PhuongTrinhBac2 phuongTrinhBac2 = new PhuongTrinhBac2(2, 4, 2);
                    Console.WriteLine("Kết quả là: {0}", phuongTrinhBac2.Giai());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Không được sai định dạng số");
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
