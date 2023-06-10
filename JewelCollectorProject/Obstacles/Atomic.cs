using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Obstacles
{
    public class Atomic : Cell
    {
        public static int DamageArea {get;} = 10;
        public static int Damage {get;} = 30;
        
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            return " !! ";
        }
    }
}