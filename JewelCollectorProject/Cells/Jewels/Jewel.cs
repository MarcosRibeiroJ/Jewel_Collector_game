using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells.Jewels
{
    /// <summary>
    /// Classe abstrata de Jewel que herda de Cell
    /// Possui apenas um atributo do tipo inteiro representando o valor de cada Jewel
    /// </summary>
    public abstract class Jewel : Cell
    {
        public int JewelValue {get;}
        public Jewel(int value)
        {
            this.JewelValue = value;
        }
    }
}