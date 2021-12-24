using System;
using System.Collections.Generic;
using System.Text;

namespace Practice_Csharp
{
    public class NhanVien
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public int SoNgayLamViec { get; set; }
        
        public int ThanhTien 
        { 
            get
            {
                if(SoNgayLamViec <= 10)
                {
                    return SoNgayLamViec * 200000;
                }
                else
                {
                    return 2000000 + (SoNgayLamViec - 10) * 400000;
                }
            }
        }

        public NhanVien()
        {
                
        }

        public NhanVien(string hoTen, DateTime ngaySinh, string gioiTinh, int soNgayLamViec)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoNgayLamViec = soNgayLamViec;
        }
    }
}
