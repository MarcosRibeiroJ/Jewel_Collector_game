using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Jewels
{
    public class GreenJewel : Jewel
    {
        public int JewelValue {get;} = 50;

        public override string ToString()
        {
            return " JG ";
        }
    }
}