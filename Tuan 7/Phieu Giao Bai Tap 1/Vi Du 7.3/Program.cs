using System;

namespace Vi_Du_7._3
{
    class Program
    {
        private delegate void HienThiThongBao(string thongBao);
        static void Main(string[] args)
        {
            HienThiThongBao del1 = ThongBaoLoi;

            HienThiThongBao del2 = GuiThongDiep;
            HienThiThongBao multiDel;

            multiDel = del1 + del2;

            HienThiThongBao del3 = CanhBao;
            multiDel += del3;

            multiDel += CanhBao;
            multiDel += CanhBao;


            multiDel -= del2;

            multiDel("ABC");

            Console.ReadLine();
        }

        private static void ThongBaoLoi(string loi)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nChuong trinh cua ban co loi bien dich sau: {0}", loi);
            Console.ResetColor();
        }

        static void GuiThongDiep(string ten)
        {
            Console.WriteLine("\nThong  diep  da  duoc  gui  cho:  {0}", ten);
        }

        static void CanhBao(string phienBan)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBan  nen  dung  phien  ban  {0}", phienBan);
            Console.ResetColor();
        }
    }
}
