using System;

namespace Bai2
{
    class PhuongTrinhBac2
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public PhuongTrinhBac2()
        {
            a = b = c = 0;
        }

        public PhuongTrinhBac2(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public string Giai()
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                    {
                        return "Phương trình này vô số nghiệm";
                    }
                    else
                    {
                        return "Phương trình này vô nghiệm";
                    }
                }
                else
                {
                    int value1 = -c / b;
                    return $"Phương trình này có 1 nghiệm: {value1}";
                }
            }
            else
            {
                double delta = b * b - 4 * a * c;

                if (delta < 0)
                {
                    return "Phương trình này vô nghiệm";
                }
                else if (delta == 0)
                {
                    int value1 = -b / (2 * a);
                    return $"Phương trình này có 1 nghiệm: {value1}";
                }
                else
                {
                    double value1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double value2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    return $"Phương trình này có 2 nghiệm: " +
                        $"\nx1 = {value1}" +
                        $"\nx2 = {value2}";
                }
            }
        }
    }
}
