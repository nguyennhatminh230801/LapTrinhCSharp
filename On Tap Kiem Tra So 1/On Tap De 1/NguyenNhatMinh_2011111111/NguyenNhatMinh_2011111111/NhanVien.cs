using System;
using System.Collections.Generic;
using System.Text;

namespace NguyenNhatMinh_2011111111
{
    class NhanVien : Nguoi, IComparable
    {
        private string maNhanVien;
        private string chucVu;
        private double luongCoBan;

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public double LuongCoBan { get => luongCoBan; set => luongCoBan = value; }

        public NhanVien() : base()
        {
            MaNhanVien = "DEFAULT_ID";
            ChucVu = "DEFAULT_CV";
            LuongCoBan = 0;
        }

        public NhanVien(string hoTen, string diaChi, string maNhanVien, string chucVu, double luongCoBan) : base(hoTen, diaChi)
        {
            MaNhanVien = maNhanVien;
            ChucVu = chucVu;
            LuongCoBan = luongCoBan;
        }

        public int HeSoChucVu()
        {
            string chucVu1 = ChucVu.Trim().ToLower();

            if(chucVu1.Equals("giam doc"))
            {
                return 10;
            }
            else if (chucVu1.Equals("truong phong") || chucVu1.Equals("pho giam doc"))
            {
                return 6;
            }
            else if(chucVu1.Equals("pho phong"))
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
            MaNhanVien = Console.ReadLine();
            Console.WriteLine("Nhap chuc vu: ");
            ChucVu = Console.ReadLine();
            Console.WriteLine("Nhap luong co ban: ");
            LuongCoBan = double.Parse(Console.ReadLine());
        }

        //Alt + Enter => Generate Overrides => Chon Equals() vs ToString()

        //So sanh 2 doi tuong co giong nhau hay khong
        public override bool Equals(object obj)
        {
            //B1: Chuyen obj ve kieu NhanVien
            NhanVien nhanVienKhac = (NhanVien)obj;

            //B2: So Sanh Trung Ma
            return MaNhanVien.Equals(nhanVienKhac.MaNhanVien);
        }

        //Khi Console.WriteLine(doiTuongLopNay) => goi vao ToString() cua Lop Nay
        public override string ToString()
        {
            return $"{MaNhanVien,-20} {HoTen,-30} {DiaChi,-30} {ChucVu,-30} {LuongCoBan,-20} {HeSoChucVu(),-20}";
        }

        //Sap xep doi tuong
        public int CompareTo(object obj)
        {
            //B1: Chuyen obj ve kieu NhanVien
            NhanVien nhanVienKhac = (NhanVien)obj;

            int answer = HeSoChucVu().CompareTo(nhanVienKhac.HeSoChucVu());
            
            //Neu bang nhau ve He So Chuc Vu thi sap xep theo he so luong
            if(answer == 0)
            {
                return LuongCoBan.CompareTo(nhanVienKhac.LuongCoBan);
            }

            //Sap xep tang dan
            return answer;

            //Sap xep giam dan
            //return answer * (-1);
        }
    }
}
