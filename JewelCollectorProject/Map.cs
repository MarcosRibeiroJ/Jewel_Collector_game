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
        private bool running = true;
        private void createMap()
        {
            ObjectPositions positions = new ObjectPositions();

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
                    else if (positions.RedJewelPositions.Contains((i, j)))
                    {
                        Cell cell = new RedJewel();
                        row.Add(cell);
                    }
                    else if (positions.GreenJewelPositions.Contains((i, j)))
                    {
                        Cell cell = new GreenJewel();
                        row.Add(cell);
                    }
                    else if (positions.BlueJewelPositions.Contains((i, j)))
                    {
                        Cell cell = new BlueJewel();
                        row.Add(cell);
                    }
                    else if (positions.TreePositions.Contains((i, j)))
                    {
                        Cell cell = new Tree();
                        row.Add(cell);
                    }
                    else if (positions.WaterPositions.Contains((i, j)))
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
                
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                string command = keyPressed.KeyChar.ToString();
                exitGame = exitGame + command;
                
                keyPressedAction(command);
            } while (running);
        }

        private void writeGameStatus()
        {
            Console.WriteLine($"Bag total items: {robot.Bag} | Bag total value: {robot.totalScore}");
            if(exitGame.Length == 0)
            {
                Console.Write($"Enter the command: ");
            } else
            {
                Console.Write($"Enter the command: {exitGame[exitGame.Length-1]}");
            }           
        }

        private void keyPressedAction(String keyPressed)
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
    }
}