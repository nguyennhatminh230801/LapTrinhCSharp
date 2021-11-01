using System;
using System.Collections.Generic;
using System.Text;

namespace NguyenNhatMinh_2011111111
{
    class Nguoi
    {
        //Alt + Enter -> Encapsulation Field (but still used field)
        private string hoTen;
        private string diaChi;

        //Alt + Enter -> Generate Constructor(float, string , int, ...)
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        //prop - tab 2 lan
        //public int MyProperty { get; set; }

        //ctor - tab 2 lan
        public Nguoi()
        {
            HoTen = "DEFAULT_NAME";
            DiaChi = "DEFAULT_ADDRESS";
        }

        public Nguoi(string hoTen, string diaChi)
        {
            HoTen = hoTen;
            DiaChi = diaChi;
        }

        public virtual void Nhap()
        {
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
        }
    }
}
