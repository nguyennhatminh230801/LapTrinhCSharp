using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnTapCsharp
{
    public class NhanVien
    {
        public string TenNV { get; set; }
        public string PhongBan { get; set; }
        public bool TiengAnh { get; set; }
        public bool TiengPhap { get; set; }
        public bool TiengTrung { get; set; }
        public DateTime NgaySinh { get; set; }
        public int SoNgayLamViec { get; set; }

        public long LuongNhanVien
        {
            get
            {
                if(SoNgayLamViec <= 20)
                {
                    return SoNgayLamViec * 100000;
                }
                else
                {
                    return 2000000 + (SoNgayLamViec - 20) * 200000;
                }
            }
        }

        public NhanVien()
        {
            TenNV = "Default Name";
            PhongBan = "Default Room";
            TiengAnh = false;
            TiengPhap = false;
            TiengTrung = false;
            NgaySinh = new DateTime(1970, 1, 1);
            SoNgayLamViec = 0;
        }

        public NhanVien(string tenNV, string phongBan, bool tiengAnh, bool tiengPhap, bool tiengTrung, DateTime ngaySinh, int soNgayLamViec)
        {
            TenNV = tenNV;
            PhongBan = phongBan;
            TiengAnh = tiengAnh;
            TiengPhap = tiengPhap;
            TiengTrung = tiengTrung;
            NgaySinh = ngaySinh;
            SoNgayLamViec = soNgayLamViec;
        }

        public override string ToString()
        {
            string answer = TenNV + "-";
            answer += PhongBan + "-";

            List<string> res = new List<string>();
            if(TiengAnh == true)
            {
                res.Add("Anh");
            }

            if (TiengPhap == true)
            {
                res.Add("Pháp");
            }

            if (TiengTrung == true)
            {
                res.Add("Trung");
            }

            //Ko co ngon ngu nao được chọn
            if(res.Count == 0)
            {
                answer += "Không giỏi Ngôn Ngữ" + "-";
            }
            else
            {
                //Aggregate giong reduce() trong JS (Linq)
                answer += res.Aggregate((a, b) => a + "," + b) + "-";
            }

            answer += NgaySinh.ToShortDateString() + "-";
            answer += LuongNhanVien.ToString();
            return answer;
        }
    }
}
