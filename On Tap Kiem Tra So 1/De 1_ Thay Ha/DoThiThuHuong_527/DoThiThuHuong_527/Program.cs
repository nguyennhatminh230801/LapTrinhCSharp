using System;
using System.Collections.Generic;

namespace DoThiThuHuong_527
{
    class Program
    {
        static void Main(string[] args)
        {
            int choose = 6;
            List<NhanVien> nhanViens = new List<NhanVien>();

            do
            {
                Console.WriteLine("quan ly nhan vien".ToLower());
                Console.WriteLine("1. Them nhan vien");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Sap Xep");
                Console.WriteLine("4. Thoat\n");
                Console.WriteLine("Moi ban nhap lua chon: ");
                choose = int.Parse(Console.ReadLine());

                switch(choose)
                {
                    case 1:
                        ThemNhanVien(ref nhanViens);
                        break;
                    case 2:
                        HienThiDanhSach(nhanViens);
                        break;
                    case 3:
                        SapXep(ref nhanViens);
                        break;
                    case 4:
                        break;

                    default:
                        break;
                }
            } while (choose != 4);
        }

        private static void SapXep(ref List<NhanVien> nhanViens)
        {
            if (nhanViens.Count == 0)
            {
                Console.WriteLine("Danh sach nay khong co nhan vien".ToUpper());
                return;
            }

            nhanViens.Sort();
            Console.WriteLine("Sap xep thanh cong".ToUpper());
        }

        private static void HienThiDanhSach(List<NhanVien> nhanViens)
        {
            if (nhanViens.Count == 0)
            {
                Console.WriteLine("Danh sach nay khong co nhan vien".ToUpper());
                return;
            }

            Console.WriteLine("danh sach nhan vien".ToUpper());
            Console.WriteLine("{0,-10} {1,-30} {2,-30} {3,-30} {4,-30} {5,-30}", "Ho Ten", "Dia Chi", "Ma Nhan Vien", "Chuc Vu", "Luong Co Ban", "He So Chuc Vu");
            foreach (var item in nhanViens)
            {
                item.Xuat();
            }
        }

        private static void ThemNhanVien(ref List<NhanVien> nhanViens)
        {
            Console.WriteLine("Nhap thong tin nhan vien: ");
            NhanVien nhanVien = new NhanVien();
            nhanVien.Nhap();

            nhanViens.Add(nhanVien);
            Console.WriteLine("Them moi thanh cong".ToUpper());
        }
    }
}
