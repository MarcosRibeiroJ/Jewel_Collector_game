using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject
{
    public class Empty : Cell
    {
        public Empty (int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
        }
        
        public override string ToString()
        {
            return " -- ";
        }
    }
}