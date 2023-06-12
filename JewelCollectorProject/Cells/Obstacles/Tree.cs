namespace JewelCollectorProject.Cells.Obstacles
{
    /// <summary>
    /// Classe que no jogo será usada como obstáculo para o robô na primeira fase do jogo.
    /// A partir da fase 2, pode ser utilizada para recarregar o combustível do robô, o total de combustível disponível em cada árvore está armazenado no atributo FuelValue.
    /// Existe uma regra que só permite que o robô abasteça uma vez em cada árvore, o atributo que controla essa função é é um bool chamado de IsRechargeable.
    /// </summary>
    public class Tree : Cell
    {
        public int FuelValue {get;} = 3;
        public bool IsRechargeable {get; set;} = true;
        
        /// <summary>
        /// Sobrescrita do método ToString herdado da classe abstrata Cell.
        /// A classe Tree pode retornar dois tipos de impressão visual, de acordo com uma condicional determinada por IsRechargeable.
        /// Caso esse atributo seja true, a impressão será com cor de fundo verde escuro e cor de texto preto.
        /// Casso esse atributo seja false, a impressão será com cor de fundo preto e cor de texto branco.
        /// Isso ajuda visualmente o jogador a diferenciar árvores que ele já utilizou o combustível durante o jogo.
        /// </summary>
        public override string ToString()
        {
            Console.BackgroundColor = IsRechargeable ? ConsoleColor.DarkGreen : ConsoleColor.Black;
            Console.ForegroundColor = IsRechargeable ? ConsoleColor.DarkRed : ConsoleColor.White;
            return " $$ ";
        }
    }
}