using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Jewels;

namespace JewelCollectorProject
{
    public class Robot : Cell
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Bag {get; set;}
        public int totalScore {get; set;}
        public Robot(int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
        }

        public void moveUp(List<List<Cell>> map)
        {
            if(X - 1 >= 0 && map[X-1][Y] is Empty)
            {
                map[X][Y] = map[X-1][Y];
                map[X-1][Y] = this;
                X--;
            }
        }

        public void moveLeft(List<List<Cell>> map) {
            if(Y - 1 >= 0 && map[X][Y-1] is Empty)
            {
                map[X][Y] = map[X][Y-1];
                map[X][Y-1] = this;
                Y--;
            }
        }

        public void moveDown(List<List<Cell>> map)
        {
            if(X + 1 < map.Count && map[X+1][Y] is Empty)
            {
                map[X][Y] = map[X+1][Y];
                map[X+1][Y] = this;
                X++;
            }
        }

        public void moveRight(List<List<Cell>> map)
        {
            int totalColumns = map.Count > 0 ? map[0].Count : 0;

            if(Y + 1 < totalColumns - 1 && map[X][Y+1] is Empty)
            {
                map[X][Y] = map[X][Y+1];
                map[X][Y+1] = this;
                Y++;
            }
        }
        
        public void captureJewel(List<List<Cell>> map) {
            isJewelUp(map);
            isJewelDown(map);
            isJewelLeft(map);
            isJewelRight(map);
        }

        private void isJewelUp(List<List<Cell>> map) {
            
            if(X > 0 && map[X-1][Y] is IJewel) {
                score(map[X-1][Y]);
                Bag++;
                Cell cell = new Empty();
                map[X-1][Y] = cell;
            }
        }

        private void isJewelDown(List<List<Cell>> map) {
            
            if(X < map.Count -1 && map[X+1][Y] is IJewel) {
                score(map[X+1][Y]);
                Bag++;
                Cell cell = new Empty();
                map[X+1][Y] = cell;
            }
        }

        private void isJewelLeft(List<List<Cell>> map) {
            
            if(Y > 0 && map[X][Y-1] is IJewel) {
                score(map[X][Y-1]);
                Bag++;
                Cell cell = new Empty();
                map[X][Y-1] = cell;
            }
        }

        private void isJewelRight(List<List<Cell>> map) {
            int totalColumns = map.Count > 0 ? map[0].Count : 0;

            if(Y < totalColumns -1 && map[X][Y+1] is IJewel) {
                score(map[X][Y+1]);
                Bag++;
                Cell cell = new Empty();
                map[X][Y+1] = cell;
            }
        }

        public void score(Cell jewel) {
            if(jewel is RedJewel)
            {
                totalScore += 100;
            } else if(jewel is GreenJewel)
            {
                totalScore += 50;
            } else if(jewel is BlueJewel)
            {
                totalScore += 10;
            }           
        }

        public override string ToString()
        {
            return " ME ";
        }
    }
}