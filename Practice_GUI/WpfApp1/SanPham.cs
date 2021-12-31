using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SanPham
    {
        public string MaSP { get; set; }

        public string TenSP { get; set; }

        public string MaLoai { get; set; }

        public int SoLuongCo { get; set; }

        public int DonGia { get; set; }

        public int ThanhTien { get => SoLuongCo * DonGia; }

        public SanPham()
        {
                
        }

        public SanPham(string maSP, string tenSP, string maLoai, int soLuongCo, int donGia)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MaLoai = maLoai;
            SoLuongCo = soLuongCo;
            DonGia = donGia;
        }
    }
}
