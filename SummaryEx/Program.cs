using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("Ayala"), p2 = new Player("Avital");
            Game game = new Game(p1,p2);
            while(!game.CheckGameOver())
            {
                Console.WriteLine(game.StepInGame());
            }
            Console.WriteLine(game.CheckVictory() + " won\nWell done!!!");
            Console.ReadKey();
        }
    }
}
