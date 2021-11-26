﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tuan12.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string MaLoai { get; set; }
        public int? SoLuong { get; set; }
        public int? DonGia { get; set; }

        public virtual LoaiSanPham MaLoaiNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
