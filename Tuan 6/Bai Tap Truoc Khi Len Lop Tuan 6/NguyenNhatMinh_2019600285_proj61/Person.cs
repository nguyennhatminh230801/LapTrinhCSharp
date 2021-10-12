using System;
using System.Text;

namespace NguyenNhatMinh_2019600285_proj61
{
    class Person
    {
        static private int id1 = 0;
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public Person()
        {
            Console.InputEncoding = Encoding.UTF8;
            id1++;
            id = id1;
            name = "DEFAULT_NAME";
            address = "DEFAULT_ADDRESS";
        }

        public Person(string name, string address)
        {
            Console.InputEncoding = Encoding.UTF8;
            id1++;
            id = id1;
            this.name = name;
            this.address = address;
        }

        public virtual void Input()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Nhập Tên: ");
            name = Console.ReadLine().Trim();
            Console.Write("Nhập Địa Chỉ: ");
            address = Console.ReadLine().Trim();
        }

        public virtual void Output()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"ID: {id}" +
                $"\nTên: {name}" +
                $"\nĐịa Chỉ: {address}");
        }
    }
}
