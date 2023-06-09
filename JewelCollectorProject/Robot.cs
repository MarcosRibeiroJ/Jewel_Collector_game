using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Jewels;
using JewelCollectorProject.Obstacles;

namespace JewelCollectorProject
{
    public class Robot : Cell
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Bag {get; set;}
        public int TotalScore {get; set;}
        public int Fuel {get; set;} = 5;
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
                    Fuel--;
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
                    Fuel--;
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
                    Fuel--;
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
                    Fuel--;
                    PressedKeyStatus = "d";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            return "";
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
                Bag++;
                Cell cell = new Empty();
                map[X-1][Y] = cell;
            } else if(X > 0 && map[X-1][Y] is Tree)
            {
                useTree(map[X-1][Y]);
            }
        }

        private void checkDown(List<List<Cell>> map)
        {    
            if(X < map.Count -1 && map[X+1][Y] is Jewel)
            {
                useJewel(map[X+1][Y]);
                Bag++;
                Cell cell = new Empty();
                map[X+1][Y] = cell;
            } else if(X < map.Count -1 && map[X+1][Y] is Tree)
            {
                useTree(map[X+1][Y]);
            }
        }

        private void checkLeft(List<List<Cell>> map)
        {    
            if(Y > 0 && map[X][Y-1] is Jewel)
            {
                useJewel(map[X][Y-1]);
                Bag++;
                Cell cell = new Empty();
                map[X][Y-1] = cell;
            } else if(Y > 0 && map[X][Y-1] is Tree)
            {
                useTree(map[X][Y-1]);
            }
        }

        private void checkRight(List<List<Cell>> map)
        {
            int totalColumns = map.Count > 0 ? map[0].Count : 0;
            if(Y < totalColumns -1 && map[X][Y+1] is Jewel)
            {
                useJewel(map[X][Y+1]);
                Bag++;
                Cell cell = new Empty();
                map[X][Y+1] = cell;
            } else if(Y < totalColumns -1 && map[X][Y+1] is Tree)
            {
                useTree(map[X][Y+1]);
            }
        }

        public void useJewel(Cell jewel)
        {
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

        public void useTree(Cell cell)
        {
            if(cell is Tree tree && tree.isRechargeable)
            {
                Fuel += tree.FuelValue;
                tree.isRechargeable = false;
            }
        }
        
        public override string ToString()
        {
            return " ME ";
        }
    }
}