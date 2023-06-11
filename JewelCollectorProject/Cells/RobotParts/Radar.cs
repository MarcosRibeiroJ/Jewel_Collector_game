using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Obstacles;
using JewelCollectorProject.Cells.Jewels;

namespace JewelCollectorProject.Cells.RobotParts
{
    public class Radar
    {
        private RobotActions action = new RobotActions();
        public void check(List<List<Cell>> map, Robot robot)
        {
            int totalAtomicElements = 0;
            try
            {
                if (robot.X > 0 && map[robot.X - 1][robot.Y] is Atomic)
                {
                    totalAtomicElements++;
                } else if(robot.X > 0 && map[robot.X - 1][robot.Y] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X - 1][robot.Y], robot);
                    Cell cell = new Empty();
                    map[robot.X - 1][robot.Y] = cell;
                } else if(robot.X > 0 && map[robot.X - 1][robot.Y] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X - 1][robot.Y], robot);
                }
                if (robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Atomic)
                {
                    totalAtomicElements++;
                } else if(robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X + 1][robot.Y], robot);
                    Cell cell = new Empty();
                    map[robot.X + 1][robot.Y] = cell;
                } else if(robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X + 1][robot.Y], robot);
                }
                if (robot.Y > 0 && map[robot.X][robot.Y - 1] is Atomic)
                {
                    totalAtomicElements++;
                } else if(robot.Y > 0 && map[robot.X][robot.Y - 1] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X][robot.Y - 1], robot);
                    Cell cell = new Empty();
                    map[robot.X][robot.Y - 1] = cell;
                } else if(robot.Y > 0 && map[robot.X][robot.Y - 1] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X][robot.Y - 1], robot);
                }
                if (robot.Y < map.Count - 1 && map[robot.X][robot.Y + 1] is Atomic)
                {
                    totalAtomicElements++;
                } else if(robot.Y < map.Count - 1 && map[robot.X][robot.Y + 1] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X][robot.Y + 1], robot);
                    Cell cell = new Empty();
                    map[robot.X][robot.Y + 1] = cell;
                } else if(robot.Y < map.Count - 1 && map[robot.X][robot.Y + 1] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X][robot.Y + 1], robot);
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