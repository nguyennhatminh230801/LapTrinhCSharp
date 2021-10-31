using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoThiThuHuong_527
{
    class NhanVien : Nguoi, IComparable
    {
        private string maNhanVien;
        private string chucVu;
        private double luongCoBan;

        public NhanVien() : base()
        {

        }

        public NhanVien(string hoTen, string diaChi, string maNhanVien, string chucVu, double luongCoBan) : base(hoTen, diaChi)
        {
            this.maNhanVien = maNhanVien;
            this.chucVu = chucVu;
            this.luongCoBan = luongCoBan;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public double LuongCoBan { get => luongCoBan; set => luongCoBan = value; }

        public int CompareTo(object obj)
        {
            return HeSoChucVu().CompareTo((obj as NhanVien).HeSoChucVu());
        }

        public int HeSoChucVu()
        {
            if (chucVu.Trim().ToLower().Equals("giam doc"))
            {
                return 10;
            }
            else if (chucVu.Trim().ToLower().Equals("truong phong") || 
                chucVu.Trim().ToLower().Equals("pho giam doc"))
            {
                return 6;
            }
            else if (chucVu.Trim().ToLower().Equals("pho phong"))
            {
                return 4;
            }
            else
            {
                return 2;
            }
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("Nhap ma nhan vien: ");
            maNhanVien = Console.ReadLine();
            Console.WriteLine("Nhap chuc vu: ");
            chucVu = Console.ReadLine();
            Console.WriteLine("Nhap luong co ban: ");
            luongCoBan = double.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("{0,-10} {1,-30} {2,-30} {3,-30} {4,-30} {5,-30}", HoTen, DiaChi, MaNhanVien, ChucVu, LuongCoBan, HeSoChucVu());
        }
    }
}
