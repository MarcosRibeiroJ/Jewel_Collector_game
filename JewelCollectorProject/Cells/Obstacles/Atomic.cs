namespace JewelCollectorProject.Cells.Obstacles
{
    /// <summary>
    /// Classe que herda da classe abstrata Cell.
    /// Esse elemento será responsável por causar dano ao robô durante o jogo.
    /// Possui dois atributos do tipo inteiro, um chamado DamageArea que representa o dano quando robô estiver ao seu lado em qualquer uma das quatro direções.
    /// E o outro chamado Damage, representa o dano causado ao robô quando ele atravessa diretamente o obstáculo.
    /// </summary>
    public class Atomic : Cell
    {
        public static int DamageArea {get;} = 10;
        public static int Damage {get;} = 30;
        
        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// </summary>
        /// <returns>Retorna a impressão visual de Atomic no jogo formatada na cor de fundo amarelo escuro e cor de texto preto.</returns>
        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            return " !! ";
        }
    }
}