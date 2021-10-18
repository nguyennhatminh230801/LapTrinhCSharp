using System;
using System.Text;
using System.Collections.Generic;

namespace NguyenNhatMinh_2019600285_proj63
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            int choose = 7;
            List<Course> courses = new List<Course>();
            while (true)
            {
                try
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("=====================QUẢN LÝ TRƯỜNG HỌC=====================");
                    Console.WriteLine("============================================================");
                    Console.WriteLine("=1. Thêm Một Khóa Học                                      =");
                    Console.WriteLine("=2. Hiển Thị Các Khóa Học                                  =");
                    Console.WriteLine("=3. Tìm Kiếm Khóa Học                                      =");
                    Console.WriteLine("=4. Tìm Kiếm Sinh Viên                                     =");
                    Console.WriteLine("=5. Xóa Một Khóa Học                                       =");
                    Console.WriteLine("=6. Kết Thúc                                               =");
                    Console.WriteLine("============================================================");
                    Console.Write("Mời bạn nhập lựa chọn: ");
                    choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(ThemKhoaHoc(ref courses));
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine(HienThiCacKhoaHoc(courses));
                            break;

                        case 3:
                            Console.Clear();
                            Console.Write("Nhập Mã Môn Học: ");
                            string courseID = Console.ReadLine();
                            Console.WriteLine(TimKiemKhoaHoc(courses, courseID));
                            break;

                        case 4:
                            Console.Clear();
                            Console.Write("Nhập Mã Học Sinh: ");
                            int studentID = int.Parse(Console.ReadLine());
                            Console.WriteLine(TimKiemSinhVien(courses, studentID));
                            break;

                        case 5:
                            Console.Clear();
                            Console.Write("Nhập Mã Môn Học: ");
                            string courseID1 = Console.ReadLine();
                            Console.WriteLine(XoaMotMonHoc(ref courses, courseID1));
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
                                choose = 8;
                            }
                            else
                            {
                                throw new Exception("Lựa chọn không hợp lệ!!!");
                            }
                            break;

                        default:
                            break;
                    }

                    if (choose == 7)
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

        

        //1. Thêm Một Khóa Học 
        public static string ThemKhoaHoc(ref List<Course> courses)
        {
            Console.WriteLine("Nhập thông tin khóa học: ");
            Course course = new Course();
            course.InputCourse();

            int choose1 = 2;
            Console.WriteLine("Bạn muốn thêm khóa học này không?");
            Console.WriteLine("1. Có");
            Console.WriteLine("2. Không");
            choose1 = int.Parse(Console.ReadLine());

            if (choose1 == 1)
            {
                courses.Add(course);
                return "Thêm mới thành công".ToUpper();
            }
            else if (choose1 == 2)
            {
                return "Thêm mới không thành công".ToUpper();
            }
            else
            {
                throw new Exception("Lựa chọn không hợp lệ!!!");
            }
        }

        //2. Hiển Thị Các Khóa Học
        public static string HienThiCacKhoaHoc(List<Course> courses)
        {
            if (courses.Count == 0)
            {
                return "Danh sách này rỗng".ToUpper();
            }

            int i = 0;

            Console.WriteLine("Danh sách khóa học".ToUpper());

            foreach (var course in courses)
            {
                i++;
                Console.WriteLine("Sinh Viên Thứ {0}:", i);
                course.DisplayCourseAndStudents();
            }

            return "đã hiển thị tất cả khóa học trong danh sách".ToUpper();
        }

        //3. Tìm Kiếm Khóa Học
        public static string TimKiemKhoaHoc(List<Course> courses, string courseID)
        {
            Course course = courses.Find(element => element.courseID.Equals(courseID));

            if(course == null)
            {
                return "không tìm được khóa học".ToUpper();
            }
            else
            {
                Console.WriteLine("Thông Tin Khóa Học: ");
                course.DisplayCourseAndStudents();
            }

            return "đã hiển thị tất cả thông tin khóa học".ToUpper();
        }

        //4. Tìm Kiếm Sinh Viên
        public static string TimKiemSinhVien(List<Course> courses, int studentID)
        {
            foreach (var course in courses)
            {
                Student student = course.GetAllStudents().Find(element => element.studentID == studentID);
                
                if(student != null)
                {
                    Console.WriteLine("Thông tin sinh viên: ");
                    Console.WriteLine(student);
                    return "Tìm kiếm thành công".ToUpper();
                }
            }

            return "Tìm kiếm không thành công".ToUpper();
        }

        //5. Xóa Một Khóa Học
        public static string XoaMotMonHoc(ref List<Course> courses, string courseID1)
        {
            Course course = courses.Find(element => element.courseID.Equals(courseID1));

            if (course == null)
            {
                return "không tìm được khóa học".ToUpper();
            }
            else
            {
                int choose1 = 2;
                Console.WriteLine("Bạn muốn xóa khóa học này không?");
                Console.WriteLine("1. Có");
                Console.WriteLine("2. Không");
                choose1 = int.Parse(Console.ReadLine());

                if (choose1 == 1)
                {
                    courses.Remove(course);
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

            return "đã hiển thị tất cả thông tin khóa học".ToUpper();
        }
    }
}
