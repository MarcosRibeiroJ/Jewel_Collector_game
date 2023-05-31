using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Jewels;
using JewelCollectorProject.Obstacles;

namespace JewelCollectorProject
{
    public class Map
    {
        private int dimension = 10;
        private List<List<Cell>> mapMatrix = new List<List<Cell>>();

        private string exitGame = "";
        private Robot robot = new Robot(0,0);

        public void createMap()
        {
    
            List<(int, int)> redJewelPositions = new List<(int, int)>
            {
                (1, 9),
                (8, 8),
            };

            List<(int, int)> greenJewelPositions = new List<(int, int)>
            {
                (9, 1),
                (7, 6),
            };

            List<(int, int)> blueJewelPositions = new List<(int, int)>
            {
                (3, 4),
                (2, 1),
            };
            
            List<(int, int)> waterPositions = new List<(int, int)>
            {
                (5, 0),
                (5, 1),
                (5, 2),
                (5, 3),
                (5, 4),
                (5, 5),
                (5, 6)
            };
            
            List<(int, int)> treePositions = new List<(int, int)>
            {
                (1, 4),
                (2, 5),
                (3, 9),
                (5, 9),
                (8, 3),
            };

            for (int i = 0; i < dimension; i++)
            {
                List<Cell> row = new List<Cell>();
                for (int j = 0; j < dimension; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Cell cell = robot;
                        row.Add(cell);
                    }
                    else if (redJewelPositions.Contains((i, j)))
                    {
                        Cell cell = new RedJewel();
                        row.Add(cell);
                    }
                    else if (greenJewelPositions.Contains((i, j)))
                    {
                        Cell cell = new GreenJewel();
                        row.Add(cell);
                    }
                    else if (blueJewelPositions.Contains((i, j)))
                    {
                        Cell cell = new BlueJewel();
                        row.Add(cell);
                    }
                    else if (treePositions.Contains((i, j)))
                    {
                        Cell cell = new Tree();
                        row.Add(cell);
                    }
                    else if (waterPositions.Contains((i, j)))
                    {
                        Cell cell = new Water();
                        row.Add(cell);
                    }
                    else
                    {
                        Cell cell = new Empty();
                        row.Add(cell);
                    }
                }
                mapMatrix.Add(row);
            }
        }


        public void printMap() {
            bool running = true;
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
                Console.WriteLine($"Bag total items: {robot.Bag} | Bag total value: {robot.totalScore}");
                if(exitGame.Length == 0)
                {
                    Console.Write($"Enter the command: ");
                } else
                {
                    Console.Write($"Enter the command: {exitGame[exitGame.Length-1]}");
                }
                
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                string command = keyPressed.KeyChar.ToString();
                exitGame = exitGame + command;
                
                if (exitGame.Contains("quit"))
                {
                    running = false;
                } else if (command.Equals("w"))
                {
                    robot.moveUp(mapMatrix);
                } else if (command.Equals("a"))
                {
                    robot.moveLeft(mapMatrix);                   
                } else if (command.Equals("s"))
                {
                    robot.moveDown(mapMatrix);
                } else if (command.Equals("d"))
                {
                    robot.moveRight(mapMatrix);
                } else if (command.Equals("g"))
                {
                    robot.captureJewel(mapMatrix);
                }
            } while (running);
        }
    }
}