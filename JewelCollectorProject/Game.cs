using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Maps;
using JewelCollectorProject.KeyEvents;
using JewelCollectorProject.Jewels;

namespace JewelCollectorProject
{
    public class Game
    {
        private int level = 1;
        private int dimension;
        private bool running = true;
        public event KeyPressedEventHandler? KeyPressed;
        public string? Command {get; set;}
        private Map map = new Map();
        
        public Game(int dimension)
        {
            this.dimension = dimension;
        }
        public void startGame()
        {
            KeyPressed += onKeyPressed;
            map.createMap(dimension);
            do
            {
                map.printMap();
                writeGameStatus();
                captureConsoleKey();
                KeyPressed?.Invoke(Command ?? string.Empty);
                checkGameStatus();
            } while (running);
        }

        public void checkGameStatus()
        {
            if(map.MapMatrix.SelectMany(list => list).OfType<Jewel>().Count() == 0)
            {
                nextLevel();
            } else if(map.Robot.Fuel <= 0 && dimension > 10)
            {
                gameOver();
            }
        }

        private void writeGameStatus()
        {
            if(dimension > 10)
            {
                Console.WriteLine($"Fuel: {map.Robot.Fuel} | Level: {level}");
            }
            Console.WriteLine($"Bag total items: {map.Robot.Bag} | Bag total value: {map.Robot.TotalScore}");
            Console.Write($"Enter the Command: {map.Robot.PressedKeyStatus}");
        }

        private void captureConsoleKey()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Command = keyPressed.KeyChar.ToString().ToLower();
        }

        private void onKeyPressed(string keyPressed)
        {
            switch (keyPressed)
            {
                case "w": map.Robot.moveUp(map.MapMatrix); break;
                case "s": map.Robot.moveDown(map.MapMatrix); break;
                case "a": map.Robot.moveLeft(map.MapMatrix); break;
                case "d": map.Robot.moveRight(map.MapMatrix); break;
                case "g": map.Robot.captureOrRecharge(map.MapMatrix); break;
                case "q": exitGame(); break;
                case "r": break;
                case "quit": running = false; break;
                default : map.Robot.PressedKeyStatus = "TECLA INVÁLIDA"; break;
            }
        }

        private void nextLevel()
        {
            resetGame();
            dimension++;
            level++;
            map.createMap(dimension);
        }

        private void resetGame()
        {
            map.Robot.Bag = 0;
            map.Robot.TotalScore = 0;
            map.Robot.X = 0;
            map.Robot.Y = 0;
            map.Robot.Fuel = 5;
            map.MapMatrix.Clear();
        }

        private void exitGame()
        {
            Console.Clear();
            Console.Write("Digite quit + <ENTER> se deseja sair do jogo ou r + <ENTER> para retornar: ");
            string? exit = Console.ReadLine();
            onKeyPressed(exit ?? string.Empty);
        }
        
        private void gameOver()
        {
            dimension = 10;
            level = 1;
            Console.Clear();
            Console.WriteLine("GAME OVER :(");
            Console.Write("Deseja jogar novamente? (y/n): ");
            captureConsoleKey();
            switch (Command)
            {
                case "y": resetGame(); map.printMap(); break;
                case "n": running = false; break;
                default:
                    Console.Clear();
                    Console.Write("TECLA INVÁLIDA");
                    Thread.Sleep(2000);
                    gameOver();break;
            }
        }
    }
}