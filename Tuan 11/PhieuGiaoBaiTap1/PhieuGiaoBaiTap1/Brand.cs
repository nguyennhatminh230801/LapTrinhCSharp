using System;
using System.Collections.Generic;
using System.Text;

namespace PhieuGiaoBaiTap1
{
    class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Brand()
        {
            ID = 0;
            Name = "Default Name";
        }

        public Brand(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
