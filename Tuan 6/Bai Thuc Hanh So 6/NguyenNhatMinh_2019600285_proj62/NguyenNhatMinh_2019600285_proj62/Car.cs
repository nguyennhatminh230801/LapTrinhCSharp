using System;
using System.Text;

namespace NguyenNhatMinh_2019600285_proj62
{
    class Car : Vehicles
    {
        public string color { get; set; }

        public Car() : base()
        {
            color = "DEFAULT_COLOR";
        }

        public Car(string id, string maker, string model, int year, double price, string color) : base(id, maker, model, year, price)
        {
            this.color = color;
        }

        public override void Input()
        {
            base.Input();
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Nhập Màu Sắc: ");
            color = Console.ReadLine();
        }

        public override void Output()
        {
            base.Output();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Màu sắc: {color}");
        }
    }
}
