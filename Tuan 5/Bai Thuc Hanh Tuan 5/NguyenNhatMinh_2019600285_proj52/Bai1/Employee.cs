using System;

namespace Bai1
{
    class Employee
    {
        private const int PRICE = 50;
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int workingDays { get; set; }
        public double salary
        {
            get
            {
                return PRICE * workingDays;
            }
        }

        public Employee()
        {
            id = "DEFAULT_ID";
            name = "DEFAULT_NAME";
            age = 0;
            workingDays = 0;
        }

        public Employee(string id, string name, int age, int workingDays)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.workingDays = workingDays;
        }

        public void Input()
        {
            Console.Write("Nhập vào Mã Nhân Viên: ");
            id = Console.ReadLine().Trim();
            Console.Write("Nhập vào Tên Nhân Viên: ");
            name = Console.ReadLine().Trim();
            Console.Write("Nhập vào Tuổi: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Nhập vào Số Ngày Làm Việc: ");
            workingDays = int.Parse(Console.ReadLine());
        }

        public void Output()
        {
            Console.WriteLine($"Mã Nhân Viên: {id}" +
                $"\nTên Nhân Viên: {name}" +
                $"\nTuổi: {age}" +
                $"\nSố Ngày Làm Việc: {workingDays}" +
                $"\nLương: {salary}");
        }
    }
}
