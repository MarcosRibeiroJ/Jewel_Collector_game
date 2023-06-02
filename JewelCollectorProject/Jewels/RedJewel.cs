using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Jewels
{
    public class RedJewel : Jewel
    {
        public int JewelValue {get;} = 100;
        
        public override string ToString()
        {
            return " JR ";
        }
    }
}