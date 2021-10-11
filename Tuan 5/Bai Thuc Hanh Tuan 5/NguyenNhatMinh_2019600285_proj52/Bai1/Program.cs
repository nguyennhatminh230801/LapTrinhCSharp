using System;
using System.Text;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while(true)
            {
                try
                {
                    Employee employee = new Employee();

                    Console.WriteLine("Nhập Thông Tin Nhân Viên: ");
                    employee.Input();
                    Console.WriteLine("Thông Tin Nhân Viên: ");
                    employee.Output();

                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Không được sai định dạng số");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    continue;
                }
            }
        }
    }
}
