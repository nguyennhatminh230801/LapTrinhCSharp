using System;
using System.Text;
using System.Linq;

namespace BTVN_Tuan_2
{
    class Mang
    {
        static void Main(string[] args)
        {
            //tieng viet
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập Số Lượng: ");
                    Int32 n = Int32.Parse(Console.ReadLine());

                    Int32[] array1;

                    do
                    {
                        Console.Write("Nhập dãy số (phải nhập cùng 1 dòng): ");

                        //ý tưởng:
                        //đây là cách nhập 1 dãy số trên 1 dòng : VD: 1 2 3
                        //B1: Nhận 1 chuỗi đầu vào
                        //B2: Trim() để thu gọn khoảng trắng
                        //B3: Split() để tách thành 1 mảng chuỗi VD: ["1", "2", "3"] tham số truyền vào split là khoảng trắng
                        //B4: Where để lọc phần tử mảng theo hàm điều kiện
                        //Hàm điều kiện ở đây là lọc phần tử trắng và phần tử có ký tự không phải số
                        //Hàm biến đổi ở đây là stringNumber => Int32.Parse(stringNumber)
                        // Hàm biến đổi này thao tác biến đổi phần tử sang số nguyên
                        //B5: ToArray() để chuyển thành 1 array

                        //Để sử dụng Select() thì cũng cần System.Linq
                        array1 = Array.ConvertAll(
                                Console.ReadLine().Trim().Split(" ").Where(phantu =>
                                {
                                    return !String.IsNullOrWhiteSpace(phantu) && phantu.All(char.IsDigit);
                                }).ToArray(),
                                (phanTuMang) => Int32.Parse(phanTuMang)
                            );
                    }
                    while (array1.Length != n);

                    //Note: sử dụng System.Linq thì mới gọi được các hàm dưới đây
                    Console.WriteLine("Phần tử lớn nhất trong mảng là: {0}" +
                        "\nPhần tử bé nhất trong mảng là: {1}" +
                        "\nTổng phần tử trong mảng là: {2}", array1.Max(),
                        array1.Min(),
                        array1.Sum());


                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn phải nhập dạng số!!!");
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
