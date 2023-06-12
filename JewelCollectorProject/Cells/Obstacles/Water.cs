namespace JewelCollectorProject.Cells.Obstacles
{
    /// <summary>
    /// Classe que no jogo será usada como obstáculo para o robô.
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