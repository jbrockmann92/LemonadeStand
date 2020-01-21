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
        Computer computer = new Computer();
        int oneOrTwoPlayer;
        int humanOrComputer;
        int currentDay = 0;
        int lengthofGame = 1;
        Store store = new Store();
        Day day = new Day();
        public List<Cup> cupsSold = new List<Cup>();

        public void RunGame()
        {
            OneOrTwoPlayer();
            GameLength();
            Console.Clear();
            day.RandTemperature();
            for (int i = 0; i < lengthofGame; i++)
            {
                store.GoToStore(player);
                Console.Clear();
                day.RandCondition();
                currentDay++;
                player.DeclareInventory();
                WeatherForecast();
                player.RecipeAndPrice();
                WillBuy(player);
                DailyInventoryUsed(player);
                player.AddMoney(player);
                Console.WriteLine($"After day {currentDay}, here are your results:");
                player.CheckProfitOrLoss(player);
                player.DeclareInventory();
                day.RandCondition();
                Console.ReadLine();
                Console.Clear();
                if (oneOrTwoPlayer == 2 && oneOrTwoPlayer == 1)
                {
                    Console.WriteLine("Player 2's turn");
                    store.GoToStore(player2);
                    Console.Clear();
                    day.RandCondition();
                    player2.DeclareInventory();
                    player2.RecipeAndPrice();
                    WillBuy(player2);
                    DailyInventoryUsed(player2);
                    player2.AddMoney(player2);
                    Console.WriteLine($"After day {currentDay}, here are {player2.name}'s results:");
                    player2.CheckProfitOrLoss(player2);
                    player2.DeclareInventory();
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (oneOrTwoPlayer == 2 && humanOrComputer == 2)
                {
                    computer.AddInventory();
                    computer.MakeRecipe();
                    WillBuy(computer);
                    Console.Clear();
                    DailyInventoryUsed(computer);
                    computer.AddMoney(computer);
                    Console.WriteLine($"After day {currentDay}, here are the computer's results:");
                    computer.CheckProfitOrLoss(computer);
                    computer.DeclareInventory();
                }
                else
                {
                    Console.WriteLine("");
                }
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
                Console.WriteLine("Sorry, that's not a valid input");
                OneOrTwoPlayer();
            }
            else
            {
                if (oneOrTwoPlayer == 2)
                {
                    HumanOrComputer();
                    Names();
                }
                Console.WriteLine("What would you like your name to be?");
                player.name = Console.ReadLine();
                Console.WriteLine("Got it!");
                Console.WriteLine("");
            }
        }

        public void HumanOrComputer()
        {
            Console.WriteLine("Would you like to play with two human players, or play against a computer player? Press 1 for human and 2 for computer.");
            humanOrComputer = int.Parse(Console.ReadLine());
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

        public void Names()
        {
            Console.WriteLine("What would you like player 1's name to be?");
            player.name = Console.ReadLine();
            Console.WriteLine("What would you like player 2's name to be?");
            player2.name = Console.ReadLine();
        }

        public void WhichWon()
        {
            if (player.wallet.Money > player2.wallet.Money)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (player.wallet.Money == player2.wallet.Money)
            {
                Console.WriteLine("You tie!");
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

        //Single Responsibility used here. Added several functions inside WillBuy() rather than doing all of the code in this function, and only calculated here the odds that someone will buy
        public void WillBuy(Player player)
        {
            day.RandomizeWeather();
            day.CalcIngredientValues(player);
            double buyPrice = ((5 - player.recipe.pricePerCup) / 5) * 100;
            double totalCupsSold = day.weatherBuyValue / buyPrice;
            AddCupsSold(totalCupsSold);
        }

        public void AddCupsSold(double totalCupsSold)
        {
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


