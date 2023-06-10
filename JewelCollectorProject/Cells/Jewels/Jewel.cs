using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Jewels
{
    public abstract class Jewel : Cell
    {
        public int JewelValue {get; private set;}
        public Jewel(int value)
        {
            this.JewelValue = value;
        }
    }
}