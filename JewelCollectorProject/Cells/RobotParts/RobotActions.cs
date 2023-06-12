using JewelCollectorProject.Cells.Jewels;
using JewelCollectorProject.Cells.Obstacles;

namespace JewelCollectorProject.Cells.RobotParts
{
    /// <summary>
    /// Classe criada para executar a ação do robô ao encontrar uma joia ou árvore.
    /// </summary>
    public class RobotActions
    {
        /// <summary>
        /// Método que incrementa em 1 o valor da Bag do robô e em seguida verifica o tipo de Jewel recebido e incrementa o TotalScore de acordo com o tipo de joia.
        /// Caso a joia seja do tipo BlueJewel, também aumenta o combustível do robô.
        /// </summary>
        /// <param name="jewel">Elemento recebido de Radar após verificar as regiões ao redor do robô.</param>
        /// <param name="robot">Elemento que representa o robô do jogo.</param>
        public void useJewel(Cell jewel, Robot robot)
        {
            robot.Bag++;
            if(jewel is RedJewel redJewel)
            {
                robot.TotalScore += redJewel.JewelValue;
            } else if(jewel is GreenJewel greenJewel)
            {
                robot.TotalScore += greenJewel.JewelValue;
            } else if(jewel is BlueJewel blueJewel)
            {
                robot.TotalScore += blueJewel.JewelValue;
                robot.Fuel += blueJewel.FuelValue;
            }
        }
        /// <summary>
        /// Método que recarrega o robô de acordo com o seguinte critério:
        /// Se a propriedade IsRechargeable do elemento Tree for true, recarrega o robô e modifica essa propriedade para false.
        /// Isso garante que só é possível recarregar uma vez em cada árvore.
        /// </summary>
        /// <param name="cell">Elemento recebido de Radar após verificar as regiões ao redor do robô.</param>
        /// <param name="robot">Elemento que representa o robô do jogo.</param>
        public void useTree(Cell cell, Robot robot)
        {
            if(cell is Tree tree && tree.IsRechargeable)
            {
                robot.Fuel += tree.FuelValue;
                tree.IsRechargeable = false;
            }
        }
    }
}