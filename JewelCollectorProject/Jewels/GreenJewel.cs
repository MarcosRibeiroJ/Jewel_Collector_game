using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Jewels
{
    public class GreenJewel : Cell, IJewel
    {
        public override string ToString()
        {
            return " JG ";
        }
    }
}