using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Jewels
{
    /// <summary>
    /// Classe que herda de Jewel.
    /// Possui o atributo herdado JewelValue.
    /// </summary>
    public class RedJewel : Jewel
    {
        /// <summary>
        /// Construtor de RedJewel que acessa o construtor da classe mãe Jewel, passando como parâmetro um inteiro que será utilizado em JewelValue.
        /// </summary>
        public RedJewel() : base(100){}

        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual de RedJewel no jogo formatada na cor de fundo vermelho e cor de texto preto.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            return " JR ";
        }
    }
}