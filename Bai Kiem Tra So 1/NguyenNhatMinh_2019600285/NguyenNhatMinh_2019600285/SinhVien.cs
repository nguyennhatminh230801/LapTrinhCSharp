using System;

namespace NguyenNhatMinh_2019600285
{
    class SinhVien : Person
    {
        private string maSinhVien;
        private double diem;
        //private string xepLoai;

        public SinhVien() : base()
        {
            MaSinhVien = "DEFAULT_ID";
            Diem = 0;
        }

        public SinhVien(string hoTen, string dienThoai, string maSinhVien, double diem) : base(hoTen, dienThoai)
        {
            MaSinhVien = maSinhVien;
            Diem = diem;
        }

        public string MaSinhVien
        {
            get { return maSinhVien; }
            set { maSinhVien = value; }
        }
        public double Diem
        {
            get { return diem; }
            set { diem = value; }
        }
        public string XepLoai
        {
            get
            {
                if (Diem >= 8)
                {
                    return "Giỏi";
                }
                else if (Diem >= 6.5 && Diem < 8)
                {
                    return "Khá";
                }
                else if (Diem >= 5 && Diem < 6.5)
                {
                    return "Trung Bình";
                }
                else
                {
                    return "Kém";
                }
            }
        }

        public override bool Equals(object obj)
        {
            return MaSinhVien.Equals((obj as SinhVien).MaSinhVien);
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập Mã Sinh Viên: ");
            MaSinhVien = Console.ReadLine();
            Console.Write("Nhập Điểm: ");
            Diem = double.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            return string.Format($"{MaSinhVien,-20}{HoTen,-30}{DienThoai,-30}{Diem,-15}{XepLoai,-15}");
        }
    }
}
