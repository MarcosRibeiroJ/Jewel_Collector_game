using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Maps;
using JewelCollectorProject.KeyEvents;
using JewelCollectorProject.Cells.Jewels;

namespace JewelCollectorProject
{
    /// <summary>
    /// Classe criada para gerenciar as ações do jogo.
    /// Determina o ínicio e fim do jogo e a dinâmica para avançar nas fases.
    /// Também é responsável por registrar um evento de captura de tecla durante a partida.
    /// Seus atributos são:
    /// level: Determina o nível do jogo, iniciando em 1.
    /// dimension: Dimensão da matriz do mapa, pode ser alterada ao iniciar um jogo.
    /// running: Booleano que encerra o jogo quando o valor for false.
    /// KeyPressed: Evento do tipo KeyPressedEventHandler que será disparado quando uma tecla for pressionada.
    /// Command: Propriedade que armazena a tecla digitada pelo usuário.
    /// map: Objeto do tipo Map que será o mapa (tabuleiro) do jogo.
    /// </summary>
    public class Game
    {
        private int level = 1;
        private int dimension;
        private bool running = true;
        public event KeyPressedEventHandler? KeyPressed;
        public string? Command {get; set;}
        private Map map = new Map();
        
        /// <summary>
        /// Construtor padrão, se não receber nenhum valor, inicializa o jogo com uma matriz 10X10.
        /// </summary>
        public Game()
        {
            this.dimension = 10;
        }
        /// <summary>
        /// Sobrecarga do construtor, permite que o usuário defina o tamanho do mapa do jogo.
        /// </summary>
        /// <param name="dimension">Inteiro que será utilizado na altura e largura da matriz do mapa.</param>
        public Game(int dimension)
        {
            this.dimension = dimension;
        }
        /// <summary>
        /// Método responsável por iniciar uma partida do jogo.
        /// Assim que acionado registra o método onRobotMove no evento KeyPressed.
        /// Em seguida, chama os métodos de impressão do mapa e da mensagem exibida logo abaixo do mapa.
        /// Com captureConsoleKey o cursor ficará aguardando o usuário pressionar alguma tecla.
        /// Assim que o usuário digitar, dispara o evento, passando a string para o médoto onRobotMove.
        /// </summary>
        public void startGame()
        {
            KeyPressed += onRobotMove;
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

        /// <summary>
        /// Método responsável por verificar quando o usuário ganhou o jogo, quando deve passar para o próximo nível ou quando perdeu.
        /// </summary>
        private void checkGameStatus()
        {
            if(dimension == 30 && map.MapMatrix.SelectMany(list => list).OfType<Jewel>().Count() == 0)
            {
                gameWin();
            }else if(map.MapMatrix.SelectMany(list => list).OfType<Jewel>().Count() == 0)
            {
                nextLevel();
            } else if(map.Robot.Fuel <= 0 && dimension > 10)
            {
                gameOver();
            }
        }

        /// <summary>
        /// Método responsável por escrever as principais informações para o usuário.
        /// Assim que a dimensão do jogo passa de 10X10, informa o combustível do robô.
        /// </summary>
        private void writeGameStatus()
        {
            if(dimension > 10)
            {
                Console.WriteLine($"Fuel: {map.Robot.Fuel} | Level: {level}");
            }
            Console.WriteLine($"Bag total items: {map.Robot.Bag} | Bag total value: {map.Robot.TotalScore}");
            Console.WriteLine("\nW (UP) | S (DOWN) | A (LEFT) | D (RIGHT) | G (GET/RECHARGE) | Q (QUIT)");
            Console.Write($"Enter the Command: {map.Robot.PressedKeyStatus}");
        }
        /// <summary>
        /// Método responsável por capturar a tecla digitada pelo usuário e armazená-la em Command.
        /// </summary>
        private void captureConsoleKey()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Command = keyPressed.KeyChar.ToString().ToLower();
        }

        /// <summary>
        /// Método responsável por mudar o nível do jogo, reiniciando os valores que precisam voltar ao valor inicial.
        /// Também incrementa as variáveis level e dimension e recria o mapa.
        /// </summary>
        private void nextLevel()
        {
            resetGame();
            dimension++;
            level++;
            map.createMap(dimension);
        }

        /// <summary>
        /// Método responsável por reiniciar os valores que precisam voltar ao estado inicial.
        /// </summary>
        private void resetGame()
        {
            map.Robot.Bag = 0;
            map.Robot.TotalScore = 0;
            map.Robot.X = 0;
            map.Robot.Y = 0;
            map.Robot.Fuel = 5;
            map.Robot.PressedKeyStatus = "";
            Command = "";
            map.MapMatrix.Clear();
        }
        /// <summary>
        /// Método responsável por verificar se o usuário deseja realmente sair do jogo ou se quer retornar.
        /// </summary>
        private void exitGame()
        {
            Console.Clear();
            Console.Write("Digite quit + <ENTER> se deseja sair do jogo ou r + <ENTER> para retornar: ");
            string? exit = Console.ReadLine();
            exit = exit?.ToLower();
            switch (exit)
            {
                case "r": break;
                case "quit": running = false; break;
                default:
                    Console.Clear();
                    Console.Write("TECLA INVÁLIDA");
                    Thread.Sleep(2000);
                    exitGame();break;
            }
        }
        /// <summary>
        /// Método responsável por exibir uma mensagem quando o usuário perde o jogo.
        /// Também permite que seja iniciada uma nova partida.
        /// </summary>
        private void gameOver()
        {
            dimension = 10;
            level = 1;
            Console.Clear();
            Console.WriteLine("GAME OVER :(");
            Console.Write("Deseja reiniciar o jogo? (y/n): ");
            captureConsoleKey();
            switch (Command)
            {
                case "y": resetGame(); map.createMap(dimension); map.printMap(); break;
                case "n": running = false; break;
                default:
                    Console.Clear();
                    Console.Write("TECLA INVÁLIDA");
                    Thread.Sleep(2000);
                    gameOver();break;
            }
        }
        /// <summary>
        /// Método responsável por exibir uma mensagem quando o jogador vence.
        /// </summary>
        private void gameWin()
        {
            Console.Clear();
            Console.WriteLine("PARABÉNS!! VOCÊ COLETOU TODAS AS JÓIAS PERDIDAS!! :)");
            running = false;
        }

        /// <summary>
        /// Método responsável por chamar as ações de movimentação, coleta e recarga do robô quando o usuário pressiona as teclas corretas.
        /// </summary>
        /// <param name="keyPressed"></param>
        private void onRobotMove(string keyPressed)
        {
            switch (keyPressed)
            {
                case "w": map.Robot.moveUp(map.MapMatrix); break;
                case "s": map.Robot.moveDown(map.MapMatrix); break;
                case "a": map.Robot.moveLeft(map.MapMatrix); break;
                case "d": map.Robot.moveRight(map.MapMatrix); break;
                case "g": map.Robot.PressedKeyStatus = "g"; map.Robot.captureOrRecharge(map.MapMatrix); break;
                case "q": exitGame(); break;
                default : map.Robot.PressedKeyStatus = "TECLA INVÁLIDA"; break;
            }
        }
    }
}