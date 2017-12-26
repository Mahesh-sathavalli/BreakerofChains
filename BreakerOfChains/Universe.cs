using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakerOfChains;

namespace BreakerOfChains
{
    //this is the Universe where the kingdoms and Ruler of the universe is resided
    public class Universe
    {
        

        public Kingdom KingOfall { get; set; }

        public static Dictionary<string, Kingdom> kingdoms { get; set; }
        public static HighPriest Priest { get; set; }
        private const int MaxSupport = 2;
        static Universe()
        {
            kingdoms = new Dictionary<string, Kingdom>();
            Kingdom Space = new Kingdom("SPACE", "Gorilla", "Shan");
            kingdoms.Add("SPACE", Space);

            Kingdom Land = new Kingdom("LAND", "Panda");
            kingdoms.Add("LAND", Land);

            Kingdom Water = new Kingdom("WATER", "Octopus");
            kingdoms.Add("WATER", Water);

            Kingdom Ice = new Kingdom("ICE", "Mammoth");
            kingdoms.Add("ICE", Ice);

            Kingdom Air = new Kingdom("AIR", "Owl");
            kingdoms.Add("AIR", Air);

            Kingdom Fire = new Kingdom("FIRE", "Dragon");
            kingdoms.Add("FIRE", Fire);

            Priest = new HighPriest();
        }

        //check the majority and set the ruler5
        
    }
}
