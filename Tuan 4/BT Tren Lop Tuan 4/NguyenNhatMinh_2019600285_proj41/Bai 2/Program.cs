using System;
using System.Text;

namespace Bai_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Circle circle = new Circle(30);

            Console.WriteLine($"Diện tích là: {circle.Area()}" +
                $"\nChu vi là: {circle.Perimeter()}");
        }
    }
}
