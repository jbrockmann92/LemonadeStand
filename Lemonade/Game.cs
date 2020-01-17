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
        int currentDay = 1;
        int lengthofGame = 3;
        Store store = new Store();
        Day day = new Day();
        List<Cup> cupsSold = new List<Cup>();

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
            for (int i = 1; i < lengthofGame; i++)
            {
                //Passing player into the GoToStore function. Player actually goes to store. Makes sense
                store.GoToStore(player);
                PrintInventory();
                DailyInventoryUsed(player);
                player.CreateRecipe();
                player.SetPrice();
                WillBuy();
                AddMoney();
                PrintInventory();
                Console.ReadLine();
            }
            Console.WriteLine("Game is over");
            Console.ReadLine();

        }

        public void CheckProfitOrLoss()
        {
            if (player.wallet.money > 1000)
            {
                Console.WriteLine($"Your total profit is {1000 - player.wallet.money}");
            }
            if (player.wallet.money <= 1000)
            {
                Console.WriteLine($"Your total loss is {(player.wallet.money - 1000) * -1}");
            }

        }

        public void WeatherForecast()
        {
            Console.WriteLine($"The forecast for tomorrow looks like {day.weather.predictedForecast}");
            //Works for now, but this probably shows today's forecast, not tomorrow's
        }

        public void PrintInventory()
        {
            Console.WriteLine($"After day {currentDay}, here are the results:");
            Console.WriteLine($"You have {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {player.inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {player.inventory.cups.Count} cups");
            Console.WriteLine($"You have {player.wallet.money} left");
            CheckProfitOrLoss();
            currentDay++;
            WeatherForecast();
            //might not be cleanest here, but works for now
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
            double totalCupsSold = day.weatherBuyValue / (20 * buyPrice);
            //I think this works. Seems unnecessarily complicated
            for (int i = 0; i < totalCupsSold; i++)
            {
                Cup cup = new Cup();
                cupsSold.Add(cup);
            }
        }

    }
}
