using System;
using System.Text;

namespace XepLoaiHocSinh
{
    class XepLoaiHS
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
                    Console.Write("Nhập Điểm: ");
                    float diem = float.Parse(Console.ReadLine());

                    if(diem < 0 || diem > 10)
                    {
                        throw new Exception("Điểm Phải Trong Khoảng [0, 10]");
                    }

                    string answer = "Xếp loại: ";

                    if (diem >= 8)
                    {
                        answer += "Giỏi";   
                    }
                    else if (diem < 8 && diem >= 6.5)
                    {
                        answer += "Khá";
                    }
                    else if (diem < 6.5 && diem >= 5)
                    {
                        answer += "Trung Bình";
                    }
                    else
                    {
                        answer += "Yếu";
                    }

                    Console.WriteLine(answer);
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
