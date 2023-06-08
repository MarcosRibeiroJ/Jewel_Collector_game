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
        private int maxTree, maxRedJewel, maxGreenJewel, maxBlueJewel, maxWater, maxAtomic;
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
                    if(dimension == 10)
                    {
                        row.Add(chooseCellByLocation(i, j));
                    } else
                    {
                        row.Add(chooseCellRandomly(i, j));
                    }
                }
                mapMatrix.Add(row);
            }
        }

        public void printMap()
        {
            if(mapMatrix.Count == 0)
            {
                createMap();
            }
            do
            {
                if(mapMatrix.SelectMany(list => list).OfType<Jewel>().Count() == 0)
                {
                    nextFase();
                }
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
            switch (keyPressed)
            {
                case "w": robot.moveUp(mapMatrix); break;
                case "s": robot.moveDown(mapMatrix); break;
                case "a": robot.moveLeft(mapMatrix); break;
                case "d": robot.moveRight(mapMatrix); break;
                case "g": robot.captureJewel(mapMatrix); break;
                case "quit": running = false; break;
            }
        }

        private void captureConsoleKey()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            command = keyPressed.KeyChar.ToString().ToLower();
            exitGame = exitGame + command;
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
                return new RedJewel();
            }
            else if(positions.GreenJewelPositions.Contains((xLocation, yLocation)))
            {
                return new GreenJewel();
            }
            else if(positions.BlueJewelPositions.Contains((xLocation, yLocation)))
            {
                return new BlueJewel();
            }
            else if(positions.TreePositions.Contains((xLocation, yLocation)))
            {
                return new Tree();
            }
            else if(positions.WaterPositions.Contains((xLocation, yLocation)))
            {
                return new Water();
            }
            else
            {
                return new Empty();
            }
        }

        /*private Cell chooseCellRandomly(int xLocation, int yLocation)
        {
            if (xLocation == 0 && yLocation == 0)
            {
                return robot;
            }
            else
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 8);
                if (randomNumber == 1 && mapMatrix.SelectMany(list => list).OfType<Atomic>().Count() <= maxAtomic)
                {
                    return new Empty();
                } else if (randomNumber == 2 && mapMatrix.SelectMany(list => list).OfType<Atomic>().Count() <= maxAtomic)
                {
                    maxAtomic--;
                    return new Atomic();
                } else if (randomNumber == 3 && mapMatrix.SelectMany(list => list).OfType<Water>().Count() <= maxWater)
                {
                    maxWater--;
                    return new Water();
                } else if (randomNumber == 4 && mapMatrix.SelectMany(list => list).OfType<BlueJewel>().Count() <= maxBlueJewel)
                {
                    maxBlueJewel--;
                    return new BlueJewel();
                } else if (randomNumber == 5 && mapMatrix.SelectMany(list => list).OfType<GreenJewel>().Count()<= maxGreenJewel)
                {
                    maxGreenJewel--;
                    return new GreenJewel();
                } else if (randomNumber == 6 && mapMatrix.SelectMany(list => list).OfType<RedJewel>().Count()<= maxRedJewel)
                {
                    maxRedJewel--;
                    return new RedJewel();
                } else if (randomNumber == 7 && mapMatrix.SelectMany(list => list).OfType<Tree>().Count()<= maxTree)
                {
                    maxTree--;
                    return new Tree();
                } else
                {
                    return new Empty();
                }
            }
        }*/

        private Cell chooseCellRandomly(int xLocation, int yLocation)
        {
            if (xLocation == 0 && yLocation == 0)
            {
                return robot;
            }
            else
            {
                List<Cell> cellTypes = new List<Cell>
                {
                    new Empty(),
                    new Atomic(),
                    new Water(),
                    new BlueJewel(),
                    new GreenJewel(),
                    new RedJewel(),
                    new Tree()
                };

                Random random = new Random();
                int randomCell = random.Next(cellTypes.Count);

                Cell selectedCell = cellTypes[randomCell];

                if (selectedCell is Atomic && mapMatrix.SelectMany(list => list).OfType<Atomic>().Count() >= maxAtomic)
                {
                    selectedCell = new Empty();
                } else if (selectedCell is Water && mapMatrix.SelectMany(list => list).OfType<Water>().Count() >= maxWater)
                {
                    selectedCell = new Empty();
                } else if (selectedCell is BlueJewel && mapMatrix.SelectMany(list => list).OfType<BlueJewel>().Count() >= maxBlueJewel)
                {
                    selectedCell = new Empty();
                } else if (selectedCell is GreenJewel && mapMatrix.SelectMany(list => list).OfType<GreenJewel>().Count() >= maxGreenJewel)
                {
                    selectedCell = new Empty();
                } else if (selectedCell is RedJewel && mapMatrix.SelectMany(list => list).OfType<RedJewel>().Count() >= maxRedJewel)
                {
                    selectedCell = new Empty();
                } else if (selectedCell is Tree && mapMatrix.SelectMany(list => list).OfType<Tree>().Count() >= maxTree)
                {
                    selectedCell = new Empty();
                }
                return selectedCell;
            }
        }


        private void nextFase()
        {
            dimension++;
            robot.Bag = 0;
            robot.TotalScore = 0;
            robot.X = 0;
            robot.Y = 0;
            mapMatrix.Clear();
            maxTree = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxRedJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxGreenJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxBlueJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxWater = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxAtomic = (int)Math.Round(((dimension * dimension) - 1) * 0.01);
            createMap();
        }
    }
}