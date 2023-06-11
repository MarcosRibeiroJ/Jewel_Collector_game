using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Jewels
{
    public class RedJewel : Jewel
    {
        public RedJewel() : base(100){}

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            return " JR ";
        }
    }
}