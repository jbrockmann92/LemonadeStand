using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Store
    {
        double pricePerLemon = .35;
        double pricePerSugarCube = .15;
        double pricePerIceCube = .1;
        double pricePerCup = .15;

        int moreLemons;
        int moreSugar;
        int moreIce;
        int moreCups;

        //Need a method here to bring the Player into the store. Need to run right after amount of days to play is declared,
        //and after each day. Possibly optional

        //Do Single Responsibility Here in GoToStore function
        public void GoToStore(Player player)
        {
            Console.WriteLine("Hello, welcome to the store.");
            PrintPrices();
            CheckIfMoney(player);
        }

        public void PrintPrices()
        {
            Console.WriteLine($"Lemons cost ${pricePerLemon}");
            Console.WriteLine($"Sugar Cubes cost ${pricePerSugarCube}");
            Console.WriteLine($"Ice Cubes cost ${pricePerIceCube}");
            Console.WriteLine($"Cups cost ${pricePerCup}");

        }

        public void CheckIfMoney(Player player)
            //Probably want to check before each individual item, not just the beginning of the store
        {
            if (player.wallet.money > 0)
            {
                BuyInventory(player);
                AddLemons(player);
                AddSugar(player);
                AddIce(player);
                AddCups(player);
            }
            else
            {
                Console.WriteLine("You don't have enough money!");
            }
        }

        public void BuyInventory(Player player)
        {
            Console.WriteLine("How many Lemons would you like to buy?");
            moreLemons = int.Parse(Console.ReadLine());
            AddLemons(player);

            Console.WriteLine("How many Sugar Cubes would you like to buy?");
            moreSugar = int.Parse(Console.ReadLine());
            AddSugar(player);

            Console.WriteLine("How many Ice Cubes would you like to buy?");
            moreIce = int.Parse(Console.ReadLine());
            AddIce(player);

            Console.WriteLine("How many cups would you like to buy?");
            moreCups = int.Parse(Console.ReadLine());
            AddCups(player);
        }

        public void AddLemons(Player player)
        {
            for (int i = 0; i < moreLemons; i++)
            {
                Lemon lemon = new Lemon();
                player.inventory.lemons.Add(lemon);
                player.wallet.money -= pricePerLemon * moreLemons;
            }
        }
        //Have to put i=1 in this case, but i=0 in the others for some reason to get the same result
        //Seems like an error or i is holding its value at one or something when it moves to the next for loop

        public void AddSugar(Player player)
        {
            for (int i = 0; i < moreSugar; i++)
            {
                SugarCube sugar = new SugarCube();
                player.inventory.sugarCubes.Add(sugar);
                player.wallet.money -= pricePerSugarCube * moreSugar;
            }
        }

        public void AddIce(Player player)
        {
            for (int i = 0; i < moreIce; i++)
            {
                IceCube ice = new IceCube();
                player.inventory.iceCubes.Add(ice);
                player.wallet.money -= pricePerIceCube * moreIce;
            }
        }

        public void AddCups(Player player)
        {
            for (int i = 0; i < moreCups; i++)
            {
                Cup cup = new Cup();
                player.inventory.cups.Add(cup);
                player.wallet.money -= pricePerCup * moreCups;
            }
        }
    }
}
