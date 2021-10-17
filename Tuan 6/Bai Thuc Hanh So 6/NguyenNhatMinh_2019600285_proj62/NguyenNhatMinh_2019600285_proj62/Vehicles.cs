using System;
using System.Text;

namespace NguyenNhatMinh_2019600285_proj62
{
    class Vehicles : IVehicle
    {
        public string id { get; set; }
        public string maker { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public double price { get; set; }

        public Vehicles()
        {
            id = "DEFAULT_ID";
            maker = "DEFAULT_MAKER";
            model = "DEFAULT_MODEL";
            year = 0;
            price = 0;
        }

        public Vehicles(string id)
        {
            this.id = id;
            maker = "DEFAULT_MAKER";
            model = "DEFAULT_MODEL";
            year = 0;
            price = 0;
        }

        public Vehicles(string id, string maker, string model, int year, double price) : this(id)
        {
            this.maker = maker;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        public virtual void Input()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập ID: ");
            id = Console.ReadLine();
            Console.Write("Nhập Nhà Sản Xuất: ");
            maker = Console.ReadLine();
            Console.Write("Nhập Mẫu Sản Xuất: ");
            model = Console.ReadLine();
            Console.Write("Nhập Năm Sản Xuất: ");
            year = int.Parse(Console.ReadLine());
            Console.Write("Nhập Giá Thành: ");
            price = double.Parse(Console.ReadLine());
        }

        public virtual void Output()
        {
            Console.WriteLine(this);
        }

        public override bool Equals(object obj)
        {
            return id.Equals((obj as Vehicles).id);
        }

        public override string ToString()
        {
            return $"Mã ID: {id}" +
                $"\nNhà Sản Xuất: {maker}" +
                $"\nMẫu Sản Xuất: {model}" +
                $"\nNăm Sản Xuất: {year}" +
                $"\nGiá Thành: {price}";
        }

    }
}
