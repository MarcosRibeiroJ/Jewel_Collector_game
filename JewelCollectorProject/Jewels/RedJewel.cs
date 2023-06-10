using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Jewels
{
    public class RedJewel : Jewel
    {
        public RedJewel() : base(100){}

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            return " JR ";
        }
    }
}