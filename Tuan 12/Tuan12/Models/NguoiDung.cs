using System;
using System.Collections.Generic;

#nullable disable

namespace Tuan12.Models
{
    public partial class NguoiDung
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }

        public NguoiDung()
        {

        }

        public NguoiDung(string tenDangNhap, string matKhau)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }

        public NguoiDung(string tenDangNhap, string matKhau, string hoTen) : this(tenDangNhap, matKhau)
        { 
            HoTen = hoTen;
        }

        public override bool Equals(object obj)
        {
            NguoiDung nguoiDung = obj as NguoiDung;
            return TenDangNhap.Equals(nguoiDung.TenDangNhap) 
                && MatKhau.Equals(nguoiDung.MatKhau);
        }
    }
}
