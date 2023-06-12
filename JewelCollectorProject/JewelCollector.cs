namespace JewelCollectorProject
{
    /// <summary>
    /// Classe principal do programa.
    /// </summary>
    public class JewelCollector
    {
        /// <summary>
        /// Método principal do programa.
        /// Instancia um objeto do tipo Game e executa o método startGame para iniciar o jogo.
        /// </summary>
        public static void Main() {
            Game newGame = new Game();
            newGame.startGame();
        }
    }
}