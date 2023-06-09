using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Obstacles
{
    public class Tree : Cell
    {
        public int FuelValue {get;} = 3;
        public bool isRechargeable {get; set;} = true;
        
        public override string ToString()
        {
            return " $$ ";
        }
    }
}