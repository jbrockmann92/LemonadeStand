using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Store
    {
        double pricePerLemon = .2;
        double pricePerSugarCube = .05;
        double pricePerIceCube = .05;
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
            BuyInventory(player);
        }

        public void PrintPrices()
        {
            Console.WriteLine($"Lemons cost ${pricePerLemon}");
            Console.WriteLine($"Sugar Cubes cost ${pricePerSugarCube}");
            Console.WriteLine($"Ice Cubes cost ${pricePerIceCube}");
            Console.WriteLine($"Cups cost ${pricePerCup}");

        }

        public void BuyInventory(Player player)
        {
            bool isValid = false;
            while(isValid == false)
            {
                if (player.wallet.Money >= 0)
                {
                    Console.WriteLine("How many Lemons would you like to buy?");
                    moreLemons = int.Parse(Console.ReadLine());
                    if (player.wallet.Money >= pricePerLemon * moreLemons)
                    {
                        isValid = true;
                        AddLemons(player);
                    }
                    else
                    {
                        Console.WriteLine("You can't afford that!");
                        return;
                    }
                    Console.WriteLine("How many Sugar Cubes would you like to buy?");
                    moreSugar = int.Parse(Console.ReadLine());
                    if (player.wallet.Money >= pricePerSugarCube * moreSugar)
                    {
                        isValid = true;
                        AddSugar(player);
                    }
                    else
                    {
                        Console.WriteLine("You're out of money!");
                        return;
                    }

                    Console.WriteLine("How many Ice Cubes would you like to buy?");
                    moreIce = int.Parse(Console.ReadLine());
                    if (player.wallet.Money >= pricePerIceCube * moreIce)
                    {
                        isValid = true;
                        AddIce(player);
                    }
                    else
                    {
                        Console.WriteLine("You can't afford that!");
                        return;
                    }

                    Console.WriteLine("How many cups would you like to buy?");
                    moreCups = int.Parse(Console.ReadLine());
                    if (player.wallet.Money >= pricePerCup * moreCups)
                    {
                        isValid = true;
                        AddCups(player);
                    }
                    else
                    {
                        Console.WriteLine("You can't afford that!");
                        return;
                    }
                }
            }
        }

        public void AddLemons(Player player)
        {
            for (int i = 0; i < moreLemons; i++)
            {
                Lemon lemon = new Lemon();
                player.inventory.lemons.Add(lemon);
            }
            player.wallet.Money -= pricePerLemon * moreLemons;
        }

        public void AddSugar(Player player)
        {
            for (int i = 0; i < moreSugar; i++)
            {
                SugarCube sugar = new SugarCube();
                player.inventory.sugarCubes.Add(sugar);
            }
            player.wallet.Money -= pricePerSugarCube * moreSugar;
        }

        public void AddIce(Player player)
        {
            for (int i = 0; i < moreIce; i++)
            {
                IceCube ice = new IceCube();
                player.inventory.iceCubes.Add(ice);
            }
            player.wallet.Money -= pricePerIceCube * moreIce;
        }

        public void AddCups(Player player)
        {
            for (int i = 0; i < moreCups; i++)
            {
                Cup cup = new Cup();
                player.inventory.cups.Add(cup);
            }
            player.wallet.Money -= pricePerCup * moreCups;
        }
    }
}
