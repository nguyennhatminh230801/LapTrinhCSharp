using System;

namespace Vi_Du_7._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSu  dung  FUNC  va  PHUONG  THUC  VO  DANH");

            Func<int, int, int> del1 = delegate (int x, int y)
            {
                return x + y;
            };

            Console.WriteLine("\n{0}  +  {1}  =  {2}", 2, 4, del1(2, 4));

            Console.WriteLine("\nSu  dung  ACTION  va  BIEU  THUC  LAMBDA");

            Action<double> del2 = (double diemTB) =>
            {
                if (diemTB >= 8)
                    Console.WriteLine("\nHoc  sinh  dat  loai:  Gioi");
                else if (diemTB >= 6.5)
                    Console.WriteLine("\nHoc  sinh  dat  loai:  Kha");
                else if (diemTB >= 5)
                    Console.WriteLine("\nHoc  sinh  dat  loai:  Trung  binh");
                else if (diemTB >= 3.5)
                    Console.WriteLine("\nHoc  sinh  dat  loai:  Yeu");
                else
                    Console.WriteLine("\nHoc  sinh  dat  loai:  Kem");
            };

            del2(9);

            Console.ReadLine();
        }

    }

}
