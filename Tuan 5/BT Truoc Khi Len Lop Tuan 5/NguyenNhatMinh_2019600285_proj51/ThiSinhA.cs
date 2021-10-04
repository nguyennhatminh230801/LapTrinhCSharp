using System;

namespace NguyenNhatMinh_2019600285_proj51
{
    class ThiSinhA
    {
        public string SoBaoDanh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public double DiemToan { get; set; }
        public double DiemLy { get; set; }
        public double DiemHoa { get; set; }
        public double DiemUuTien { get; set; }

        private double tongDiem;
        public double TongDiem { get => tongDiem; set => tongDiem = value; }

        public ThiSinhA()
        {
            SoBaoDanh = "";
            HoTen = "";
            DiaChi = "";
            DiemToan = 0;
            DiemLy = 0;
            DiemHoa = 0;
            DiemUuTien = 0;
            TongDiem = 0;
        }

        public ThiSinhA(string soBaoDanh)
        {
            SoBaoDanh = soBaoDanh;
            HoTen = "";
            DiaChi = "";
            DiemToan = 0;
            DiemLy = 0;
            DiemHoa = 0;
            DiemUuTien = 0;
            TongDiem = 0;
        }

        public ThiSinhA(string soBaoDanh, string hoTen, string diaChi, double diemToan, double diemLy, double diemHoa, double diemUuTien)
        {
            SoBaoDanh = soBaoDanh;
            HoTen = hoTen;
            DiaChi = diaChi;
            DiemToan = diemToan;
            DiemLy = diemLy;
            DiemHoa = diemHoa;
            DiemUuTien = diemUuTien;
            TongDiem = DiemHoa + DiemToan + DiemLy + DiemUuTien;
        }

        public void Nhap()
        {
            Console.Write("Nhập Số Báo Danh: ");
            SoBaoDanh = Console.ReadLine().Trim();
            Console.Write("Nhập Họ Tên: ");
            HoTen = Console.ReadLine().Trim();
            Console.Write("Nhập Địa Chỉ: ");
            DiaChi = Console.ReadLine().Trim();
            Console.Write("Nhập Điểm Toán: ");
            DiemToan = double.Parse(Console.ReadLine());
            Console.Write("Nhập Điểm Lý: ");
            DiemLy = double.Parse(Console.ReadLine());
            Console.Write("Nhập Điểm Hóa: ");
            DiemHoa = double.Parse(Console.ReadLine());
            Console.Write("Nhập Điểm Uư Tiên: ");
            DiemUuTien = double.Parse(Console.ReadLine());

            TongDiem = DiemHoa + DiemToan + DiemLy + DiemUuTien;
        }

        //Nạp chồng xuất đối tượng
        public override string ToString()
        {
            return $"Số báo danh: {SoBaoDanh}" +
                $"\nHọ tên: {HoTen}" +
                $"\nĐịa Chỉ: {DiaChi}" +
                $"\nĐiểm Toán: {DiemToan}" +
                $"\nĐiểm Lý: {DiemLy}" +
                $"\nĐiểm Hóa: {DiemHoa}" +
                $"\nĐiêm Ưu Tiên: {DiemUuTien}" +
                $"\nTổng Điểm: {TongDiem}";
        }
    }
}
