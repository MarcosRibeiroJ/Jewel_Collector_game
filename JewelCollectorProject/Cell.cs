using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject
{
    public abstract class Cell
    {
        public int X {get; set;}
        public int Y {get; set;}
        
        public abstract override string ToString();
    }
}