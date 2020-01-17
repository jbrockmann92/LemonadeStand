﻿using System;
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
        Day day = new Day();
        List<Cup> cupsSold = new List<Cup>() { new Cup(), new Cup(), new Cup() };

        public void Introduction()
        {
            Console.WriteLine("Hello, welcome to the Lemonade Stand Game");
            Console.WriteLine("In this game, you'll be the owner of a lemonade stand, and your decisions will be the difference between");
            Console.WriteLine("money and fame, and homelessness. The choice is yours.");
            Console.WriteLine("");
            Console.WriteLine("Here are the rules: You'll buy ingredients and have the option to change your recipe every day.");
            Console.WriteLine("The better your recipe is, the higher the chances will be of customers buying your lemonade.");
            Console.WriteLine("You'll also get the chance to change how much you charge per cup before each day.");
            Console.WriteLine("You'll earn money, and use that money to buy more ingredients.");
            Console.WriteLine("The game lasts 7 days, and you'll be given a score at the end.");
            Console.WriteLine("Press any key when you're ready to start.");
            Console.ReadLine();
            Console.WriteLine("Good luck!");
            Console.ReadLine();
        }

        public void RunGame()
        {
            for (int i = 0; i < lengthofGame; i++)
            {
                //Passing player into the GoToStore function. Player actually goes to store. Makes sense
                store.GoToStore(player);
                PrintInventory();
                DailyInventoryUsed(player);
                PrintInventory();
                Console.ReadLine();
            }

        }


        public void PrintInventory()
        {
            Console.WriteLine($"You have {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {player.inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {player.inventory.cups.Count} cups");
        }

        public void AddMoney()
        //Sinlge responsibility method for adding money to wallet after a sale
        {
            foreach (Cup cup in cupsSold)
            {
                player.wallet.money += player.recipe.pricePerCup;
            }
        }

        //NEED THIS! THIS IS HOW WE REMOVE ITEMS FROM THE LIST WHEN A CUSTOMER BUYS SOMETHING.NEEDS TO BE ADJUSTED FOR HOW MANY ARE IN THE RECIPE, BUT IT'S WORKING

        public void DailyInventoryUsed(Player player)
        {
            for (int i = 0; i < cupsSold.Count; i++)
            {
                player.inventory.lemons.RemoveAt(0);
                player.inventory.sugarCubes.RemoveAt(0);
                player.inventory.iceCubes.RemoveAt(0);
                player.inventory.cups.RemoveAt(0);
            }
        }


        public void WillBuy()
        {
            //Something about if the total values from CalculateWeather() and Calculate
            day.RandomizeWeather();
            day.CalcIngredientValues(player);
            //Add something here about calculating the price into the equation?
            double buyPrice = 1 - player.recipe.pricePerCup;
            //I believe we are doing the price per cup in terms of cents, not numbers in 100
            buyPrice *= 100;
        }
        public void Sales()
        {
            if (player.inventory.cups.Count > 0)
            {
                Console.WriteLine("Made a sale!");
            }
            else
            {
                Console.WriteLine("Out of cups!");
            }
            if (player.inventory.lemons.Count > 0)
            {
                Console.WriteLine("Made a sale!");
            }
            else
            {
                Console.WriteLine("Out of lemons!");
            }
            if (player.inventory.sugarCubes.Count > 0)
            {
                Console.WriteLine("Made a sale!");
            }
            else
            {
                Console.WriteLine("Out of sugar cubes!");
            }
            if (player.inventory.iceCubes.Count > 0)
            {
                Console.WriteLine("Made a sale!");
            }
            else
            {
                Console.WriteLine("Out of ice cubes!");
            }
        }//needs to be done for every ingredient in recipe? i think yes

    }
}
