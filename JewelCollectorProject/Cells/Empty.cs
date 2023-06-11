using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells
{
    /// <summary>
    /// Classe que representa um espaço vazio que o robô pode se movimentar.
    /// </summary>
    public class Empty : Cell
    {
        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual de uma célula vazia no jogo formatada na cor de fundo cinza escuro e cor de texto branco.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            return " -- ";
        }
    }
}