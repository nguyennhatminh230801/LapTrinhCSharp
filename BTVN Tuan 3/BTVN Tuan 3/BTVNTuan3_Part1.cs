using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BTVN_Tuan_3
{
    //partial: chia 1 class sao cho có thể viết code ở nhiều nơi miễn là cùng namespace
    public partial class BTVNTuan3
    {
        //Những cài đặt chi tiết để ở file Part 2

        public static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> danhSachSinhVien = new List<Student>();
            //File lưu ở Debug
            const string path = "Student.txt";
            try
            {
                DocFile(ref danhSachSinhVien, path);
                int choose = 9;

                while (true)
                {
                    Console.WriteLine("\n===============================================");
                    Console.WriteLine("==============QUẢN LÝ SINH VIÊN================");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("= 1. Thêm Sinh Viên                           =");
                    Console.WriteLine("= 2. Cập Nhật Thông Tin Sinh Viên Bởi ID      =");
                    Console.WriteLine("= 3. Xóa Sinh Viên Bởi ID                     =");
                    Console.WriteLine("= 4. Tìm kiếm Sinh Viên theo tên              =");
                    Console.WriteLine("= 5. Sắp xếp Sinh Viên Theo Điểm Trung Bình   =");
                    Console.WriteLine("= 6. Sắp xếp Sinh Viên Theo Tên               =");
                    Console.WriteLine("= 7. Hiển Thị Danh Sách Sinh Viên             =");
                    Console.WriteLine("= 8. Ghi Danh Sách Vào File \"Student.txt\"     =");
                    Console.WriteLine("= 0. Thoát                                    =");
                    Console.WriteLine("===============================================");
                    Console.Write("Mời bạn nhập lựa chọn:");
                    choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Bạn muốn thoát chương trình (Yes/No) ?: ");
                            string request = Console.ReadLine().Trim().ToLower();

                            if (request == "yes")
                            {
                                choose = -1;
                            }
                            else
                            {
                                choose = 9;
                            }
                            break;
                        case 1:
                            Console.Clear();
                            ThemSinhVien(ref danhSachSinhVien);
                            break;

                        case 2:
                            Console.Clear();
                            Console.Write("Nhập ID: ");
                            int id = int.Parse(Console.ReadLine());
                            string status = CapNhatThongTinSinhVienBoiID(ref danhSachSinhVien, id);
                            Console.WriteLine(status);
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("Nhập ID: ");
                            int id1 = int.Parse(Console.ReadLine());
                            string status1 = XoaSinhVienBoiID(ref danhSachSinhVien, id1);
                            Console.WriteLine(status1);
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine("Nhập Tên: ");
                            string ten = Console.ReadLine();
                            string status2 = TimKiemSinhVienTheoTen(danhSachSinhVien, ten);
                            Console.WriteLine(status2);
                            break;

                        case 5:
                            Console.Clear();
                            string status3 = SapXepSinhVienTheoDiemTrungBinh(ref danhSachSinhVien);
                            Console.WriteLine(status3);
                            break;

                        case 6:
                            Console.Clear();
                            string status4 = SapXepSinhVienTheoTen(ref danhSachSinhVien);
                            Console.WriteLine(status4);
                            break;

                        case 7:
                            Console.Clear();
                            string status5 = HienThiDanhSachSinhVien(danhSachSinhVien);
                            break;

                        case 8:
                            Console.Clear();
                            GhiRaFile(danhSachSinhVien, path);
                            break;

                        default:
                            break;
                    }

                    if(choose == -1)
                    {
                        break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bạn không được nhập sai định dạng!!!!".ToUpper());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void DocFile(ref List<Student> danhSachSinhVien, string pathIn)
        {
            using(StreamReader streamReader = new StreamReader(pathIn))
            {
                while(!streamReader.EndOfStream)
                {
                    Student student = new Student();
                    student.ID = int.Parse(streamReader.ReadLine());
                    student.Ten = streamReader.ReadLine();
                    student.GioiTinh = streamReader.ReadLine();
                    student.Tuoi = int.Parse(streamReader.ReadLine());
                    student.DiemToan = double.Parse(streamReader.ReadLine());
                    student.DiemLy = double.Parse(streamReader.ReadLine());
                    student.DiemHoa = double.Parse(streamReader.ReadLine());
                    student.DiemTrungBinh = double.Parse(streamReader.ReadLine());
                    student.HocLuc = streamReader.ReadLine();
                    danhSachSinhVien.Add(student);
                }
                Console.WriteLine("Đọc File Lưu Thành Công!!".ToUpper());
            }
        }
    }
}
