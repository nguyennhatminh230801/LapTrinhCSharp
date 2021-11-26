﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tuan12.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
        }

        public string MaHd { get; set; }
        public DateTime? NgayLap { get; set; }
        public string NguoiLap { get; set; }
        public string MaKh { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
    }
}
