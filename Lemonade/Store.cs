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

        public void GoToStore(Player player)
        {
            Console.WriteLine($"Hello {player.name}, welcome to the store.");
            Console.WriteLine("-------------------------------");
            PrintPrices();
            BuyInventory(player);
        }

        public void PrintPrices()
        {
            Console.WriteLine($"Lemons cost ${pricePerLemon}");
            Console.WriteLine($"Sugar Cubes cost ${pricePerSugarCube}");
            Console.WriteLine($"Ice Cubes cost ${pricePerIceCube}");
            Console.WriteLine($"Cups cost ${pricePerCup}");
            Console.WriteLine("--------------------------------");
        }

        public void BuyInventory(Player player)
        {
            Console.WriteLine($"You currently have ${player.wallet.Money} to spend");
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
                        BuyInventory(player);
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
                        BuyInventory(player);
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
                        BuyInventory(player);
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
                        BuyInventory(player);
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
