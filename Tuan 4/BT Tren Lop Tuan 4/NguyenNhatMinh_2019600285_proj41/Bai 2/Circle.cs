using System;

namespace Bai_2
{
    class Circle
    {
        public double radius { get; set; }

        public Circle()
        {
            radius = 0;
        }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public double Perimeter()
        {
            return 2d * Math.PI * radius;
        }
    }
}
