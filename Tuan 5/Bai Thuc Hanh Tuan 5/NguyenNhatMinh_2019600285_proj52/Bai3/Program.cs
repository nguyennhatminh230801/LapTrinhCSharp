using System;
using System.Text;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập số lượng đối tượng: ");
                    int soLuong = int.Parse(Console.ReadLine());

                    UocChungLonNhat[] uocChungLonNhats = new UocChungLonNhat[soLuong];

                    for(int i = 0; i < uocChungLonNhats.Length; i++)
                    {
                        Console.WriteLine("Nhập thông tin cho đối tượng thứ {0}:", i + 1);
                        uocChungLonNhats[i] = new UocChungLonNhat();//nếu từng phần tử 1 là đối tượng thì cũng phải tự cấp phát
                        uocChungLonNhats[i].Nhap();
                    }

                    for (int i = 0; i < uocChungLonNhats.Length; i++)
                    {
                        Console.WriteLine("Thông tin cho đối tượng thứ {0}:", i + 1);
                        Console.WriteLine(uocChungLonNhats[i]);
                    }

                    break;
                }
                catch (FormatException)
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
