using System;
using System.Text;

namespace Bai_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Person person = new Person();

            person.Input();
            person.Output();
            person.CheckAge();

        }
    }
}
