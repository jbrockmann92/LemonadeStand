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
        int currentDay = 0;
        int lengthofGame;
        Store store = new Store();
        Day day = new Day();
        List<Cup> cupsSold = new List<Cup>();

        public void RunGame()
        {
            GameLength();
            day.RandTemperature();
            for (int i = 0; i < lengthofGame; i++)
            {
                store.GoToStore(player);
                day.RandCondition();
                PrintInventory();
                player.RecipeAndPrice();
                WillBuy();
                DailyInventoryUsed(player);
                AddMoney();
                Console.WriteLine($"After day {currentDay}, here are the results:");
                CheckProfitOrLoss();
                PrintInventory();
                day.RandCondition();
                Console.ReadLine();            }
            Console.WriteLine("Game is over");
            Console.ReadLine();
        }

        public void GameLength()

        {
            Console.WriteLine("How many days would you like to play for? You can choose up to 21 days.");
            int tempLengthofGame = int.Parse(Console.ReadLine());
            if (tempLengthofGame < 22)
            {
                lengthofGame = tempLengthofGame;
            }
            else
            {
                Console.WriteLine("Please try again. The game can only be up to 21 days long");
                GameLength();
            }
        }

        public void CheckProfitOrLoss()
        {
            Console.WriteLine($"You sold a total of {cupsSold.Count} cups");
            if (player.wallet.Money > 100)
            {
                Console.WriteLine($"Your total profit is ${Math.Round((100 - player.wallet.Money) * -1)}");
            }
            if (player.wallet.Money <= 100)
            {
                Console.WriteLine($"Your total loss is ${Math.Round(player.wallet.Money - 100)}");
            }

        }

        public void WeatherForecast()
        {
            Console.WriteLine($"The forecast for tomorrow looks like {day.weather.predictedForecast}, with a temperature of {day.weather.temperature} degrees");
            if (day.weatherBuyValue < 50)
            {
                Console.WriteLine("Poor selling conditions...");
            }
            else if (day.weatherBuyValue > 51 && day.weatherBuyValue < 100)
            {
                Console.WriteLine("Fair selling conditions");
            }
            else if (day.weatherBuyValue > 101 && day.weatherBuyValue < 150)
            {
                Console.WriteLine("Good selling conditions!");
            }
            else
            {
                Console.WriteLine("Fantastic selling conditions!!");
            }
            Console.WriteLine("");
        }

        public void PrintInventory()
        {
            Console.WriteLine("");
            Console.WriteLine($"You have {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {player.inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {player.inventory.cups.Count} cups");
            Console.WriteLine($"You have ${Math.Round(player.wallet.Money, 5)} left");
            currentDay++;
            Console.WriteLine("");
            WeatherForecast();
        }

        public void AddMoney()
        //Single responsibility method for adding money to wallet after a sale
        {
            foreach (Cup cup in cupsSold)
            {
                player.wallet.Money += player.recipe.pricePerCup;
            }
        }

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

        //Single Responsibility used here
        public void WillBuy()
        {
            day.RandomizeWeather();
            day.CalcIngredientValues(player);
            double buyPrice = (5 - player.recipe.pricePerCup) / 5;
            double totalCupsSold = day.weatherBuyValue / (100 * buyPrice);
            for (int i = 0; i < totalCupsSold; i++)
            {
                Cup cup = new Cup();
                if (player.inventory.lemons.Count > cupsSold.Count && player.inventory.sugarCubes.Count > cupsSold.Count && player.inventory.iceCubes.Count > cupsSold.Count && player.inventory.cups.Count > cupsSold.Count)
                {
                    cupsSold.Add(cup);
                    Sales();
                }
            }
        }
        
        public void Sales()
        {
            if (player.inventory.cups.Count > 0 && player.inventory.lemons.Count > 0 && player.inventory.sugarCubes.Count > 0 && player.inventory.iceCubes.Count > 0)
            {
                Console.WriteLine("Made a sale!");
            }
            else
            {
                Console.WriteLine("Out of an item in your inventory to make lemonade!");
            }
        }

    }
}
