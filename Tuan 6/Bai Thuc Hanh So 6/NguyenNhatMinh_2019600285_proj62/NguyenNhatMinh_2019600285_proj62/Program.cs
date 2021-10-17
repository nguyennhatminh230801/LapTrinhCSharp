using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace NguyenNhatMinh_2019600285_proj62
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Vehicles> vehicleList = new List<Vehicles>();

            int choose = 8;

            while (true)
            {
                try
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine("=====================QUẢN LÝ VẬN TẢI========================");
                    Console.WriteLine("============================================================");
                    Console.WriteLine("=1. Nhập Dữ Liệu                                           =");
                    Console.WriteLine("=2. Hiển Thị Dữ Liệu                                       =");
                    Console.WriteLine("=3. Tìm Kiếm Theo ID                                       =");
                    Console.WriteLine("=4. Tìm Kiếm Theo Maker                                    =");
                    Console.WriteLine("=5. Sắp Xếp Theo Price                                     =");
                    Console.WriteLine("=6. Sắp Xếp Theo Year                                      =");
                    Console.WriteLine("=7. Kết Thúc                                               =");
                    Console.WriteLine("============================================================");
                    Console.Write("Mời bạn nhập lựa chọn: ");
                    choose = int.Parse(Console.ReadLine());

                    switch (choose)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(NhapDuLieu(ref vehicleList));
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine(HienThiDuLieu(vehicleList));
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine(TimKiemXeTheoID(vehicleList));
                            break;

                        case 4:
                            Console.Clear();
                            Console.WriteLine(TimKiemXeTheoMaker(vehicleList));
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine(SapXepTheoPrice(vehicleList));
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine(SapXepTheoYear(vehicleList));
                            break;

                        case 7:
                            Console.Clear();
                            int choose2 = 2;
                            Console.WriteLine("Bạn Muốn Thoát Chương Trình?");
                            Console.WriteLine("1. Có");
                            Console.WriteLine("2. Không");
                            choose2 = int.Parse(Console.ReadLine());

                            if (choose2 == 1)
                            {
                                break;
                            }
                            else if (choose2 == 2)
                            {
                                choose = 8;
                            }
                            else
                            {
                                throw new Exception("Lựa chọn không hợp lệ!!!");
                            }
                            break;
                        default:
                            break;
                    }
                    
                    if(choose == 7)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn phải nhập theo định dạng số!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }

        public static string SapXepTheoYear(List<Vehicles> vehicleList)
        {
            if (vehicleList.Count == 0)
            {
                return "Danh sách này trống".ToUpper();
            }

            var query = (from vehicle in vehicleList
                         orderby vehicle.year
                         select vehicle).ToList();

            Console.WriteLine("Danh sách sau khi sắp xếp: ");

            int i = 1;

            foreach (var item in query)
            {
                Console.WriteLine($"Thông tin xe tải thứ {i++}: ");
                item.Output();
            }

            return "Sắp xếp thành công".ToUpper();
        }

        public static string SapXepTheoPrice(List<Vehicles> vehicleList)
        {
            if (vehicleList.Count == 0)
            {
                return "Danh sách này trống".ToUpper();
            }

            var query = (from vehicle in vehicleList
                         orderby vehicle.price
                         select vehicle).ToList();

            Console.WriteLine("Danh sách sau khi sắp xếp: ");

            int i = 1;

            foreach (var item in query)
            {
                Console.WriteLine($"Thông tin xe tải thứ {i++}: ");
                item.Output();
            }

            return "Sắp xếp thành công".ToUpper();
        }

        public static string TimKiemXeTheoMaker(List<Vehicles> vehicleList)
        {
            if (vehicleList.Count == 0)
            {
                return "Danh sách này trống".ToUpper();
            }

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập Maker: ");
            string maker = Console.ReadLine();

            var query = (from vehicle in vehicleList
                         where vehicle.maker == maker
                         select vehicle).ToList();

            if (query.Count == 0)
            {
                return "Không tìm được xe nào có hãng sản xuất này".ToUpper();
            }
            else
            {
                Console.WriteLine("Các xe do Hãng Sản Xuất Này Làm: ");

                int i = 1;

                foreach (var item in query)
                {
                    Console.WriteLine($"Thông tin xe tải thứ {i++}: ");
                    item.Output();
                }


            }
            return "Tìm kiếm thành công".ToUpper();
        }

        public static string TimKiemXeTheoID(List<Vehicles> vehicleList)
        {
            if (vehicleList.Count == 0)
            {
                return "Danh sách này trống".ToUpper();
            }

            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập ID: ");
            string id = Console.ReadLine();

            var vehicle = vehicleList.Find(element => element.id == id);

            if (vehicle == null)
            {
                return "Không tìm được xe".ToUpper();
            }
            else
            {
                Console.WriteLine("Thông tin xe: ");
                Console.WriteLine(vehicle);
            }
            return "Tìm kiếm thành công".ToUpper();
        }

        public static string HienThiDuLieu(List<Vehicles> vehicleList)
        { 
            Console.OutputEncoding = Encoding.UTF8;
            if (vehicleList.Count == 0)
            {
                return "Danh sách này trống".ToUpper();
            }

            int i = 1;

            foreach (var item in vehicleList)
            {
                Console.WriteLine($"Thông tin xe thứ {i++}: ");
                item.Output();
            }

            return "Đã hiển thị tất cả xe".ToUpper();
        }

        public static string NhapDuLieu(ref List<Vehicles> vehicleList)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Nhập dữ liệu 3 Car: ");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Nhập dữ liệu cho Car thứ {i}: ");
                Car car = new Car();
                car.Input();
                vehicleList.Add(car);
            }

            Console.WriteLine("Nhập dữ liệu 3 Truck: ");

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Nhập dữ liệu cho Truck thứ {i}: ");
                Truck truck = new Truck();
                truck.Input();
                vehicleList.Add(truck);
            }

            return "Thành công".ToUpper();
        }
    }
}
