using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Jewels
{
    public class GreenJewel : Jewel
    {
        public GreenJewel() : base(50){}

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            return " JG ";
        }
    }
}