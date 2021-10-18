using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenNhatMinh_2019600285_proj62
{
    class Truck : Vehicles
    {
        public int truckload { get; set; }

        public Truck() : base()
        {
            truckload = 0;
        }

        public Truck(string id, string maker, string model, int year, double price, int truckload) : base(id, maker, model, year, price)
        {
            this.truckload = truckload;
        }

        public override void Input()
        {
            base.Input();
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập Tải Trọng: ");
            truckload = int.Parse(Console.ReadLine());
        }

        public override void Output()
        {
            base.Output();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Tải Trọng: {truckload}");
        }
    }
}
