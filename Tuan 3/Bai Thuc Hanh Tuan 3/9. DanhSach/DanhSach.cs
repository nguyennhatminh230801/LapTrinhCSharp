using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _9._DanhSach
{
    class DanhSach
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập dãy số thực: ");
                    List<double> array1 = Console.ReadLine().Trim().Split(" ")
                        .Select(element => double.Parse(element)).ToList();

                    array1.Sort();

                    //Kiểm tra và loại bỏ số âm
                    List<double> array2 = array1.Where(element => element >= 0).ToList();
                    Console.WriteLine((array1.Count == array2.Count) ? "Mảng không có phần tử âm" : "Mảng đã lọc bỏ phần tử âm");
                    array1 = array2;

                    //Nhập và chèn x
                    Console.Write("Nhập X: ");
                    double x = double.Parse(Console.ReadLine());

                    int n = array1.Count;

                    int pos1 = 0;

                    for(int i = 0; i < n; i++)
                    {
                        if(array1[i] < x)
                        {
                            pos1 = i + 1;
                        }
                    }

                    array1.Insert(pos1, x);

                    Console.WriteLine("Sau khi chèn: {0}", string.Join(",", array1.Select(element => element.ToString()).ToArray()) );
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn không được nhập sai kiểu số!!!!");
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
