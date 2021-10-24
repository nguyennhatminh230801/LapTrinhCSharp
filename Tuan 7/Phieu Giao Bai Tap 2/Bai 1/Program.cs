using System;
using System.Text;
namespace Bai_1
{
    class Program
    {
        public delegate void HienThiThongBao(double so);
        
        static void Main(string[] args)
        {
            try
            {
                Console.InputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;

                HienThiThongBao hienThiThongBao = DiemChu;
                Console.Write("Nhap vao diem: ");
                hienThiThongBao(double.Parse(Console.ReadLine()));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void DiemChu(double diem)
        {
            string str1;

            if(diem <= 10 && diem >= 8.5)
            {
                str1 = "A";
            }
            else if (diem < 8.5 && diem >= 7)
            {
                str1 = "B";
            }
            else if (diem < 7 && diem >= 5.5)
            {
                str1 = "C";
            }
            else if (diem < 5.5 && diem >= 4)
            {
                str1 = "D";
            }
            else
            {
                str1 = "F";
            }

            Console.WriteLine(str1);
        }
    }
}
