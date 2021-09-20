using System;
using System.Text;

namespace BTTrenLopTuan2
{
    class HinhChuNhat
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập Chiều Dài: ");
                    float dai = float.Parse(Console.ReadLine());

                    Console.Write("Nhập Chiều Rộng: ");
                    float rong = float.Parse(Console.ReadLine());

                    if (dai < 0 || rong < 0)
                    {
                        throw new Exception("Bạn không được nhập các cạnh có độ dài bé hơn 0!!!");
                    }

                    float chuVi = (dai + rong) * 2;
                    float dienTich = dai * rong;

                    Console.WriteLine("Chu vi là : {0}" +
                        "\nDiện Tích Là: {1}", chuVi, dienTich);
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Bạn phải nhập vào dạng số!!!");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
