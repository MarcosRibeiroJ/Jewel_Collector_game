using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelCollectorProject.Cells.Obstacles;
using JewelCollectorProject.Cells.Jewels;

namespace JewelCollectorProject.Cells.RobotParts
{
    /// <summary>
    /// Classe que representa o radar do robô.
    /// Esse radar verifica nas 4 posições adjacentes ao robô, se existe alguma célula contendo uma joia, árvore ou elemento radioativo (Atomic)
    /// Caso encontre um desses elementos, realiza uma ação específica para o tipo encontrado.
    /// - Se o elemento encontrato for do tipo Atomic:
    /// Reduz do combustível do robô no valor determinado na classe Atomic.
    /// - Se o elemento encontrado for do tipo Jewel:
    /// Envia o objeto para classe e método responsáveis por tratar o tipo Jewel e insere um novo objeto do tipo Empty no mesmo local.
    /// - Se o elemento encontrado for do tipo Tree:
    /// Envia o objeto para classe e método responsáveis por tratar o tipo Tree.
    /// Possui um atributo do tipo RobotActions que simboliza a ação que será realizada. Esse objeto é inserido utilizando o conceito de composição.
    /// </summary>
    public class Radar
    {
        private RobotActions action = new RobotActions();
        /// <summary>
        /// Método responsável por verificar nas 4 posições adjacentes ao robô (cima, baixo, direita, esquerda), se existe algum elemento do tipo Tree, Atomic e Jewel.
        /// </summary>
        /// <param name="map">Matriz do tipo Map que representa o mapa do jogo.</param>
        /// <param name="robot">Robô que deverá ser movimentado no mapa do Jogo</param>
        public void check(List<List<Cell>> map, Robot robot)
        {
            try
            {
                if (robot.X > 0 && map[robot.X - 1][robot.Y] is Atomic)
                {
                    robot.Fuel -= Atomic.DamageArea;
                } else if(robot.X > 0 && map[robot.X - 1][robot.Y] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X - 1][robot.Y], robot);
                    Cell cell = new Empty();
                    map[robot.X - 1][robot.Y] = cell;
                } else if(robot.X > 0 && map[robot.X - 1][robot.Y] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X - 1][robot.Y], robot);
                }
                if (robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Atomic)
                {
                    robot.Fuel -= Atomic.DamageArea;
                } else if(robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X + 1][robot.Y], robot);
                    Cell cell = new Empty();
                    map[robot.X + 1][robot.Y] = cell;
                } else if(robot.X < map.Count - 1 && map[robot.X + 1][robot.Y] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X + 1][robot.Y], robot);
                }
                if (robot.Y > 0 && map[robot.X][robot.Y - 1] is Atomic)
                {
                    robot.Fuel -= Atomic.DamageArea;
                } else if(robot.Y > 0 && map[robot.X][robot.Y - 1] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X][robot.Y - 1], robot);
                    Cell cell = new Empty();
                    map[robot.X][robot.Y - 1] = cell;
                } else if(robot.Y > 0 && map[robot.X][robot.Y - 1] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X][robot.Y - 1], robot);
                }
                if (robot.Y < map.Count - 1 && map[robot.X][robot.Y + 1] is Atomic)
                {
                    robot.Fuel -= Atomic.DamageArea;
                } else if(robot.Y < map.Count - 1 && map[robot.X][robot.Y + 1] is Jewel && robot.PressedKeyStatus == "g")
                {
                    action.useJewel(map[robot.X][robot.Y + 1], robot);
                    Cell cell = new Empty();
                    map[robot.X][robot.Y + 1] = cell;
                } else if(robot.Y < map.Count - 1 && map[robot.X][robot.Y + 1] is Tree && robot.PressedKeyStatus == "g" && map.Count > 10)
                {
                    action.useTree(map[robot.X][robot.Y + 1], robot);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                robot.PressedKeyStatus = "";
            }
        }
    }

}