using System;
using System.Text;

namespace _8._Chuoi
{
    class Chuoi
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                try
                {
                    Console.Write("Nhập dãy: ");
                    string s = Console.ReadLine().Trim();
                    Console.WriteLine((isPalindrome(s)) ? "Dãy đối xứng" : "Dãy không đối xứng");
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

        public static bool isPalindrome(string str1)
        {
            int n = str1.Length;

            for(int i = 0; i < n; i++)
            {
                if(str1[i] != str1[n - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
