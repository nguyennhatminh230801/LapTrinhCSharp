using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiThuHuong_527
{
    class Nguoi
    {
        private string hoTen;
        private string diaChi;

        public Nguoi()
        {
                
        }
        public Nguoi(string hoTen, string diaChi)
        {
            this.hoTen = hoTen;
            this.diaChi = diaChi;
        }

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public virtual void Nhap()
        {
            Console.WriteLine("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.WriteLine("Nhap dia chi: ");
            diaChi = Console.ReadLine();
        }
    }
}
