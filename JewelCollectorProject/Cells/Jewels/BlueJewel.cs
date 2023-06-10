using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject;

namespace JewelCollectorProject.Cells.Jewels
{
    public class BlueJewel : Jewel
    {
        public BlueJewel() : base(10) {}
        public int FuelValue {get;} = 5;
        
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            return " JB ";
        }
    }
}