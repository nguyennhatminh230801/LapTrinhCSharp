using System;

namespace OnTapKTSo2
{
    public class NhanVien
    {
        public string HoTen { get; set; }
        public string LoaiNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public double SoTienBanHang { get; set; }

        public double HoaHong
        {
            get
            {
                if (SoTienBanHang < 1000)
                {
                    return 0;
                }
                else if (SoTienBanHang > 5000)
                {
                    return (SoTienBanHang * 20) / 100;
                }
                else
                {
                    return (SoTienBanHang * 10) / 100;
                }
            }
        }

        public NhanVien()
        {
            HoTen = "Default Name";
            LoaiNV = "Default loaiNV";
            NgaySinh = new DateTime(1970, 1, 1);
            SoTienBanHang = 0;
        }

        public NhanVien(string hoTen, string loaiNV, DateTime ngaySinh, double soTienBanHang)
        {
            HoTen = hoTen;
            LoaiNV = loaiNV;
            NgaySinh = ngaySinh;
            SoTienBanHang = soTienBanHang;
        }

        public override string ToString()
        {
            return $"{HoTen} - {LoaiNV} - {NgaySinh.ToShortDateString()} -Tiền Bán Hàng: {SoTienBanHang} -Hoa hồng: {HoaHong}";
        }
    }
}
