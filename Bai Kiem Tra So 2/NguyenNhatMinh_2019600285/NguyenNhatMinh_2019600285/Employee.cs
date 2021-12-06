using System;
using System.Collections.Generic;
using System.Text;

namespace NguyenNhatMinh_2019600285
{
    public class Employee
    {
        public string HoTen { get; set; }
        
        public bool IsGioiTinhNam { get; set; }

        public Int64 SoNgayCong { get; set; }

        public Int64 Luong { get; set; }

        public Int64 Thuong
        {
            get
            {
                if(SoNgayCong >= 27)
                {
                    return (Luong * 10) / 100;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Employee()
        {
            HoTen = "Default HoTen";
            IsGioiTinhNam = false;
            SoNgayCong = 0;
            Luong = 0;
        }

        public Employee(string hoTen, bool isGioiTinhNam, Int64 soNgayCong, Int64 luong)
        {
            HoTen = hoTen;
            IsGioiTinhNam = isGioiTinhNam;
            SoNgayCong = soNgayCong;
            Luong = luong;
        }

        public override string ToString()
        {
            return $"{HoTen} - {(IsGioiTinhNam ? "Nam" : "Nữ")} - {SoNgayCong} - {Luong} - {Thuong}";
        }
    }


}
