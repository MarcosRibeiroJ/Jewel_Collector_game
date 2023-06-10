using JewelCollectorProject.Maps;
namespace JewelCollectorProject
{
    public class JewelCollector
    {
        public static void Main() {
            Game newGame = new Game(30);
            newGame.startGame();
        }
    }
}