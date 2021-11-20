using System;
using System.Collections.Generic;

namespace PhieuGiaoBaiTap3.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string MaSp { get; set; } = null!;
        public string TenSp { get; set; } = null!;
        public string? MaLoai { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

        public virtual LoaiSanPham? MaLoaiNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
