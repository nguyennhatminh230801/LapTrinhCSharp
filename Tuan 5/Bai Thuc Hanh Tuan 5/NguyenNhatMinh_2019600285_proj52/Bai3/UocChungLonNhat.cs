using System;

namespace Bai3
{
    class UocChungLonNhat
    {
        public int soThuNhat{ get; set; }
        public int soThuHai { get; set; }

        public UocChungLonNhat()
        {
            soThuNhat = 0;
            soThuHai = 0;
        }

        public UocChungLonNhat(int soThuNhat, int soThuHai)
        {
            this.soThuNhat = soThuNhat;
            this.soThuHai = soThuHai;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhập số thứ nhất: ");
            soThuNhat = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập số thứ hai: ");
            soThuHai = int.Parse(Console.ReadLine());
        }

        public int TimUSCLN()
        {
            if (soThuNhat == 0)
            {
                return soThuHai;
            }
            else if(soThuHai == 0)
            {
                return soThuNhat;
            }
            else
            {
                int value1 = soThuNhat, value2 = soThuHai;

                while(value1 != value2)
                {
                    if (value1 > value2)
                    {
                        value1 -= value2;
                    }
                    else
                    {
                        value2 -= value1;
                    }
                }

                return value1;
            }
        }

        public override string ToString()
        {
            return $"Số thứ nhất: {soThuNhat}" +
                $"\nSố thứ hai: {soThuHai}" +
                $"\nƯóc chung lớn nhất: {this.TimUSCLN()}";
        }
    }
}
