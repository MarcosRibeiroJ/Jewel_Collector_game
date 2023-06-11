using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.RobotParts
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
        public Radar Radar {get;}
        public Robot(int xLocation, int yLocation) //erro CS8618
        {
            X = xLocation;
            Y = yLocation;
            Motor = new Motor();
            Radar = new Radar();
        }

        public void moveUp(List<List<Cell>> map)
        {
            Motor.moveUp(map, this);
            Radar.check(map, this);
        }

        public void moveDown(List<List<Cell>> map)
        {
            Motor.moveDown(map, this);
            Radar.check(map, this);
        }

        public void moveLeft(List<List<Cell>> map)
        {
            Motor.moveLeft(map, this);
            Radar.check(map, this);
        }

        public void moveRight(List<List<Cell>> map)
        {
            Motor.moveRight(map, this);
            Radar.check(map, this);
        }

        public void captureOrRecharge(List<List<Cell>> map)
        {
            Radar.check(map, this);
            PressedKeyStatus = "";
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return " ME ";
        }
    }
}