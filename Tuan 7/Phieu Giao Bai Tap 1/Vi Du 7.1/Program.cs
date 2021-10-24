using System;

namespace Phieu_Bai_Tap_1
{
    class Program
    {
        public delegate void ThongBao(string message);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ThongBao thongBao = ThongBaoLoi;
            thongBao("thieu ;");
        }

        public static void ThongBaoLoi(string loi)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nChuong Trinh Ban Co Loi Bien Dich Sau: {0}");
            Console.ResetColor();
        }
    }
}
