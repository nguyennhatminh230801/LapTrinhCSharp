using System;
using System.Collections.Generic;
using System.Text;

namespace NguyenNhatMinh_2019600285_proj63
{
    class Course
    {
        public string courseID { get; set; }
        public string courseName { get; set; }
        public int fee { get; set; }
        public List<Student> listStudent { get; set; }

        public Course()
        {
            listStudent = new List<Student>();
            courseID = "DEFAULT_COURSE_ID";
            courseName = "DEFAULT_COURSE_NAME";
            fee = 0;
        }

        public void InputCourse()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập Mã Môn Học: ");
            courseID = Console.ReadLine();
            Console.Write("Nhập Tên Môn Học: ");
            courseName = Console.ReadLine();
            Console.Write("Nhập Học Phí: ");
            fee = int.Parse(Console.ReadLine());

            Console.Write("Nhập số lượng sinh viên: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Nhập Thông Tin Học Sinh Thứ {i}: ");
                Student student = new Student();
                student.InputStudent();
                listStudent.Add(student);
            }    
        }

        public void DisplayCourseAndStudents()
        {
            Console.WriteLine($"Mã Môn Học: {courseID}" +
                $"\nTên Môn Học: {courseName}" +
                $"\nHọc Phí: {fee}");

            Console.WriteLine("Danh Sách Sinh Viên Lớp Học: ");
            
            int i = 1;

            foreach (var student in listStudent)
            {
                Console.WriteLine($"Thông Tin Sinh Viên Thứ {i++}: ");
                Console.WriteLine(student);
            }
        }

        public List<Student> GetAllStudents()
        {
            return listStudent;
        }
    }
}
