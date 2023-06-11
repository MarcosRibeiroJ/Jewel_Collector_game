using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Obstacles;

namespace JewelCollectorProject.Cells.RobotParts
{
    public class Radar
    {
        public void checkRadioactivity(List<List<Cell>> map, Robot robot)
        {
            int totalAtomicElements = 0;
            try
            {
                if (robot.X > 0 && map[robot.X - 1][robot.Y] is Atomic)
                {
                    totalAtomicElements++;
                }
                if (robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Atomic)
                {
                    totalAtomicElements++;
                }
                if (robot.Y > 0 && map[robot.X][robot.Y - 1] is Atomic)
                {
                    totalAtomicElements++;
                }
                if (robot.Y < map[0].Count - 1 && map[robot.X][robot.Y + 1] is Atomic)
                {
                    totalAtomicElements++;
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