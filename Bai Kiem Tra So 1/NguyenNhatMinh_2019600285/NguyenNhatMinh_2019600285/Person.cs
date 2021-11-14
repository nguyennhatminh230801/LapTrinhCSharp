using System;
using System.Linq;
namespace NguyenNhatMinh_2019600285
{
    class Person
    {
        private string hoTen;
        private string dienThoai;

        public Person()
        {
            HoTen = "DEFAULT_NAME";
            DienThoai = "DEFAULT_PHONE_NUMBER";
        }

        public Person(string hoTen, string dienThoai)
        {
            HoTen = hoTen;
            DienThoai = dienThoai;
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }

        public virtual void Nhap()
        {
            Console.Write("Nhập Họ Tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập Điện Thoại: ");
            DienThoai = Console.ReadLine();
        }
    }
}
