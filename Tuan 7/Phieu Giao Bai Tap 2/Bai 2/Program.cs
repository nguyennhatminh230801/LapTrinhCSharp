using System;
using System.Text;

namespace Bai_2
{
    class Program
    {
        public delegate void HienThiThongBao(double diem);
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    HienThiThongBao hienThiThongBao = DiemChu;
                    hienThiThongBao += XepLoaiHocLuc;

                    Console.Write("Nhap vao diem: ");
                    hienThiThongBao(double.Parse(Console.ReadLine()));
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        public static void DiemChu(double diem)
        {
            string str1;

            if (diem <= 10 && diem >= 8.5)
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

        public static void XepLoaiHocLuc(double diem)
        {
            string str1;

            if (diem <= 10 && diem >= 8)
            {
                str1 = "Giỏi";
            }
            else if (diem < 8 && diem >= 6.5)
            {
                str1 = "Khá";
            }
            else if (diem < 6.5 && diem >= 5)
            {
                str1 = "Trung Bình";
            }
            else if (diem < 5 && diem >= 3.5)
            {
                str1 = "Yếu";
            }
            else
            {
                str1 = "Kém";
            }

            Console.WriteLine(str1);
        }
    }
}
