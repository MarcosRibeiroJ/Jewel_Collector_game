using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Jewels;
using JewelCollectorProject.Obstacles;
using JewelCollectorProject.KeyEvents;

namespace JewelCollectorProject.Maps
{
    public class Map
    {
        private int dimension = 10;
        private List<List<Cell>> mapMatrix = new List<List<Cell>>();
        private string exitGame = "";
        private Robot robot = new Robot(0,0);
        private bool running = true;
        public event KeyPressedEventHandler? KeyPressed;
        public string? command {get; set;}
        public Map()
        {
            KeyPressed += onKeyPressed;
        }
        
        public void createMap()
        {
            for(int i = 0; i < dimension; i++)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < dimension; j++)
                {
                    row.Add(chooseCellType(i, j));
                }
                mapMatrix.Add(row);
            }
        }

        public void printMap()
        {
            createMap();
            do
            {
                Console.Clear();
                foreach (List<Cell> row in mapMatrix)
                {
                    foreach (Cell cell in row)
                    {
                        Console.Write(cell);
                    }
                    Console.WriteLine();
                }
                writeGameStatus();
                captureConsoleKey();
                KeyPressed?.Invoke(command ?? string.Empty);
            } while (running);
        }

        private void writeGameStatus()
        {
            Console.WriteLine($"Bag total items: {robot.Bag} | Bag total value: {robot.TotalScore}");
            Console.Write($"Enter the command: {robot.PressedKeyStatus}");      
        }

        private void onKeyPressed(string keyPressed)
        {
            if (exitGame.Contains("quit"))
            {
                running = false;
            } else if (keyPressed.Equals("w"))
            {
                robot.moveUp(mapMatrix);
            } else if (keyPressed.Equals("a"))
            {
                robot.moveLeft(mapMatrix);                   
            } else if (keyPressed.Equals("s"))
            {
                robot.moveDown(mapMatrix);
            } else if (keyPressed.Equals("d"))
            {
                robot.moveRight(mapMatrix);
            } else if (keyPressed.Equals("g"))
            {
                robot.captureJewel(mapMatrix);
            }
        }

        private void captureConsoleKey()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            command = keyPressed.KeyChar.ToString().ToLower();
            exitGame = exitGame + command;
        }
        private Cell chooseCellType(int xLocation, int yLocation)
        {
            return chooseCellByLocation(xLocation, yLocation);
        }

        private Cell chooseCellByLocation(int xLocation, int yLocation)
        {
            ObjectPositions positions = new ObjectPositions();
            if (xLocation == 0 && yLocation == 0)
            {
                return robot;
            }
            else if(positions.RedJewelPositions.Contains((xLocation, yLocation)))
            {
                RedJewel redJewel = new RedJewel();
                return redJewel;
            }
            else if(positions.GreenJewelPositions.Contains((xLocation, yLocation)))
            {
                GreenJewel greenJewel = new GreenJewel();
                return greenJewel;
            }
            else if(positions.BlueJewelPositions.Contains((xLocation, yLocation)))
            {
                BlueJewel blueJewel = new BlueJewel();
                return blueJewel;
            }
            else if(positions.TreePositions.Contains((xLocation, yLocation)))
            {
                Tree tree = new Tree();
                return tree;
            }
            else if(positions.WaterPositions.Contains((xLocation, yLocation)))
            {
                Water water = new Water();
                return water;
            }
            else
            {
                Empty emptyCell = new Empty();
                return emptyCell;
            }
        }
    }
}