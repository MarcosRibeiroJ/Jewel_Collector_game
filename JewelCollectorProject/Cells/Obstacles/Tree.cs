using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Obstacles
{
    public class Tree : Cell
    {
        public int FuelValue {get;} = 3;
        public bool isRechargeable {get; set;} = true;
        
        public override string ToString()
        {
            Console.BackgroundColor = isRechargeable ? ConsoleColor.DarkGreen : ConsoleColor.Black;
            Console.ForegroundColor = isRechargeable ? ConsoleColor.DarkRed : ConsoleColor.White;
            return " $$ ";
        }
    }
}