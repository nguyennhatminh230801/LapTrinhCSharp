using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Style_Template_EFCore_OnThi.Models
{
    public class KhachHang
    {
        [Key] //Khoa chinh
        [StringLength(5)] //nvarchar(5)
        public string MaKH { get; set; }

        [Required] // not null
        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        public KhachHang()
        {
                
        }

        public KhachHang(string maKH, string hoTen, string gioiTinh)
        {
            MaKH = maKH;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
        }
    }
}
