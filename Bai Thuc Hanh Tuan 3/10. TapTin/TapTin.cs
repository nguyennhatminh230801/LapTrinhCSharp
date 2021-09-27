using System;
using System.Text;
using System.IO;

namespace _10._TapTin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string input = @"D:\Github Clone\LapTrinhCSharp\Bai Thuc Hanh Tuan 3\10. TapTin\VanBanInput.txt";
            string output = @"D:\Github Clone\LapTrinhCSharp\Bai Thuc Hanh Tuan 3\10. TapTin\VanBanOutput.txt";
            StreamReader streamReader = null;
            StreamWriter streamWriter = null;

            try
            {
                streamReader = new StreamReader(input);
                streamWriter = new StreamWriter(output);

                while(!streamReader.EndOfStream)
                {
                    streamWriter.WriteLine(streamReader.ReadLine().ToUpper());
                }

                
                streamReader.Close();
                streamWriter.Close();

                streamReader = new StreamReader(output);
                
                int TotalWord = 0;

                while (!streamReader.EndOfStream)
                {
                    TotalWord += streamReader.ReadLine().Trim().Split(" ").Length;
                }
                
                //1 file không thể được mở cùng lúc bởi StreamReader và StreamWriter
                streamReader.Close();

                streamWriter = File.AppendText(output);

                streamWriter.WriteLine("Tổng số từ: {0}", TotalWord);
                streamWriter.Close()
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm ra được đường dẫn file");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bạn không được nhập sai kiểu số!!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if(streamReader != null)
                {
                    streamReader.Close();
                }

                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
    }
}
