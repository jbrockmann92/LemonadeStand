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
        int currentDay = 0;
        int lengthofGame = 7;

        Store store = new Store();
        Day day = new Day();
        List<Cup> cupsSold = new List<Cup>();

        public void Introduction()
        {
            UserInterface.DisplayIntroduction();
        }

        public void RunGame()
        {
            for (int i = 1; i < lengthofGame; i++)
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
                Console.ReadLine();
            }
            Console.WriteLine("Game is over");
            Console.ReadLine();
        }

        public void CheckProfitOrLoss()
        {
            Console.WriteLine($"You sold a total of {cupsSold.Count} cups");
            if (player.wallet.Money > 100)
            {
                Console.WriteLine($"Your total profit is ${(100 - player.wallet.Money) * -1}");
            }
            if (player.wallet.Money <= 100)
            {
                Console.WriteLine($"Your total loss is ${player.wallet.Money - 100}");
            }

        }

        public void WeatherForecast()
        {
            Console.WriteLine($"The forecast for tomorrow looks like {day.weather.predictedForecast}, with a temperature of {day.weather.temperature} degrees");
        }

        public void PrintInventory()
        {
            Console.WriteLine($"You have {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {player.inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {player.inventory.cups.Count} cups");
            Console.WriteLine($"You have ${player.wallet.Money} left");
            currentDay++;
            WeatherForecast();
        }

        public void AddMoney()
        //Sinlge responsibility method for adding money to wallet after a sale
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
                //Second time through, cupsSold is higher than our total inventory. Just a good sales day apparently. Need validation here. 
                //Need to re-work the numbers. Selling too many cups and not making enough money. Each cup ends up costing like $1. Bad business model.
                //Could be fixed by using Pitcher Class
                player.inventory.lemons.RemoveAt(0);
                player.inventory.sugarCubes.RemoveAt(0);
                player.inventory.iceCubes.RemoveAt(0);
                player.inventory.cups.RemoveAt(0);
            }
        }


        public void WillBuy()
        {
            day.RandomizeWeather();
            day.CalcIngredientValues(player);
            double buyPrice = 1 - player.recipe.pricePerCup;
            double totalCupsSold = day.weatherBuyValue / (100 * buyPrice);
            for (int i = 0; i < totalCupsSold; i++)
            {
                Cup cup = new Cup();
                cupsSold.Add(cup);
            }
        }
        
        //This is the validation for the issue above in DailyInventoryUsed() if the sales are more than the inventory.
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
