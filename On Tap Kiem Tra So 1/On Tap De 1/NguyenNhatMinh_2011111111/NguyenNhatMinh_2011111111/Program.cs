using System;
using System.Collections.Generic;

namespace NguyenNhatMinh_2011111111
{
    //Tao 1 class moi , Shift + Alt + C
    class Program
    {
        static void Main(string[] args)
        {
            int choose = 7;
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            while (true)
            {
                try
                {
                    Console.WriteLine("quan ly nhan vien".ToUpper());
                    Console.WriteLine("1. Them nhan vien");
                    Console.WriteLine("2. Hien thi danh sach");
                    Console.WriteLine("3. Sap Xep");
                    Console.WriteLine("4. Tim Kiem");
                    Console.WriteLine("5. Chen");
                    Console.WriteLine("6. Xoa");
                    Console.WriteLine("7. Thoat\n");
                    Console.WriteLine("Moi ban nhap lua chon: ");
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
                            SapXep(ref danhSachNhanVien);
                            break;

                        case 4:
                            TimKiem(danhSachNhanVien);
                            break;

                        case 5:
                            Chen(ref danhSachNhanVien);
                            break;

                        case 6:
                            Xoa(ref danhSachNhanVien);
                            break;

                        case 7:
                            break;
                        default:
                            break;
                    }

                    if(choose == 7)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        private static void Xoa(ref List<NhanVien> danhSachNhanVien)
        {
            Console.WriteLine("Nhap Ma Nhan Vien Can Tim Kiem: ");
            string MaNV = Console.ReadLine();

            NhanVien nhanVien = danhSachNhanVien.Find(elem => elem.MaNhanVien == MaNV);

            if(nhanVien == null)
            {
                Console.WriteLine("khong tim duoc nhan vien nay".ToUpper());
            }
            danhSachNhanVien.Remove(nhanVien);

            Console.WriteLine("Xoa thanh cong".ToUpper());
        }

        private static void Chen(ref List<NhanVien> danhSachNhanVien)
        {
            Console.WriteLine("Nhap thong tin nhan vien: ");
            NhanVien nhanVien = new NhanVien();
            nhanVien.Nhap();

            int vitriChen = -1;
            do
            {
                Console.WriteLine("Nhap vi tri chen:");
                vitriChen = int.Parse(Console.ReadLine());

                if (vitriChen < 0 || vitriChen > danhSachNhanVien.Count)
                {
                    Console.WriteLine("Yeu cau nhap lai".ToUpper());
                }
            } while (vitriChen < 0 || vitriChen > danhSachNhanVien.Count);

            danhSachNhanVien.Insert(vitriChen, nhanVien);

            Console.WriteLine("chen thanh cong".ToUpper());
        }

        private static void TimKiem(List<NhanVien> danhSachNhanVien)
        {
            Console.WriteLine("Nhap Ma Nhan Vien Can Tim Kiem: ");
            string MaNV = Console.ReadLine();

            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNhanVien = MaNV;

            foreach (var item in danhSachNhanVien)
            {
                if(nhanVien.Equals(item))
                {
                    Console.WriteLine("Da Tim Thay Nhan Vien Nay".ToUpper());
                    Console.WriteLine("Thong Tin Nhan Vien".ToUpper());
                    Console.WriteLine($"{"MA NV",-20} {"HO TEN",-30} {"DIA CHI",-30} {"CHUC VU",-30} {"LUONG CO BAN",-20} {"HS CHUC VU",-20}");
                    Console.WriteLine(item);
                    return; 
                }
            }

            Console.WriteLine("Khong co nhan vien nay".ToUpper());
        }

        private static void SapXep(ref List<NhanVien> danhSachNhanVien)
        {
            danhSachNhanVien.Sort();
            Console.WriteLine("sap xep danh sach thanh cong".ToUpper());
        }

        private static void HienThiDanhSach(List<NhanVien> danhSachNhanVien)
        {
            Console.WriteLine($"{"MA NV",-20} {"HO TEN",-30} {"DIA CHI",-30} {"CHUC VU",-30} {"LUONG CO BAN",-20} {"HS CHUC VU",-20}");
            foreach (var item in danhSachNhanVien)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Da hien thi het danh sach".ToUpper());
        }

        private static void ThemNhanVien(ref List<NhanVien> danhSachNhanVien)
        {
            Console.WriteLine("Nhap thong tin nhan vien: ");
            NhanVien nhanVien = new NhanVien();
            nhanVien.Nhap();

            foreach (var item in danhSachNhanVien)
            {
                if(nhanVien.Equals(item))
                {
                    throw new Exception("Da ton tai ma nhan vien nay !!");
                }
            }

            //Add them 1 phan tu vao list
            danhSachNhanVien.Add(nhanVien);

            Console.WriteLine("Them moi thanh cong".ToUpper());
        }
    }
}
