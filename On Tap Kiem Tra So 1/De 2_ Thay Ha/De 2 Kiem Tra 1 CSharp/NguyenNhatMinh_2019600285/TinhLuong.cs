using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenNhatMinh_2019600285
{
    class TinhLuong
    {
        //Alt + Enter -> Encapsulation Field (but still used field)
        private string hoTen;
        private string diaChi;
        private double heSoLuong;

        public static int LUONG_CO_BAN 
        { 
            get
            {
                return 1000000;
            }
        }

        //prop - tab 2 lan
        //public int MyProperty { get; set; }


        //Alt + Enter -> Generate Constructor(float, string , int, ...)
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public double HeSoLuong { get => heSoLuong; set => heSoLuong = value; }

        //ctor - tab 2 lan
        public TinhLuong()
        {
            HoTen = "DEFAULT_NAME";
            DiaChi = "DEFAULT_ADDRESS";
            heSoLuong = 0;
        }

        public TinhLuong(string hoTen, string diaChi, double heSoLuong)
        {
            HoTen = hoTen;
            DiaChi = diaChi;
            HeSoLuong = heSoLuong;
        }

        //ke thua va lop con phai override
        //=> can 1 phuong thuc ao (virtual)
        public virtual double TinhLuongNhanVien()
        {
            return heSoLuong * LUONG_CO_BAN;
        }
        
        public virtual void Nhap()
        {
            Console.WriteLine("Nhap Ho Ten: ");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap Dia Chi: ");
            DiaChi = Console.ReadLine();
            Console.WriteLine("Nhap He So Luong: ");
            HeSoLuong = double.Parse(Console.ReadLine());
        }
    }
}
