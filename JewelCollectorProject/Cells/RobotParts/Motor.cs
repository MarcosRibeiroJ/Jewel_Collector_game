using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Obstacles;

namespace JewelCollectorProject.Cells.RobotParts
{
    public class Motor
    {
        private Radar radar = new Radar();
        public void moveUp(List<List<Cell>> map, int xLocation, int yLocation, Robot robot)
        {
            try
            {
                if(map[xLocation-1][yLocation] is Empty)
                {
                    map[xLocation][yLocation] = map[xLocation-1][yLocation];
                    map[xLocation-1][yLocation] = robot;
                    robot.X--;
                    robot.Fuel--;
                    radar.checkRadioactivity(map, robot);
                    robot.PressedKeyStatus = "w";
                } else if(map[xLocation-1][yLocation] is Atomic)
                {
                    map[xLocation][yLocation] = new Empty();
                    map[xLocation-1][yLocation] = robot;
                    robot.X--;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "w";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        public void moveDown(List<List<Cell>> map, int xLocation, int yLocation, Robot robot)
        {
            try
            {
                if(map[xLocation+1][yLocation] is Empty)
                {
                    map[xLocation][yLocation] = map[xLocation+1][yLocation];
                    map[xLocation+1][yLocation] = robot;
                    robot.X++;
                    robot.Fuel--;
                    radar.checkRadioactivity(map, robot);
                    robot.PressedKeyStatus = "s";
                } else if(map[xLocation+1][yLocation] is Atomic)
                {
                    map[xLocation][yLocation] = new Empty();
                    map[xLocation+1][yLocation] = robot;
                    robot.X++;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "s";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        public void moveLeft(List<List<Cell>> map, int xLocation, int yLocation, Robot robot) {
            try
            {
                if(map[xLocation][yLocation-1] is Empty)
                {
                    map[xLocation][yLocation] = map[xLocation][yLocation-1];
                    map[xLocation][yLocation-1] = robot;
                    robot.Y--;
                    robot.Fuel--;
                    radar.checkRadioactivity(map, robot);
                    robot.PressedKeyStatus = "a";
                }else if(map[xLocation][yLocation-1] is Atomic)
                {
                    map[xLocation][yLocation] = new Empty();
                    map[xLocation][yLocation-1] = robot;
                    robot.Y--;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "a";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        public string moveRight(List<List<Cell>> map, int xLocation, int yLocation, Robot robot)
        {
            try
            {
                if(map[xLocation][yLocation+1] is Empty)
                {
                    map[xLocation][yLocation] = new Empty();
                    map[xLocation][yLocation+1] = robot;
                    robot.Y++;
                    robot.Fuel--;
                    radar.checkRadioactivity(map, robot);
                    robot.PressedKeyStatus = "d";
                } else if(map[xLocation][yLocation+1] is Atomic)
                {
                    map[xLocation][yLocation] = map[xLocation][yLocation+1];
                    map[xLocation][yLocation+1] = robot;
                    robot.Y++;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "d";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            return "";
        }
    }
}