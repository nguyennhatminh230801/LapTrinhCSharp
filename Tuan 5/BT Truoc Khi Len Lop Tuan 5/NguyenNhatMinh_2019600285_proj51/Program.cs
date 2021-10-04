using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace NguyenNhatMinh_2019600285_proj51
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<ThiSinhA> danhSachThiSinhA = new List<ThiSinhA>();
            int choose = 7;

            while (true)
            {
                try
                {
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("===================QUẢN LÝ THÍ SINH==================");
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("=1. Nhập Thông Tin Sinh Viên                        =");
                    Console.WriteLine("=2. Hiển Thị Danh Sách Thí Sinh                     =");
                    Console.WriteLine("=3. Hiển Thị Các Sinh Viên Theo Tổng Điểm           =");
                    Console.WriteLine("=4. Hiển Thị Sinh Viên Theo Địa Chỉ                 =");
                    Console.WriteLine("=5. Tìm Kiếm Theo Số Báo Danh                       =");
                    Console.WriteLine("=6. Thoát Chương Trình                              =");
                    Console.WriteLine("=====================================================");
                    Console.Write("Nhập lựa chọn: ");
                    choose = int.Parse(Console.ReadLine());
                    Console.WriteLine("=====================================================");

                    switch(choose)
                    {
                        case 1:
                            Console.Clear();
                            NhapThongTinSinhVien(ref danhSachThiSinhA);
                            break;
                        case 2:
                            Console.Clear();
                            HienThiDanhSachSinhVien(danhSachThiSinhA);
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Nhập tổng điểm: ");
                            double TongDiem = double.Parse(Console.ReadLine());
                            HienThiDanhSachSinhVienTheoTongDiem(danhSachThiSinhA, TongDiem);
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Nhập địa chỉ: ");
                            string diaChi = Console.ReadLine().Trim();
                            HienThiDanhSachSinhVienTheoDiaChi(danhSachThiSinhA, diaChi);
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("Nhập số báo danh: ");
                            string soBaoDanh = Console.ReadLine().Trim();
                            TimKienSoBaoDanh(danhSachThiSinhA, soBaoDanh);
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Bạn muốn thoát chương trình?");
                            Console.WriteLine("1. Có");
                            Console.WriteLine("2. Không");
                            int choose3 = int.Parse(Console.ReadLine());

                            if(choose3 == 2)
                            {
                                choose = 7;
                            }

                            break;

                        default:
                            break;
                    }
                    
                    if(choose == 6)
                    {
                        break;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Bạn không được nhập sai kiểu số!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        public static void TimKienSoBaoDanh(List<ThiSinhA> danhSachThiSinhA, string soBaoDanh)
        {
            if (danhSachThiSinhA.Count == 0)
            {
                Console.WriteLine("Danh sách này rỗng".ToUpper());
                return;
            }

            ThiSinhA thiSinhA= danhSachThiSinhA.Find(element => element.SoBaoDanh.Trim().ToLower() == soBaoDanh.Trim().ToLower());

            if(thiSinhA == null)
            {
                Console.WriteLine("Không tìm được thí sinh này".ToUpper());
                return;
            }

            Console.WriteLine("Thông tin thí sinh: ".ToUpper());
            Console.WriteLine(thiSinhA);
        }

        public static void HienThiDanhSachSinhVienTheoDiaChi(List<ThiSinhA> danhSachThiSinhA, string diaChi)
        {
            if (danhSachThiSinhA.Count == 0)
            {
                Console.WriteLine("Danh sách này rỗng".ToUpper());
                return;
            }

            var query = (from thiSinhA in danhSachThiSinhA
                         where thiSinhA.DiaChi.Contains(diaChi)
                         select thiSinhA).ToList();

            if (query.Count == 0)
            {
                Console.WriteLine("Không có thí sinh nào ở nơi này".ToUpper());
                return;
            }

            HienThiDanhSachSinhVien(query);
        }

        public static void HienThiDanhSachSinhVienTheoTongDiem(List<ThiSinhA> danhSachThiSinhA, double tongDiem)
        {
            if (danhSachThiSinhA.Count == 0)
            {
                Console.WriteLine("Danh sách này rỗng".ToUpper());
                return;
            }

            var query = (from thiSinhA in danhSachThiSinhA
                        where thiSinhA.TongDiem >= tongDiem
                        select thiSinhA).ToList();
            
            if(query.Count == 0)
            {
                Console.WriteLine("Không có thí sinh nào vượt tổng điểm này".ToUpper());
                return;
            }

            HienThiDanhSachSinhVien(query);
        }

        public static void HienThiDanhSachSinhVien(List<ThiSinhA> danhSachThiSinhA)
        {
            if(danhSachThiSinhA.Count == 0)
            {
                Console.WriteLine("Danh sách này rỗng".ToUpper());
                return;
            }

            int i = 1;
            Console.WriteLine("danh sách thí sinh:".ToUpper());
            foreach (var item in danhSachThiSinhA)
            {
                Console.WriteLine($"Sinh viên thứ {i++}: ");
                Console.WriteLine(item);
            }
        }

        public static void NhapThongTinSinhVien(ref List<ThiSinhA> danhSachThiSinhA)
        {
            ThiSinhA thiSinhA = new ThiSinhA();
            Console.WriteLine("Nhập mới một thí sinh: ".ToUpper());
            thiSinhA.Nhap();

            int choose2 = 0;
            Console.WriteLine("\nBạn có lưu hay không ?");
            Console.WriteLine("1. Có");
            Console.WriteLine("2. Không");
            choose2 = int.Parse(Console.ReadLine());

            if(choose2 == 2)
            {
                return;
            }

            danhSachThiSinhA.Add(thiSinhA);
        }
    }
}
