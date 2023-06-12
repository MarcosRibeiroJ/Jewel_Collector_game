namespace JewelCollectorProject.Cells.Jewels
{
    /// <summary>
    /// Classe que herda de Jewel.
    /// Possui o atributo herdado JewelValue e um atributo interno chamado FuelValue, representando o valor de combustível que fornece ao robô.
    /// </summary>
    public class BlueJewel : Jewel
    {
        /// <summary>
        /// Construtor de BlueJewel que acessa o construtor da classe mãe Jewel, passando como parâmetro um inteiro que será utilizado em JewelValue.
        /// </summary>
        public BlueJewel() : base(10) {}
        public int FuelValue {get;} = 5;
        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual de BlueJewel no jogo formatada na cor de fundo azul e cor de texto preto.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            return " JB ";
        }
    }
}