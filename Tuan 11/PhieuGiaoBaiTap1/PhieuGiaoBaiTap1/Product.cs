using System;
using System.Collections.Generic;
using System.Text;

namespace PhieuGiaoBaiTap1
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<string> Color { get; set; }
        public int Brand { get; set; }

        public Product()
        {
            ID = 0;
            Name = "Default Name";
            Price = 0.0;
            Color = null;
            Brand = 0;
        }

        public Product(int iD, string name, double price, List<string> color, int brand)
        {
            ID = iD;
            Name = name;
            Price = price;
            Color = color;
            Brand = brand;
        }

        public override string ToString()
        {
            return $"{ID,3}{Name,12}{Price,5}{Brand,2}{string.Join(",", Color)}";
        }
    }
}
