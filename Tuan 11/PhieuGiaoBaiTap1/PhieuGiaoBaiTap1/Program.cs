using System;
using System.Collections.Generic;
using System.Linq;

namespace PhieuGiaoBaiTap1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Brand> brands = new List<Brand>()
            {
                new Brand(){ Name = "VinGroup", ID = 1 },
                new Brand(){ Name = "SamSung", ID = 2 },
                new Brand(){ Name = "FPT", ID = 3 }
            };

            List<Product> products = new List<Product>()
            {
                new Product(1, "O to", 400, new List<string>(){"Do", "Trang", "Den"}, 1),
                new Product(2, "Dien Thoai", 400, new List<string>(){"Den", "Xanh"}, 2),
                new Product(3, "May Giat", 500, new List<string>(){"Trang"}, 2),
                new Product(4, "Tu Lanh", 200, new List<string>(){"Trang", "Xam"}, 2),
                new Product(5, "Laptop", 300, new List<string>(){"Xam", "Do", "Den"}, 3),
                new Product(6, "Dieu Hoa", 500, new List<string>(){"Trang"}, 2),
                new Product(7, "Xe May", 600, new List<string>(){"Trang"}, 1)
            };

            //1. In ra danh sach san pham
            var query1 = from elem in products
                         select elem;

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }

            //2. Lấy ra tên SP
            var query2 = from elem in products
                         select elem.Name;

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

            //3. Trả về kiểu vô danh vởi new{}
            var query3 = from elem in products
                         select new
                         {
                             maID = elem.ID,
                             giaban = elem.Price
                         };

            foreach (var item in query3)
            {
                Console.WriteLine(item.maID + "-" + item.giaban);
            }

            //4. In ra sản phẩm có giá 400
            var query4 = from elem in products
                         where elem.Price == 400
                         select elem;

            foreach (var item in query4)
            {
                Console.WriteLine(item);
            }

            //5. Sắp xếp theo chiều giảm dần của giá bán
            var query5 = from elem in products
                         orderby elem.Price descending
                         select elem;

            foreach (var item in query5)
            {
                Console.WriteLine(item);
            }

            //6 Lấy ra sản phẩm <=500, nhóm sản phẩm theo thương hiệu(cùng Brand)
            var query6 = from elem in products
                         where elem.Price <= 500
                         group elem by elem.Brand;

            foreach (var group in query6)
            {
                Console.WriteLine(group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine($"{item.Name} - {item.Price}");
                }
            }

            //8 Lấy ra Tên Sản Phẩm, Tên Thương Hiệu, Giá Bán
            var query7 = from elem in products
                         join elem2 in brands
                         on elem.ID equals elem2.ID
                         select new
                         {
                             name = elem.Name,
                             brand = elem2.Name,
                             price = elem.Price
                         };

            foreach (var item in query7)
            {
                Console.WriteLine($"{item.name, 10}-{item.price,4}-{item.brand, 12}");
            }
        }
    }
}
