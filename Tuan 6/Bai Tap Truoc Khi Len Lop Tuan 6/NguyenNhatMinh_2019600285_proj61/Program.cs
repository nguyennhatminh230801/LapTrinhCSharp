using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NguyenNhatMinh_2019600285_proj61
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> students = new List<Student>();

            int choose = 7;
            while (true)
            {
                try
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("===================QUẢN LÝ SINH VIÊN========================");
                    Console.WriteLine("============================================================");
                    Console.WriteLine("=1. Thêm Sinh Viên                                         =");
                    Console.WriteLine("=2. Hiển Thị Danh Sách Sinh Viên                           =");
                    Console.WriteLine("=3. Tìm Kiếm Sinh Viên Theo ID                             =");
                    Console.WriteLine("=4. Tìm Kiếm Sinh Viên Theo Address                        =");
                    Console.WriteLine("=5. Xóa Một Sinh Viên Theo ID                              =");
                    Console.WriteLine("=6. Kết Thúc Chương Trình                                  =");
                    Console.WriteLine("============================================================");
                    Console.Write("Mời bạn nhập lựa chọn: ");
                    choose = int.Parse(Console.ReadLine());

                    switch(choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(ThemSinhVien(ref students));
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine(HienThiDanhSachSinhVien(students));
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine(TimKiemSinhVienTheoID(students));
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine(TimKiemSinhVienTheoAddress(students));
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine(XoaSinhVienTheoID(ref students));
                            break;

                        case 6:
                            Console.Clear();
                            int choose2 = 2;
                            Console.WriteLine("Bạn Muốn Thoát Chương Trình?");
                            Console.WriteLine("1. Có");
                            Console.WriteLine("2. Không");
                            choose2 = int.Parse(Console.ReadLine());

                            if (choose2 == 1)
                            {
                                break;
                            }
                            else if (choose2 == 2)
                            {
                                choose = 7;
                            }
                            else
                            {
                                throw new Exception("Lựa chọn không hợp lệ!!!");
                            }
                            break;
                    }

                    if(choose == 6)
                    {
                        break;
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Nhập sai kiểu!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        //1. Thêm Sinh Viên
        private static string ThemSinhVien(ref List<Student> students)
        {
            Console.WriteLine("Nhập thông tin sinh viên: ");
            Student student = new Student();
            student.Input();

            int choose1 = 2;
            Console.WriteLine("Bạn muốn thêm sinh viên này không?");
            Console.WriteLine("1. Có");
            Console.WriteLine("2. Không");
            choose1 = int.Parse(Console.ReadLine());

            if(choose1 == 1)
            {
                students.Add(student);
                return "Thêm mới thành công".ToUpper();
            }
            else if(choose1 == 2)
            {
                return "Thêm mới không thành công".ToUpper();
            }
            else
            {
                throw new Exception("Lựa chọn không hợp lệ!!!");
            }
        }

        //2. Hiển Thị Danh Sách Sinh Viên
        private static string HienThiDanhSachSinhVien(List<Student> students)
        {
            if(students.Count == 0)
            {
                return "Danh sách này rỗng".ToUpper();
            }

            int i = 0;

            Console.WriteLine("Danh sách sinh viên".ToUpper());

            foreach (var item in students)
            {
                i++;
                Console.WriteLine("Sinh Viên Thứ {0}:", i);
                item.Output();
            }

            return "đã hiển thị tất cả sinh viên trong danh sách".ToUpper();
        }

        //3. Tìm Kiếm Sinh Viên Theo ID
        private static string TimKiemSinhVienTheoID(List<Student> students)
        {
            Console.Write("Nhập ID Sinh Viên Cần Tìm: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(element => element.id == id);

            if(student == null)
            {
                return "không tìm được sinh viên này".ToUpper();
            }

            Console.WriteLine("Thông tin sinh viên: ");
            student.Output();

            return "tìm kiếm thành công".ToUpper();
        }

        //4. Tìm Kiếm Sinh Viên Theo Address
        private static string TimKiemSinhVienTheoAddress(List<Student> students)
        {
            Console.WriteLine("Nhập Địa Chỉ Cần Tìm: ");
            string address = Console.ReadLine().Trim();

            var query = (from student in students
                        where student.address.Contains(address.ToLower())
                        select student).ToList();
            
            if(query.Count == 0)
            {
                return "Không có sinh viên nào ở địa chỉ này".ToUpper();
            }

            HienThiDanhSachSinhVien(query);
            return "";
        }

        //5. Xóa Một Sinh Viên Theo ID
        private static string XoaSinhVienTheoID(ref List<Student> students)
        {
            Console.Write("Nhập ID Sinh Viên Cần Tìm: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(element => element.id == id);

            if (student == null)
            {
                return "không tìm được sinh viên này".ToUpper();
            }

            int choose1 = 2;
            Console.WriteLine("Bạn muốn xóa sinh viên này không?");
            Console.WriteLine("1. Có");
            Console.WriteLine("2. Không");
            choose1 = int.Parse(Console.ReadLine());

            if (choose1 == 1)
            {
                students.Remove(student);
                return "xóa thành công".ToUpper();
            }
            else if (choose1 == 2)
            {
                return "xóa không thành công".ToUpper();
            }
            else
            {
                throw new Exception("Lựa chọn không hợp lệ!!!");
            }
        }
    }
}
