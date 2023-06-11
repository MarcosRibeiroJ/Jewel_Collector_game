using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.RobotParts
{
    /// <summary>
    /// Classe criada para representar o robô no jogo.
    /// Possui os seguintes atributos:
    /// X e Y: Representam sua posição no jogo. Essa localização é usada como referência para as ações com os demais elementos do mapa.
    /// Bag e TotalScore: Representam o total de joias coletadas e os pontos acumulados com as coletas.
    /// Fuel: Representa o combustível do robô.
    /// PressedKeyStatus: Simboliza o comando direcionado ao robô durante o jogo. Quando por algum motivo ele não conseguir executar o comando, emitirá uma mensagem de aviso.
    /// Motor: Objeto do tipo Motor, utiliza o conceito de composição para simbolizar o motor do robô.
    /// Radar: Objeto do tipo Radar, utiliza o conceito de composição para simbolizar o radar que o robô possui.
    /// </summary>
    public class Robot : Cell
    {
        public int X {get;set;}
        public int Y {get;set;}
        public int Bag {get; set;}
        public int TotalScore {get; set;}
        public int Fuel {get; set;} = 5;
        public string? PressedKeyStatus {get; set;}
        public Motor Motor {get;}
        public Radar Radar {get;}
        /// <summary>
        /// Construtor que recebe dois inteiros representando a posição X e Y do robô no mapa.
        /// Também inicializa os objetos Motor e Radar.
        /// </summary>
        /// <param name="xLocation"></param>
        /// <param name="yLocation"></param>
        public Robot(int xLocation, int yLocation)
        {
            X = xLocation;
            Y = yLocation;
            Motor = new Motor();
            Radar = new Radar();
        }
        /// <summary>
        /// Método que movimenta o robô uma posição acima no mapa.
        /// Quando ativado, aciona o método moveUp de Motor e o método check de Radar.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        public void moveUp(List<List<Cell>> map)
        {
            Motor.moveUp(map, this);
            Radar.check(map, this);
        }
        /// <summary>
        /// Método que movimenta o robô uma posição abaixo no mapa.
        /// Quando ativado, aciona o método moveDown de Motor e o método check de Radar.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        public void moveDown(List<List<Cell>> map)
        {
            Motor.moveDown(map, this);
            Radar.check(map, this);
        }
        /// <summary>
        /// Método que movimenta o robô uma posição à esquerda no mapa.
        /// Quando ativado, aciona o método moveLeft de Motor e o método check de Radar.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        public void moveLeft(List<List<Cell>> map)
        {
            Motor.moveLeft(map, this);
            Radar.check(map, this);
        }
        /// <summary>
        /// Método que movimenta o robô uma posição à direita no mapa.
        /// Quando ativado, aciona o método moveRight de Motor e o método check de Radar.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        public void moveRight(List<List<Cell>> map)
        {
            Motor.moveRight(map, this);
            Radar.check(map, this);
        }
        /// <summary>
        /// Método que tenta capturar uma joia ou recarregar o robô.
        /// Aciona o método check de Radar para verificar se é possível executar a ação.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        public void captureOrRecharge(List<List<Cell>> map)
        {
            Radar.check(map, this);
            PressedKeyStatus = "";
        }
        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual do robô no jogo formatada na cor de fundo branco e cor de texto preto.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            return " ME ";
        }
    }
}