using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Jewels
{
    public class BlueJewel : Jewel
    {
        public int JewelValue {get;} = 10;
        
        public override string ToString()
        {
            return " JB ";
        }
    }
}