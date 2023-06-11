using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Obstacles;

namespace JewelCollectorProject.Cells.RobotParts
{
    /// <summary>
    /// Classe responsável por mover a posição do robô.
    /// Possui 4 métodos que movimentam o robô uma posição na matriz em qualquer uma das 4 direções possíveis.
    /// Também reduz o combustível do robô de acordo com a regra:
    /// - Se robô andar uma posição para uma célula vazia, reduz 1 ponto de combustível.
    /// - Se robô andar uma posição para uma célula contendo um elemento Atomic, reduz o combustível no total de dano determinado na classe Atomic.
    /// </summary>
    public class Motor
    {
        /// <summary>
        /// Método que movimenta o robô uma posição acima na matriz.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        /// <param name="robot">Robô que deverá ser movimentado no mapa do Jogo</param>
        public void moveUp(List<List<Cell>> map, Robot robot)
        {
            try
            {
                if(map[robot.X-1][robot.Y] is Empty)
                {
                    map[robot.X][robot.Y] = map[robot.X-1][robot.Y];
                    map[robot.X-1][robot.Y] = robot;
                    robot.X--;
                    robot.Fuel--;
                    robot.PressedKeyStatus = "w";
                } else if(map[robot.X-1][robot.Y] is Atomic)
                {
                    map[robot.X][robot.Y] = new Empty();
                    map[robot.X-1][robot.Y] = robot;
                    robot.X--;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "w";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }

        /// <summary>
        /// Método que movimenta o robô uma posição abaixo na matriz.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        /// <param name="robot">Robô que deverá ser movimentado no mapa do Jogo</param>
        public void moveDown(List<List<Cell>> map, Robot robot)
        {
            try
            {
                if(map[robot.X+1][robot.Y] is Empty)
                {
                    map[robot.X][robot.Y] = map[robot.X+1][robot.Y];
                    map[robot.X+1][robot.Y] = robot;
                    robot.X++;
                    robot.Fuel--;
                    robot.PressedKeyStatus = "s";
                } else if(map[robot.X+1][robot.Y] is Atomic)
                {
                    map[robot.X][robot.Y] = new Empty();
                    map[robot.X+1][robot.Y] = robot;
                    robot.X++;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "s";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }
        /// <summary>
        /// Método que movimenta o robô uma posição à esquerda na matriz.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        /// <param name="robot">Robô que deverá ser movimentado no mapa do Jogo</param>
        public void moveLeft(List<List<Cell>> map, Robot robot) {
            try
            {
                if(map[robot.X][robot.Y-1] is Empty)
                {
                    map[robot.X][robot.Y] = map[robot.X][robot.Y-1];
                    map[robot.X][robot.Y-1] = robot;
                    robot.Y--;
                    robot.Fuel--;
                    robot.PressedKeyStatus = "a";
                }else if(map[robot.X][robot.Y-1] is Atomic)
                {
                    map[robot.X][robot.Y] = new Empty();
                    map[robot.X][robot.Y-1] = robot;
                    robot.Y--;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "a";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            
        }
        /// <summary>
        /// Método que movimenta o robô uma posição à direita na matriz.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        /// <param name="robot">Robô que deverá ser movimentado no mapa do Jogo</param>
        public string moveRight(List<List<Cell>> map, Robot robot)
        {
            try
            {
                if(map[robot.X][robot.Y+1] is Empty)
                {
                    map[robot.X][robot.Y] = new Empty();
                    map[robot.X][robot.Y+1] = robot;
                    robot.Y++;
                    robot.Fuel--;
                    robot.PressedKeyStatus = "d";
                } else if(map[robot.X][robot.Y+1] is Atomic)
                {
                    map[robot.X][robot.Y] = map[robot.X][robot.Y+1];
                    map[robot.X][robot.Y+1] = robot;
                    robot.Y++;
                    robot.Fuel -= Atomic.Damage;
                    robot.PressedKeyStatus = "d";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                robot.PressedKeyStatus = "MOVIMENTO INVÁLIDO";
            }
            return "";
        }
    }
}