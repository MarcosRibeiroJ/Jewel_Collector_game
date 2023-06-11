using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Obstacles;

namespace JewelCollectorProject.Cells.RobotParts
{
    public class Radar
    {
        public void checkRadioactivity(List<List<Cell>> map, int xLocation, int yLocation, Robot robot)
        {
            int totalAtomicElements = 0;
            try
            {
                for (int i = -1; i < 2; i++)
                {
                    if(map[xLocation+i][yLocation] is Atomic)
                    {
                        totalAtomicElements++;
                    }    
                }
                for (int i = -1; i < 2; i++)
                {
                    if(map[xLocation][yLocation+i] is Atomic)
                    {
                        totalAtomicElements++;
                    }    
                }
                robot.Fuel -= Atomic.DamageArea * totalAtomicElements; 
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "";
            }
        }
    }
}