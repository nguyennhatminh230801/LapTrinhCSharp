using System;
using System.Text;

namespace NguyenNhatMinh_2019600285_proj63
{
    class Student
    {
        public int studentID { get; set; }
        public string name { get; set; }
        public string mark { get; set; }

        public void InputStudent()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập Mã Học Sinh: ");
            studentID = int.Parse(Console.ReadLine());
            Console.Write("Nhập Tên Học Sinh: ");
            name = Console.ReadLine();
            Console.Write("Nhập Điểm Thi: ");
            mark = Console.ReadLine();
        }
        public override string ToString()
        {
            Console.OutputEncoding = Encoding.UTF8;

            return $"Mã Học Sinh: {studentID}" +
                $"\nTên Học Sinh: {name}" +
                $"\nĐiểm Thi: {mark}";
        }
    }
}
