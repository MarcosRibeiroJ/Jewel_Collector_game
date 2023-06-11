using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollectorProject.Cells
{
    /// <summary>
    /// Classe abstrata Cell que representa uma célula dentro do jogo.
    /// </summary>
    public abstract class Cell
    {
        /// <summary>
        /// Método abstrato ToString que foi sobrescrito da classe Object.
        /// Quem herdar dessa classe é obrigado a sobrescrever esse método, garantindo que todo elemento do jogo terá uma representação gráfica.
        /// </summary>
        /// <returns>string com a representação gráfica do elemento do jogo.</returns>
        public abstract override string ToString();
    }
}