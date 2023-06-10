using JewelCollectorProject.Maps;
namespace JewelCollectorProject
{
    public class JewelCollector
    {
        public static void Main() {
            Game newGame = new Game(10);
            newGame.startGame();
        }
    }
}