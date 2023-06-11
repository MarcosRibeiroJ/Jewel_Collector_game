using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Obstacles
{
    /// <summary>
    /// Classe que no jogo será usada como obstáculo para Robot.
    /// </summary>
    public class Water : Cell
    {
        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual de água no jogo formatada na cor de fundo azul escuro e cor de texto branco.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            return " ## ";
        }
    }
}