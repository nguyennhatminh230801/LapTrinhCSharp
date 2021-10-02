using System;
using System.Text;

namespace CanBacHai
{
    class CanBacHai
    {
        static void Main(string[] args)
        {
            //Tieng Viet
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            while (true)
            {
                try
                {
                    Console.Write("Nhập N: ");
                    float n = float.Parse(Console.ReadLine());
                    Console.Write("Nhập Sai Số: ");
                    float saiso = float.Parse(Console.ReadLine());

                    float Ketqua = 1;

                    while((float)(Math.Abs(Ketqua * Ketqua - n) / n) >= saiso)
                    {
                        Ketqua += (n / Ketqua - Ketqua) / 2;
                    }

                    Console.WriteLine("Kết quả là {0}", Ketqua);
                    break;
                }
                catch (FormatException) //Không thể Parse số
                {
                    Console.WriteLine("Số bạn nhập vào không đúng!!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine("Kết thúc chương trình");
            Console.ReadKey(true);
        }
    }
}
