namespace JewelCollectorProject.Cells.Jewels
{
    /// <summary>
    /// Classe que herda de Jewel.
    /// Possui o atributo herdado JewelValue.
    /// </summary>
    public class GreenJewel : Jewel
    {
        /// <summary>
        /// Construtor de GreenJewel que acessa o construtor da classe mãe Jewel, passando como parâmetro um inteiro que será utilizado em JewelValue.
        /// </summary>
        public GreenJewel() : base(50){}

        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual de GreenJewel no jogo formatada na cor de fundo verde e cor de texto preto.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            return " JG ";
        }
    }
}