using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells
{
    public class Empty : Cell
    {
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            return " -- ";
        }
    }
}