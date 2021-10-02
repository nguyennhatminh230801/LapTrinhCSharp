using System;

namespace Bai_1
{
    class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public Person()
        {
            id = "";
            name = "";
            age = 0;
            email = "";
            address = "";
        }

        public Person(string id)
        {
            this.id = id;
            name = "";
            age = 0;
            email = "";
            address = "";
        }

        public Person(string id, string name, int age, string email, string address)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.address = address;
        }

        public void Input()
        {
            Console.Write("Nhập ID: ");
            id = Console.ReadLine().Trim();
            Console.Write("Nhập Tên: ");
            name = Console.ReadLine().Trim();
            Console.Write("Nhập Tuổi: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Nhập Email: ");
            email = Console.ReadLine().Trim();
            Console.Write("Nhập địa chỉ: ");
            address = Console.ReadLine().Trim();
        }

        public void Output()
        {
            Console.WriteLine(
                $"ID: {id}" +
                $"\nTên: {name}" +
                $"\nTuổi: {age}" +
                $"\nEmail: {email}" +
                $"\nĐịa Chỉ: {address}"
            );
        }

        public void CheckAge()
        {
            Console.WriteLine((age >= 18) ? "Bạn đủ tuổi bầu cử" : "Bạn còn nhỏ");
        }
    }
}
