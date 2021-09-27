using System;
using System.Text;

namespace _4._CuuChuong
{
    class CuuChuong
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    Console.Write("{0} x {1} = {2, -7}", i, j, i * j);
                }
                Console.WriteLine();
            }
        }
    }
}
