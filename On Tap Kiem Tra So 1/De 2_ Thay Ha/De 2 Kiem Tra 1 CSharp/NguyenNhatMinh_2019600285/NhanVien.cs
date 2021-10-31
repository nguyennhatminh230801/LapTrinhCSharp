using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenNhatMinh_2019600285
{
    class NhanVien : TinhLuong, IComparable
    {
        private string maNV;
        private string chucVu;
        
        public NhanVien() : base()
        {
            MaNV = "DEFAULT_ID";
            ChucVu = "DEFAULT_CHUCVU";
        }

        public NhanVien(string hoTen, string diaChi, double heSoLuong, string maNV, string chucVu) : base(hoTen, diaChi, heSoLuong)
        {
            this.maNV = maNV;
            this.chucVu = chucVu;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }


        public double PhuCapChucVu()
        {
            string chucVu1 = chucVu.Trim().ToLower();
            
            if(chucVu1.Equals("giam doc"))
            {
                return 0.5;
            }
            else if (chucVu1.Equals("truong phong") || chucVu1.Equals("pho giam doc"))
            {
                return 0.4;
            }
            else if(chucVu1.Equals("pho phong"))
            {
                return 0.3;
            }
            else
            {
                return 0;
            }
        }
        public override double TinhLuongNhanVien()
        {
            return (HeSoLuong + PhuCapChucVu()) * LUONG_CO_BAN;
        }

        //ToString (override)   
        public override string ToString()
        {
            //{0}, {1}, {2}  theo thu tu la tung thong tin duoc xuat ra
            //muon xuat tren 1 dong {STT, -khoang cach} 
            //am khoang cacnh thi thong tin hien ve ben trai
            return string.Format("{0,-15} {1,-30} {2,-30} {3,-15} {4,-30} {5,-30}", MaNV, HoTen, ChucVu, HeSoLuong, DiaChi, TinhLuongNhanVien());
        }

        public override bool Equals(object obj)
        {
            //Chuyen object ve kieu NhanVien
            NhanVien nhanVien = (NhanVien)obj;
            //So sanh theo MaNV
            return MaNV.Equals(nhanVien.MaNV);
        }

        public override void Nhap()
        {
            Console.WriteLine("Nhap Ma Nhan Vien: ");
            MaNV = Console.ReadLine();
            base.Nhap();
            Console.WriteLine("Nhap Chuc Vu: ");
            ChucVu = Console.ReadLine();
        }

        //Xay dung tieu chi sap xep - co tu interface IComparable
        public int CompareTo(object obj)
        {
            NhanVien nhanvien1 = (NhanVien)obj;

            int answer = TinhLuongNhanVien().CompareTo(nhanvien1.TinhLuongNhanVien());

            //Tang Dan
            return answer;

            //Giam Dan
            //return answer * (-1); 
        }
    }
}
