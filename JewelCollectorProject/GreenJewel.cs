using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject
{
    public class GreenJewel : Cell
    {
        public GreenJewel(int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
        }

        public override string ToString()
        {
            return " JG";
        }
    }
}