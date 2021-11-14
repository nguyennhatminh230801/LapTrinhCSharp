using System;
using System.Collections.Generic;
using System.Text;
namespace NguyenNhatMinh_2019600285
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int choose = 5;

            List<SinhVien> danhSachSinhVien = new List<SinhVien>();
            while (true)
            {
                try
                {
                    Console.WriteLine("************************************");
                    Console.WriteLine("****Nguyễn Nhật Minh, 2019600285****");
                    Console.WriteLine("************************************");
                    Console.WriteLine("*1. Thêm Sinh Viên                 *");
                    Console.WriteLine("*2. Hiển Thị Danh Sách             *");
                    Console.WriteLine("*3. Xóa Sinh Viên                  *");
                    Console.WriteLine("*4. Kết Thúc                       *");
                    Console.WriteLine("************************************");
                    Console.Write("Mời bạn nhập lựa chọn: ");
                    choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            SinhVien sinhVien = new SinhVien();
                            Console.WriteLine("Nhập Thông Tin Sinh Viên: ");
                            sinhVien.Nhap();
                            ThemSinhVien(ref danhSachSinhVien, sinhVien);
                            break;

                        case 2:
                            HienThiDanhSach(danhSachSinhVien);
                            break;

                        case 3:
                            Console.Write("Nhập Mã Sinh Viên: ");
                            string maSV = Console.ReadLine();
                            XoaSinhVien(ref danhSachSinhVien,maSV);
                            break;

                        case 4:
                            Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình!!".ToUpper());
                            break;

                        default:
                            throw new Exception("Lựa Chọn Không Hợp Lệ".ToUpper());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            
        }

        public static void XoaSinhVien(ref List<SinhVien> danhSachSinhVien, string maSV)
        {
            SinhVien sinhVien = danhSachSinhVien.Find(sinhVien => sinhVien.MaSinhVien.ToLower().Equals(maSV.Trim().ToLower()));

            if(sinhVien == null)
            {
                throw new Exception("Không tìm được mã sinh viên này!!Xóa Thất Bại".ToUpper());
            }

            int choose2;

            do
            {
                Console.WriteLine("Bạn có chắc chắn muốn xóa Sinh Viên này không ?");
                Console.WriteLine("1. Có");
                Console.WriteLine("2. Không");
                Console.Write("Mời bạn nhập lựa chọn: ");
                choose2 = int.Parse(Console.ReadLine());
            } while (choose2 != 1 && choose2 != 2);
            
            if(choose2 == 2)
            {
                throw new Exception("Người dùng không chấp nhận xóa !!Xóa Thất Bại".ToUpper());
            }
            else
            {
                danhSachSinhVien.Remove(sinhVien);
                Console.WriteLine("Xóa sinh viên thành công".ToUpper());
            }
        }

        public static void HienThiDanhSach(List<SinhVien> danhSachSinhVien)
        {
            if(danhSachSinhVien.Count == 0)
            {
                throw new Exception("Danh sách này rỗng!!!".ToUpper());
            }

            Console.WriteLine($"{"MA SV",-20}{"HO TEN",-30}{"DIEN THOAI",-30}{"DIEM",-15}{"XEP LOAI",-15}");
            
            foreach (SinhVien sinhVien in danhSachSinhVien)
            {
                Console.WriteLine(sinhVien);
            }

            Console.WriteLine("Hiển thị danh sách thành công!!!".ToUpper());
        }

        public static void ThemSinhVien(ref List<SinhVien> danhSachSinhVien, SinhVien sinhVien)
        {
            foreach(SinhVien sinhVien1 in danhSachSinhVien)
            {
                if(sinhVien1.Equals(sinhVien))
                {
                    throw new Exception("Không cho phép thêm sinh viên trùng mã!!!".ToUpper());
                }
            }

            danhSachSinhVien.Add(sinhVien);
            Console.WriteLine("Thêm mới thành công".ToUpper());
        }
    }
}
