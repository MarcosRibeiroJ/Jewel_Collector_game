using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Jewels;

namespace JewelCollectorProject
{
    /// <summary>
    /// 
    /// </summary>
    public class Robot : Cell
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Bag {get; set;}
        public int TotalScore {get; set;}
        public string? PressedKeyStatus {get; set;}
        public Robot(int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
        }

        public void moveUp(List<List<Cell>> map)
        {
            try
            {
                if(map[X-1][Y] is Empty)
                {
                    map[X][Y] = map[X-1][Y];
                    map[X-1][Y] = this;
                    X--;
                    PressedKeyStatus = "w";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        public void moveLeft(List<List<Cell>> map) {
            try
            {
                if(map[X][Y-1] is Empty)
                {
                    map[X][Y] = map[X][Y-1];
                    map[X][Y-1] = this;
                    Y--;
                    PressedKeyStatus = "a";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        public void moveDown(List<List<Cell>> map)
        {
            try
            {
                if(map[X+1][Y] is Empty)
                {
                    map[X][Y] = map[X+1][Y];
                    map[X+1][Y] = this;
                    X++;
                    PressedKeyStatus = "s";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        public string moveRight(List<List<Cell>> map)
        {
            int totalColumns = map.Count > 0 ? map[0].Count : 0;

            try
            {
                if(map[X][Y+1] is Empty)
                {
                    map[X][Y] = map[X][Y+1];
                    map[X][Y+1] = this;
                    Y++;
                    PressedKeyStatus = "d";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            return "";
        }
        
        public void captureJewel(List<List<Cell>> map) {
            isJewelUp(map);
            isJewelDown(map);
            isJewelLeft(map);
            isJewelRight(map);
            PressedKeyStatus = "g";
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
                TotalScore += 100;
            } else if(jewel is GreenJewel)
            {
                TotalScore += 50;
            } else if(jewel is BlueJewel)
            {
                TotalScore += 10;
            }           
        }

        public override string ToString()
        {
            return " ME ";
        }
    }
}