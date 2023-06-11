using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Jewels
{
    /// <summary>
    /// Classe abstrata de Jewel que herda de Cell
    /// Possui apenas um atributo do tipo inteiro representando o valor de cada Jewel.
    /// </summary>
    public abstract class Jewel : Cell
    {
        public int JewelValue {get;}
        /// <summary>
        /// Construtor de Jewel.
        /// O construtor tem a finalidade de receber um inteiro que será utilizado em JewelValue.
        /// Esse valor será passado no momento que outros elementos que herdam de Jewel forem construídos.
        /// </summary>
        /// <param name="value">valor do tipo int que atribuído a JewelValue</param>
        public Jewel(int value)
        {
            this.JewelValue = value;
        }
    }
}