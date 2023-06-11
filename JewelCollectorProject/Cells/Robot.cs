using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Jewels;
using JewelCollectorProject.Cells.Obstacles;
using JewelCollectorProject.Cells.RobotParts;

namespace JewelCollectorProject.Cells
{
    public class Robot : Cell
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Bag {get; set;}
        public int TotalScore {get; set;}
        public int Fuel {get; set;} = 5;
        public string? PressedKeyStatus {get; set;}
        public Motor Motor {get;}
        public Robot(int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
            Motor = new Motor();
        }

        public void moveUp(List<List<Cell>> map)
        {
            Motor.moveUp(map, X, Y, this);
        }

        public void moveDown(List<List<Cell>> map)
        {
            Motor.moveDown(map, X, Y, this);
        }

        public void moveLeft(List<List<Cell>> map)
        {
            Motor.moveLeft(map, X, Y, this);
        }

        public void moveRight(List<List<Cell>> map)
        {
            Motor.moveRight(map, X, Y, this);
        }
        
        public void captureOrRecharge(List<List<Cell>> map)
        {
            checkUp(map);
            checkDown(map);
            checkLeft(map);
            checkRight(map);
            PressedKeyStatus = "g";
        }

        private void checkUp(List<List<Cell>> map)
        {    
            if(X > 0 && map[X-1][Y] is Jewel)
            {
                useJewel(map[X-1][Y]);
                Cell cell = new Empty();
                map[X-1][Y] = cell;
            } else if(X > 0 && map[X-1][Y] is Tree && map.Count > 10)
            {
                useTree(map[X-1][Y]);
            }
        }

        private void checkDown(List<List<Cell>> map)
        {    
            if(X < map.Count -1 && map[X+1][Y] is Jewel)
            {
                useJewel(map[X+1][Y]);
                Cell cell = new Empty();
                map[X+1][Y] = cell;
            } else if(X < map.Count -1 && map[X+1][Y] is Tree && map.Count > 10)
            {
                useTree(map[X+1][Y]);
            }
        }

        private void checkLeft(List<List<Cell>> map)
        {    
            if(Y > 0 && map[X][Y-1] is Jewel)
            {
                useJewel(map[X][Y-1]);
                Cell cell = new Empty();
                map[X][Y-1] = cell;
            } else if(Y > 0 && map[X][Y-1] is Tree && map.Count > 10)
            {
                useTree(map[X][Y-1]);
            }
        }

        private void checkRight(List<List<Cell>> map)
        {
            if(Y < map.Count -1 && map[X][Y+1] is Jewel)
            {
                useJewel(map[X][Y+1]);
                Cell cell = new Empty();
                map[X][Y+1] = cell;
            } else if(Y < map.Count -1 && map[X][Y+1] is Tree && map.Count > 10)
            {
                useTree(map[X][Y+1]);
            }
        }

        private void useJewel(Cell jewel)
        {
            Bag++;
            if(jewel is RedJewel redJewel)
            {
                TotalScore += redJewel.JewelValue;
            } else if(jewel is GreenJewel greenJewel)
            {
                TotalScore += greenJewel.JewelValue;
            } else if(jewel is BlueJewel blueJewel)
            {
                TotalScore += blueJewel.JewelValue;
                Fuel += blueJewel.FuelValue;
            }           
        }

        private void useTree(Cell cell)
        {
            if(cell is Tree tree && tree.IsRechargeable)
            {
                Fuel += tree.FuelValue;
                tree.IsRechargeable = false;
            }
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return " ME ";
        }
    }
}