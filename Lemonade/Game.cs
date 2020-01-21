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
        Player player2 = new Player();
        int oneOrTwoPlayer;
        List<Day> days;
        int currentDay = 1;
        int lengthofGame = 1;
        Store store = new Store();
        Day day = new Day();
        public List<Cup> cupsSold = new List<Cup>();

        public void RunGame()
        {
            OneOrTwoPlayer();
            day.RandTemperature();
            if (oneOrTwoPlayer == 1)
            {           
                for (int i = 0; i < lengthofGame; i++)
                {
                    GameLength();
                    store.GoToStore(player);
                    day.RandCondition();
                    player.DeclareInventory();
                    WeatherForecast();
                    player.RecipeAndPrice();
                    WillBuy(player);
                    DailyInventoryUsed(player);
                    player.AddMoney(player);
                    Console.WriteLine($"After day {currentDay}, here are your results:");
                    player.CheckProfitOrLoss(player);
                    player.DeclareInventory();
                    currentDay++;
                    day.RandCondition();
                    Console.ReadLine();
                }
            }
            else if (oneOrTwoPlayer == 2)
            {

                for (int i = 0; i < lengthofGame; i++)
                {
                    GameLength();
                    Console.WriteLine("You've chosen a two-player game. Player 1 goes first");
                    store.GoToStore(player);
                    day.RandCondition();
                    player.DeclareInventory();
                    WeatherForecast();
                    player.RecipeAndPrice();
                    WillBuy(player);
                    DailyInventoryUsed(player);
                    player.AddMoney(player);
                    Console.WriteLine($"After day {currentDay}, here are Player 1's results:");
                    player.CheckProfitOrLoss(player);
                    player.DeclareInventory();
                    day.RandCondition();
                    Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Player 2's turn");
                    store.GoToStore(player2);
                    day.RandCondition();
                    player2.DeclareInventory();
                    player2.RecipeAndPrice();
                    WillBuy(player2);
                    DailyInventoryUsed(player2);
                    player2.AddMoney(player2);
                    Console.WriteLine($"After day {currentDay}, here are Player 2's results:");
                    player2.CheckProfitOrLoss(player2);
                    player2.DeclareInventory();
                    currentDay++;
                    day.RandCondition();
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Not a valid input. Please try again!");
                OneOrTwoPlayer();
            }
            Console.WriteLine("Game is over");
            WhichWon();
            Console.ReadLine();
        }

        public void OneOrTwoPlayer()
        {
            Console.WriteLine("Would you like to play a one- or two-player game?");
            oneOrTwoPlayer = int.Parse(Console.ReadLine());
            if (oneOrTwoPlayer != 1 && oneOrTwoPlayer != 2)
            {
                Console.WriteLine("sorry, that's not a valid input");
                OneOrTwoPlayer();
            }
            else
            {
                Console.WriteLine("Alright, let's go!");
            }
        }
        public void GameLength()

        {
            Console.WriteLine("How many days would you like to play for? You can choose up to 21 days.");

            int tempLengthofGame = int.Parse(Console.ReadLine());
            if (tempLengthofGame > 0 && tempLengthofGame < 22)
            {
                lengthofGame = tempLengthofGame;
            }
            else
            {
                Console.WriteLine("Please try again. The game can only be up to 21 days long");
                GameLength();
            }
        }

        public void WhichWon()
        {
            if (player.wallet.Money > player2.wallet.Money)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
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

        public void DailyInventoryUsed(Player player)
        {
            for (int i = 0; i < player.cupsSold.Count; i++)
            {
                player.inventory.lemons.RemoveAt(0);
                player.inventory.sugarCubes.RemoveAt(0);
                player.inventory.iceCubes.RemoveAt(0);
                player.inventory.cups.RemoveAt(0);
            }
        }

        //Single Responsibility used here
        public void WillBuy(Player player)
        {
            day.RandomizeWeather();
            day.CalcIngredientValues(player);
            double buyPrice = ((5 - player.recipe.pricePerCup) / 5) * 100;
            double totalCupsSold = day.weatherBuyValue / buyPrice;
            for (int i = 0; i < totalCupsSold; i++)
            {
                Cup cup = new Cup();
                if (player.inventory.lemons.Count > player.cupsSold.Count && player.inventory.sugarCubes.Count > player.cupsSold.Count && player.inventory.iceCubes.Count > player.cupsSold.Count && player.inventory.cups.Count > player.cupsSold.Count)
                {
                    player.cupsSold.Add(cup);
                    Sales(player);
                }
            }
        }
        public void Sales(Player player)

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
