using System;
using System.Collections.Generic;
using System.Text;

namespace DanhSach
{
    class DanhSach
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<string> thanhPho = new List<string>();
            thanhPho.Add("Thanh Pho Ho Chi Minh");
            thanhPho.Add("Ha Noi");
            thanhPho.Add("Da Nang");
            thanhPho.Add("Can Tho");
            thanhPho.Add("Hai Phong");

            thanhPho.Sort();

            Console.WriteLine("Sau Khi Sắp Xếp: ");
            foreach (var item in thanhPho)
            {
                Console.WriteLine(item);
            }

            thanhPho.Remove("Ha Noi");

            thanhPho.Add("Thanh Hoa");
            thanhPho.Add("Vinh Phuc");
            thanhPho.Add("Thai Nguyen");
            thanhPho.Add("Ca Mau");
            thanhPho.Add("Ben Tre");

            Console.WriteLine("Sau Khi Xóa Và Thêm: ");
            foreach (var item in thanhPho)
            {
                Console.WriteLine(item);
            }
        }
    }
}
