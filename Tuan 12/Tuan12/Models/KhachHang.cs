using System;
using System.Collections.Generic;

#nullable disable

namespace Tuan12.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
            MaKh = "";
            TenKh = "";
            SoDt = "";
            DiaChi = "";
        }

        public string MaKh { get; set; }
        public string TenKh { get; set; }
        public string SoDt { get; set; }
        public string DiaChi { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
