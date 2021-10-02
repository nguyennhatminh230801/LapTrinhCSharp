using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BTVN_Tuan_3
{
    public partial class BTVNTuan3
    {
        private static int count = 1;

        public struct Student
        {
            public int ID;
            public string Ten;
            public string GioiTinh;
            public int Tuoi;
            public double DiemToan;
            public double DiemLy;
            public double DiemHoa;
            public double DiemTrungBinh;
            public string HocLuc;

            public override string ToString()
            {
                return "\nID: " + ID
                    + "\nTên: " + Ten
                    + "\nGiới Tính:" + GioiTinh
                    + "\nTuổi: " + Tuoi
                    + "\nĐiểm Toán: " + DiemToan
                    + "\nĐiểm Lý: " + DiemLy
                    + "\nĐiểm Hoá: " + DiemHoa
                    + "\nĐiểm Trung Bình: " + DiemTrungBinh
                    + "\nHọc Lực: " + HocLuc;
            }
        }

        //1. Thêm Sinh Viên
        public static void ThemSinhVien(ref List<Student> danhSachSinhVien)
        {
            Student student = new Student();

            Console.WriteLine("thêm sinh viên".ToUpper());
            student.ID = count++;
            Console.Write("Nhập Tên: ");
            student.Ten = Console.ReadLine().Trim();
            Console.Write("Nhập Giới Tính: ");
            student.GioiTinh = Console.ReadLine().Trim();
            Console.Write("Nhập Tuổi: ");
            student.Tuoi = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("Nhập Điểm Toán: ");
                student.DiemToan = double.Parse(Console.ReadLine());

                if(student.DiemToan < 0d || student.DiemToan > 10d)
                {
                    Console.WriteLine("Yêu cầu nhập lại!!!");
                }
            } while (student.DiemToan < 0d || student.DiemToan > 10d);

            do
            {
                Console.Write("Nhập Điểm Lý: ");
                student.DiemLy = double.Parse(Console.ReadLine());

                if(student.DiemToan < 0d || student.DiemToan > 10d)
                {
                    Console.WriteLine("Yêu cầu nhập lại!!!");
                }
            } while (student.DiemToan < 0d || student.DiemToan > 10d);

            do
            {
                Console.Write("Nhập Điểm Hóa: ");
                student.DiemHoa = double.Parse(Console.ReadLine());
                if (student.DiemToan < 0d || student.DiemToan > 10d)
                {
                    Console.WriteLine("Yêu cầu nhập lại!!!");
                }
            } while (student.DiemToan < 0d || student.DiemToan > 10d);

            student.DiemTrungBinh = (student.DiemToan + student.DiemLy + student.DiemHoa) / 3;

            if (student.DiemTrungBinh >= 8d)
            {
                student.HocLuc = "Giỏi";
            }
            else if (student.DiemTrungBinh < 8d && student.DiemTrungBinh >= 6.5)
            {
                student.HocLuc = "Khá";
            }
            else if (student.DiemTrungBinh < 6.5 && student.DiemTrungBinh >= 5d)
            {
                student.HocLuc = "Trung Bình";
            }
            else
            {
                student.HocLuc = "Yếu";
            }

            Console.WriteLine("Thêm Sinh Viên Thành Công".ToUpper());
            danhSachSinhVien.Add(student);
        }

        //2. Cập nhật thông tin Sinh Viên Bởi ID
        public static string CapNhatThongTinSinhVienBoiID(ref List<Student> danhSachSinhVien, int id)
        {
            if (danhSachSinhVien.Where(element => element.ID == id).ToList().Count == 0)
            {
                return "Cập nhật không thành công!!! Không Tìm Được Mã Nhập Vào".ToUpper();
            }

            int pos1 = 0;

            for (int i = 0; i < danhSachSinhVien.Count; i++)
            {
                if (danhSachSinhVien[i].ID == id)
                {
                    pos1 = i;
                    break;
                }
            }

            Student sinhVien = danhSachSinhVien[pos1];

            int choose1 = 9;

            while (true)
            {
                Console.WriteLine("Chọn thông tin bạn muốn cập nhật: ");
                Console.WriteLine("1. Tên");
                Console.WriteLine("2. Giới Tính");
                Console.WriteLine("3. Tuổi");
                Console.WriteLine("4. Điểm Toán");
                Console.WriteLine("5. Điểm Lý");
                Console.WriteLine("6. Điểm Hóa");
                Console.WriteLine("0. Hủy \n");

                Console.Write("Nhập lựa chọn của bạn: ");
                choose1 = int.Parse(Console.ReadLine());

                switch (choose1)
                {
                    

                    case 0:
                        Console.Clear();
                        Console.WriteLine("Bạn muốn thoát chương trình (Yes/No) ?");
                        string check = Console.ReadLine().Trim().ToLower();
                        if (check == "no")
                        {
                            choose1 = 9;
                        }
                        else
                        {
                            choose1 = -1;
                        }
                        break;

                    case 1:
                        Console.WriteLine("Thông tin cũ: {0}", sinhVien.Ten);
                        Console.Write("Thay đổi thông tin mới cho tên: ");
                        sinhVien.Ten = Console.ReadLine().Trim();
                        break;

                    case 2:
                        Console.WriteLine("Thông tin cũ: {0}", sinhVien.GioiTinh);
                        Console.Write("Thay đổi thông tin mới cho giới tính: ");
                        sinhVien.GioiTinh = Console.ReadLine().Trim();
                        break;

                    case 3:
                        Console.WriteLine("Thông tin cũ: {0}", sinhVien.Tuoi);
                        Console.Write("Thay đổi thông tin mới cho tuổi: ");
                        sinhVien.Tuoi = int.Parse(Console.ReadLine());
                        break;

                    case 4:
                        Console.WriteLine("Thông tin cũ: {0}", sinhVien.DiemToan);
                        Console.Write("Thay đổi thông tin mới cho điểm toán: ");
                        sinhVien.DiemToan = double.Parse(Console.ReadLine());
                        sinhVien.DiemTrungBinh = (sinhVien.DiemToan + sinhVien.DiemLy + sinhVien.DiemHoa) / 3;

                        if (sinhVien.DiemTrungBinh >= 8)
                        {
                            sinhVien.HocLuc = "Giỏi";
                        }
                        else if (sinhVien.DiemTrungBinh < 8 && sinhVien.DiemTrungBinh >= 6.5)
                        {
                            sinhVien.HocLuc = "Khá";
                        }
                        else if (sinhVien.DiemTrungBinh < 6.5 && sinhVien.DiemTrungBinh >= 5)
                        {
                            sinhVien.HocLuc = "Trung Bình";
                        }
                        else
                        {
                            sinhVien.HocLuc = "Yếu";
                        }
                        break;

                    case 5:
                        Console.WriteLine("Thông tin cũ: {0}", sinhVien.DiemLy);
                        Console.Write("Thay đổi thông tin mới cho điểm lý: ");
                        sinhVien.DiemLy = double.Parse(Console.ReadLine());
                        sinhVien.DiemTrungBinh = (sinhVien.DiemToan + sinhVien.DiemLy + sinhVien.DiemHoa) / 3;

                        if (sinhVien.DiemTrungBinh >= 8)
                        {
                            sinhVien.HocLuc = "Giỏi";
                        }
                        else if (sinhVien.DiemTrungBinh < 8 && sinhVien.DiemTrungBinh >= 6.5)
                        {
                            sinhVien.HocLuc = "Khá";
                        }
                        else if (sinhVien.DiemTrungBinh < 6.5 && sinhVien.DiemTrungBinh >= 5)
                        {
                            sinhVien.HocLuc = "Trung Bình";
                        }
                        else
                        {
                            sinhVien.HocLuc = "Yếu";
                        }
                        break;

                    case 6:
                        Console.WriteLine("Thông tin cũ: {0}", sinhVien.DiemHoa);
                        Console.Write("Thay đổi thông tin mới cho điểm hóa: ");
                        sinhVien.DiemHoa = double.Parse(Console.ReadLine());
                        sinhVien.DiemTrungBinh = (sinhVien.DiemToan + sinhVien.DiemLy + sinhVien.DiemHoa) / 3;

                        if (sinhVien.DiemTrungBinh >= 8)
                        {
                            sinhVien.HocLuc = "Giỏi";
                        }
                        else if (sinhVien.DiemTrungBinh < 8 && sinhVien.DiemTrungBinh >= 6.5)
                        {
                            sinhVien.HocLuc = "Khá";
                        }
                        else if (sinhVien.DiemTrungBinh < 6.5 && sinhVien.DiemTrungBinh >= 5)
                        {
                            sinhVien.HocLuc = "Trung Bình";
                        }
                        else
                        {
                            sinhVien.HocLuc = "Yếu";
                        }
                        break;

                    default:
                        break;
                }
               
                if(choose1 == -1)
                {
                    break;
                }
            }
            return "Cập nhật thành công!!".ToUpper();
        }

        //3. Xóa Sinh Viên Bởi ID
        public static string XoaSinhVienBoiID(ref List<Student> danhSachSinhVien, int id1)
        {
            if (danhSachSinhVien.Where(element => element.ID == id1).ToList().Count == 0)
            {
                return "Xóa không thành công!!! Không Tìm Được Mã Nhập Vào".ToUpper();
            }

            Student student = danhSachSinhVien.Find(element => element.ID == id1);
            danhSachSinhVien.Remove(student);

            return "Xóa thành công!!".ToUpper();
        }

        //4. Tìm Kiếm Sinh Viên Theo Tên
        public static string TimKiemSinhVienTheoTen(List<Student> danhSachSinhVien, string ten)
        {
            List<Student> students = danhSachSinhVien.Where(element => element.Ten.Equals(ten)).ToList();

            if (students.Count() == 0)
            {
                return "Không Tìm Được Tên Sinh viên này".ToUpper();
            }

            return HienThiDanhSachSinhVien(students);
        }

        //5. Sắp xếp sinh viên theo điểm trung bình
        public static string SapXepSinhVienTheoDiemTrungBinh(ref List<Student> danhSachSinhVien)
        {
            if (danhSachSinhVien.Count() == 0)
            {
                return "Danh Sách rỗng!! Sắp xếp không thành công".ToUpper();
            }

            var query = from sinhVien in danhSachSinhVien
                        orderby sinhVien.DiemTrungBinh
                        select sinhVien;

            danhSachSinhVien = query.ToList();

            return "sắp xếp thành công".ToUpper();
        }

        //6. Sắp xếp sinh viên theo tên
        public static string SapXepSinhVienTheoTen(ref List<Student> danhSachSinhVien)
        {
            if (danhSachSinhVien.Count() == 0)
            {
                return "Danh Sách rỗng!! Sắp xếp không thành công".ToUpper();
            }

            var query = from sinhVien in danhSachSinhVien
                        orderby sinhVien.Ten
                        select sinhVien;

            danhSachSinhVien = query.ToList();

            return "sắp xếp thành công".ToUpper();
        }

        //7. Hiển Thị Danh Sách Sinh Viên
        public static string HienThiDanhSachSinhVien(List<Student> danhSachSinhVien)
        {
            if (danhSachSinhVien.Count() == 0)
            {
                return "Danh sách này rỗng!!!!".ToUpper();
            }

            Console.WriteLine("Tất cả sinh viên liên quan:".ToUpper());

            foreach (var item in danhSachSinhVien)
            {
                Console.WriteLine(item);
            }

            return "Tất cả sinh viên đã được hiển thị".ToUpper();
        }

        //8. Ghi ra file "Student.txt"
        public static void GhiRaFile(List<Student> danhSachSinhVien, string pathOut)
        {
            using (StreamWriter streamWriter = new StreamWriter(pathOut))
            {
                foreach (var item in danhSachSinhVien)
                {
                    streamWriter.WriteLine(item.ID);
                    streamWriter.WriteLine(item.Ten);
                    streamWriter.WriteLine(item.GioiTinh);
                    streamWriter.WriteLine(item.Tuoi);
                    streamWriter.WriteLine(item.DiemToan);
                    streamWriter.WriteLine(item.DiemLy);
                    streamWriter.WriteLine(item.DiemHoa);
                    streamWriter.WriteLine(item.DiemTrungBinh);
                    streamWriter.WriteLine(item.HocLuc);
                }

                Console.WriteLine("Ghi File thành công".ToUpper());
            }
        }
    }
}
