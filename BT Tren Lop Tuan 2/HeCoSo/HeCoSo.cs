using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace HeCoSo
{
    class HeCoSo
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    int choice = 3;

                    Console.WriteLine("============================================================");
                    Console.WriteLine("Chương trình chuyển Hệ Cơ Số: ");
                    Console.WriteLine("1. Hệ 10 sang Hệ 2");
                    Console.WriteLine("2. Hệ 2 sang Hệ 10");
                    Console.Write("Mời bạn nhập lựa chọn: ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            DecimalToBinary();
                            break;
                        case 2:
                            Console.Write("Nhập xâu ký tự: ");
                            string binaryNumber = Console.ReadLine().Trim();

                            if(!binaryNumber.All(Char.IsDigit))
                            {
                                throw new Exception("Nhập Không Đúng Định Đạng!! Phát hiện ký tự khồng phải số");
                            }

                            Int64 value2 = BinaryToDecimal(binaryNumber);
                            Console.WriteLine("Giá trị cần tìm: {0}", value2);
                            break;

                        default:
                            throw new Exception("Lựa chọn không hợp lệ!!!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn phải nhập vào dạng số");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public static Int64 BinaryToDecimal(string binaryNumber)
        {
            Int64 answer = 0;

            char[] res = binaryNumber.ToCharArray();
            Array.Reverse(res);
            
            List<Int64> list1 = res.Select(element => element.ToString()).ToList()
                .Select(phanTu => Int64.Parse(phanTu)).ToList();

            Int64 startBin = 1;

            foreach (var item in list1)
            {
                answer += item * startBin;
                startBin *= 2;
            }

            return answer;
        }

        public static void DecimalToBinary()
        {
            Int64 value1;
            string answer = "";
            Console.Write("Nhập số N: ");
            Int64 number = Int64.Parse(Console.ReadLine());

            while (number != 0)
            {
                value1 = number % 2;
                answer += value1.ToString();
                number /= 2;
            }

            char[] res = answer.ToCharArray();
            Array.Reverse(res);

            answer = string.Join("", res);

            Console.WriteLine("Giá trị cần tìm: {0}", answer);
        }
    }
}
