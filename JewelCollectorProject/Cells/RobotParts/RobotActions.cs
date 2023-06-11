using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Jewels;
using JewelCollectorProject.Cells.Obstacles;

namespace JewelCollectorProject.Cells.RobotParts
{
    public class RobotActions
    {
        public void useJewel(Cell jewel, Robot robot)
        {
            robot.Bag++;
            if(jewel is RedJewel redJewel)
            {
                robot.TotalScore += redJewel.JewelValue;
            } else if(jewel is GreenJewel greenJewel)
            {
                robot.TotalScore += greenJewel.JewelValue;
            } else if(jewel is BlueJewel blueJewel)
            {
                robot.TotalScore += blueJewel.JewelValue;
                robot.Fuel += blueJewel.FuelValue;
            }
        }

        public void useTree(Cell cell, Robot robot)
        {
            if(cell is Tree tree && tree.IsRechargeable)
            {
                robot.Fuel += tree.FuelValue;
                tree.IsRechargeable = false;
            }
        }
    }
}