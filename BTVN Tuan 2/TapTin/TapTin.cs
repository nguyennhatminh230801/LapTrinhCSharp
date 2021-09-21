using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace TapTin
{
    class TapTin
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            StreamReader streamReader = null;
            StreamWriter streamWriter = null;

            try
            {
                string res1 = @"d:\XuLyFileCS.txt";

                streamReader = new StreamReader(res1);

                List<List<int>> map2d = new List<List<int>>();

                int n = int.Parse(streamReader.ReadLine());
                int m = int.Parse(streamReader.ReadLine());

                for(int i = 0; i < n; i++)
                {
                    List<int> array1 = streamReader.ReadLine().Trim().Split(" ")
                        .Select(elem => int.Parse(elem)).ToList();

                    if(array1.Count != m)
                    {
                        throw new Exception("Nhập ma trận không đúng");
                    }

                    map2d.Add(array1);
                }

                streamReader.Close();

                int TongMaTran = map2d.Select(elem => elem.Sum()).Sum();

                //cách thêm vào đuôi
                streamWriter = File.AppendText(res1);

                streamWriter.WriteLine("Tổng ma trận: {0}", TongMaTran);

                Console.WriteLine("Kết thúc thành công!!!");

                streamWriter.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("Bạn phải nhập dạng số!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
