using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject
{
    public class ObjectPositions
    {
        public List<(int, int)> RedJewelPositions {get;} = new List<(int, int)>
        {
            (1, 9),
            (8, 8),
        };
        
        public List<(int, int)> GreenJewelPositions {get;} = new List<(int, int)>
        {
            (9, 1),
            (7, 6),
        };

        public List<(int, int)> BlueJewelPositions {get;} = new List<(int, int)>
        {
            (3, 4),
            (2, 1),
        };
            
        public List<(int, int)> WaterPositions {get;} = new List<(int, int)>
        {
            (5, 0),
            (5, 1),
            (5, 2),
            (5, 3),
            (5, 4),
            (5, 5),
            (5, 6)
        };
            
        public List<(int, int)> TreePositions = new List<(int, int)>
        {
            (1, 4),
            (2, 5),
            (3, 9),
            (5, 9),
            (8, 3),
        };
    }
}