using System;
using System.IO;
using System.Text;

namespace XuLyFile
{
    class XuLyFile
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string inputFile = @"c:\source\test.txt";
            string outputFile = @"d:\target\test1.txt";

            string inputFile1 = @"c:\source\testRes.txt";
            string outputFile1 = @"d:\target\testRes1.txt";


            StreamReader streamReader = null;
            StreamWriter streamWriter = null;

            try
            {
                //1. File copy
                File.Copy(inputFile, outputFile);

                //2. StreamReader
                streamReader = new StreamReader(inputFile1);
                streamWriter = new StreamWriter(outputFile1);

                //https://stackoverflow.com/questions/2425863/what-is-character-for-end-of-file-of-filestream

                while (!streamReader.EndOfStream)
                {
                    streamWriter.WriteLine(streamReader.ReadLine());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bạn phải nhập vào dạng số!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (streamReader != null)
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
