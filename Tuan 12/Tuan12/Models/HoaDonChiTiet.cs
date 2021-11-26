using System;
using System.Collections.Generic;

#nullable disable

namespace Tuan12.Models
{
    public partial class HoaDonChiTiet
    {
        public string MaHd { get; set; }
        public string MaSp { get; set; }
        public int? SoLuongMua { get; set; }

        public virtual HoaDon MaHdNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
