using System;
using System.Collections.Generic;
using System.Linq;

namespace NguyenNhatMinh_2019600285
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose = 5;
            //Alt + Enter
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            while (true)
            {
                try
                {
                    Console.WriteLine("quan ly nhan vien".ToUpper());
                    Console.WriteLine("1. Them nhan vien");
                    Console.WriteLine("2. Hien Thi Danh Sach");
                    Console.WriteLine("3. Sap Xep Theo Luong");
                    Console.WriteLine("4. Thoat Chuong Trinh\n");
                    Console.WriteLine("Nhap lua chon cua ban: ");
                    choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 1:
                            ThemNhanVien(ref danhSachNhanVien);
                            break;

                        case 2:
                            HienThiDanhSach(danhSachNhanVien);
                            break;

                        case 3:
                            SapXepTheoLuong(ref danhSachNhanVien);
                            break;

                        case 4:
                            break;

                        default:
                            break;
                    }

                    if (choose == 4)
                    {
                        break; //Dung chuong Trinh
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }

        }

        private static void SapXepTheoLuong(ref List<NhanVien> danhSachNhanVien)
        {
            danhSachNhanVien.Sort();

            //var query = (from elem in danhSachNhanVien
                         //orderby elem.TinhLuongNhanVien() ascending
                         //select elem).ToList();

            Console.WriteLine("sap xep thanh cong".ToUpper());
        }

        private static void HienThiDanhSach(List<NhanVien> danhSachNhanVien)
        {
            Console.WriteLine("{0,-15}{1,-30}{2,-30}{3,-15}{4,-30}{5,-30}", "Ma NV", "Ho Ten", "Chuc Vu", "HS Luong", "Dia Chi", "Luong");
            foreach (var item in danhSachNhanVien)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("da hien thi het danh sach".ToUpper());
        }

        private static void ThemNhanVien(ref List<NhanVien> danhSachNhanVien)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.Nhap();

            //int index = danhSachNhanVien.IndexOf(nhanVien);

            ////bi trung
            //if(index != -1)
            //{
            //    throw new Exception("Ban khong duoc nhap trung ma nhan vien");
            //}

            foreach (var item in danhSachNhanVien)
            {
                if (nhanVien.Equals(item))
                {
                    throw new Exception("Ban khong duoc nhap trung ma nhan vien");
                }
            }

            danhSachNhanVien.Add(nhanVien);

            Console.WriteLine("Them Thanh Cong".ToUpper());
            //NhanVien nhanVien1 = danhSachNhanVien.Find(element => element.HoTen.Equals(nhanVien.HoTen));

            //if(nhanVien1 != null)
            //{
            //    throw new Exception("Ban khong duoc nhap trung ma nhan vien");
            //}

            //List<NhanVien> danhSachtam = (from nhanVien2 in danhSachNhanVien
            //                             where nhanVien2.HoTen.Equals(nhanVien.HoTen)
            //                             select nhanVien2).ToList();
        }
    }
}
