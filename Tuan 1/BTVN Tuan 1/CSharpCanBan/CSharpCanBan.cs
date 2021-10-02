using System;
using System.Text;

namespace CSharpCanBan
{
    class CSharpCanBan
    {
        static void Main(string[] args)
        {
            //Tiếng Việt
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("\tMèo con đi học " +
                              "\nHôm nay trời nắng chang chang " +
                              "\nMèo con đi học chẳng mang thứ gì  " +
                              "\nChỉ mang một cai bút chì " +
                              "\nVà mang một mẩu banh my con con.");

            Console.ReadKey(true);
        }
    }
}
