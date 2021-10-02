using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CauTruc
{
    class CauTruc
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    List<HocSinh> danhSachHocSinh = new List<HocSinh>();

                    for (int i = 1; i <= 5; i++)
                    {
                        HocSinh hocSinh = new HocSinh();
                        Console.Write("Nhập Họ Tên: ");
                        hocSinh.hoTen = Console.ReadLine().Trim();
                        Console.Write("Nhập Tuổi: ");
                        hocSinh.tuoi = int.Parse(Console.ReadLine());
                        Console.Write("Nhập Giới Tính: ");
                        string res = Console.ReadLine().Trim().ToLower();

                        if (res.Equals("nam"))
                        {
                            hocSinh.gioiTinh = true;
                        }
                        else
                        {
                            hocSinh.gioiTinh = false;
                        }

                        danhSachHocSinh.Add(hocSinh);
                    }

                    int TongSoTuoi = danhSachHocSinh.Select(element => element.tuoi).Sum();

                    Console.WriteLine("Tổng số tuổi: {0}", TongSoTuoi);
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
