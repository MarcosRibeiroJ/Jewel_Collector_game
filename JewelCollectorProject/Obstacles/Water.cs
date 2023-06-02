using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Obstacles
{
    /// <summary>
    /// Classe que no jogo será usada como obstáculo para Robot.
    /// </summary>
    public class Water : Cell
    {
        /// <summary>
        /// Reescrita do método ToString herdado da classe abstrata Cell
        /// </summary>
        /// <returns>Retorna a impressão visual de água no jogo.</returns>
        public override string ToString()
        {
            return " ## ";
        }
    }
}