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
                    row.Add(new Empty());
                }
                mapMatrix.Add(row);
            }
            if(dimension == 10)
            {
                insertFixedCells();
            } else
            {
                insertRandomCells();
            }
        }

        public void insert(Cell cell, int xLocation, int yLocation)
        {
            mapMatrix[xLocation][yLocation] = cell;
        }

        public void insertFixedCells()
        {
            insert(robot, 0, 0);

            insert(new RedJewel(), 1, 9);
            insert(new RedJewel(), 8, 8);
            insert(new GreenJewel(), 9, 1);
            insert(new GreenJewel(), 7, 6);
            insert(new BlueJewel(), 3, 4);
            insert(new BlueJewel(), 2, 1);

            insert(new Water(), 5, 0);
            insert(new Water(), 5, 1);
            insert(new Water(), 5, 2);
            insert(new Water(), 5, 3);
            insert(new Water(), 5, 4);
            insert(new Water(), 5, 5);
            insert(new Water(), 5, 6);
            insert(new Tree(), 5, 9);
            insert(new Tree(), 3, 9);
            insert(new Tree(), 8, 3);
            insert(new Tree(), 2, 5);
            insert(new Tree(), 1, 4);
        }

        public void insertRandomCells()
        {
            insert(robot, 0, 0);

            for (int i = 0; i <= maxAtomic; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(mapMatrix[x][y] is Empty)
                {
                    insert(new Atomic(), x, y);
                }
            }
            for (int i = 0; i <= maxWater; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(mapMatrix[x][y] is Empty)
                {
                    insert(new Water(), x, y);
                }
            }
            for (int i = 0; i <= maxTree; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(mapMatrix[x][y] is Empty)
                {
                    insert(new Tree(), x, y);
                }
            }
            for (int i = 0; i <= maxBlueJewel; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(mapMatrix[x][y] is Empty)
                {
                    insert(new BlueJewel(), x, y);
                }
            }
            for (int i = 0; i <= maxGreenJewel; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);

                if(mapMatrix[x][y] is Empty)
                {
                    insert(new GreenJewel(), x, y);
                }
            }
            for (int i = 0; i <= maxRedJewel; i++)
            {
                Random random = new Random();
                int x = random.Next(1, dimension);
                int y = random.Next(1, dimension);
                if(mapMatrix[x][y] is Empty)
                {
                    insert(new RedJewel(), x, y);
                }
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
                if(robot.Fuel == 0)
                {
                    gameOver();
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
            if(dimension > 10)
            {
                Console.WriteLine($"Fuel: {robot.Fuel}");
            }
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
                case "g": robot.captureOrRecharge(mapMatrix); break;
                case "quit": running = false; break;
            }
        }

        private void captureConsoleKey()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            command = keyPressed.KeyChar.ToString().ToLower();
            exitGame = exitGame + command;
        }
        private void nextFase()
        {
            resetGame();
            dimension++;
            maxTree = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxRedJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxGreenJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxBlueJewel = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxWater = (int)Math.Round(((dimension * dimension) - 1) * 0.1);
            maxAtomic = (int)Math.Round(((dimension * dimension) - 1) * 0.01);
            createMap();
        }

        public void gameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER :(");
            Console.Write("Deseja jogar novamente? (y/n): ");
            captureConsoleKey();
            if(command.Equals("y"))
            {
                resetGame();
                printMap();
            } else
            {
                running = false;
            }
        }

        public void resetGame()
        {
            robot.Bag = 0;
            robot.TotalScore = 0;
            robot.X = 0;
            robot.Y = 0;
            robot.Fuel = 5;
            mapMatrix.Clear();
        }
    }
}