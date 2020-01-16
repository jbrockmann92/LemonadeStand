using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Game
    {
        Player player = new Player();
        List<Day> days;
        int currentDay;
        int lengthofGame = 7;
        Store store = new Store();

        public void Introduction()
        {
            Console.WriteLine("Hello, welcome to the Lemonade Stand Game");
            Console.WriteLine("In this game, you'll be the owner of a lemonade stand, and your decisions will be the difference between");
            Console.WriteLine("money and fame, and homelessness. The choice is yours.");
        }

        public void BeginGame()
        {
            store.GoToStore(player);
        }

        public void PrintInventory()
        {
            Console.WriteLine($"You have {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {player.inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {player.inventory.cups.Count} cups");
        }
    }
}
