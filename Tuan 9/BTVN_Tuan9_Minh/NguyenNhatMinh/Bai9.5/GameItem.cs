using System;
using System.Collections.Generic;
using System.Text;

namespace Bai9._5
{
    internal class GameItem
    {
        public string ImageAddress { get; set; }
        public string GameName { get; set; }
        public bool Choosed { get; set; }

        public GameItem()
        {
            ImageAddress = null;
            GameName = null;
            Choosed = false;
        }

        public GameItem(string imageAddress, string gameName)
        {
            ImageAddress = imageAddress;
            GameName = gameName;
            Choosed = false;
        }

        public GameItem(string imageAddress, string gameName, bool choosed)
        {
            ImageAddress = imageAddress;
            GameName = gameName;
            Choosed = choosed;
        }
    }
}
