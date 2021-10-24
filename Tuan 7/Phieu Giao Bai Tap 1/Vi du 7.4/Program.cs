using System;

namespace Vi_du_7._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSU  DUNG  FUNC");

            Func<int, int, int> del1 = Cong2So;

            Console.WriteLine("\n{0}  +  {1}  =  {2}", 3, 5, del1(3, 5));

            Console.WriteLine("\nSU  DUNG  ACTION");

            Action<double> del2 = XepLoaiHocSinh;

            del2(7.5);

            Console.ReadLine();
        }

        public static int Cong2So(int a, int b)
        {
            return a + b;
        }

        public static void XepLoaiHocSinh(double diemTB)
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
        }

    }
}
