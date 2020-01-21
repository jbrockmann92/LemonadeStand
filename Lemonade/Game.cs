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

        //Write option to assign each player a name?
        //Create AI to play if the computer is playing against a person

        public void RunGame()
        {
            OneOrTwoPlayer();
            HumanOrComputer();
            GameLength();
            day.RandTemperature();
            if (oneOrTwoPlayer == 2 && humanOrComputer == 2)
            {
                Names();
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
                for (int i = 0; i < lengthofGame; i++)
                {
                    currentDay++;
                    store.GoToStore(player);
                    day.RandCondition();
                    player.DeclareInventory();
                    WeatherForecast();
                    player.RecipeAndPrice();
                    WillBuy(player);
                    DailyInventoryUsed(player);
                    player.AddMoney(player);
                    Console.WriteLine($"After day {i + 1}, here are {player.name}'s results:");
                    player.CheckProfitOrLoss(player);
                    player.DeclareInventory();
                    day.RandCondition();
                    Console.ReadLine();
                    Console.Clear();
                    if (oneOrTwoPlayer == 2 && humanOrComputer == 1)
                    {
                        Console.WriteLine("You've chosen a 2-player game. It's Player 2's turn");
                        for (int j = 0; j < lengthofGame; j++)
                        {
                            Console.WriteLine("Player 2's turn");
                            store.GoToStore(player2);
                            day.RandCondition();
                            player2.DeclareInventory();
                            player2.RecipeAndPrice();
                            WillBuy(player2);
                            DailyInventoryUsed(player2);
                            player2.AddMoney(player2);
                            Console.WriteLine($"After day {i + 1}, here are {player2.name}'s results:");
                            player2.CheckProfitOrLoss(player2);
                            player2.DeclareInventory();
                            Console.ReadLine();
                            Console.Clear();
                            //currentday++ is getting in the way, otherwise I could make only player 2's stuff in the else if statement
                        }
                        WhichWon();
                    }
                    else if (oneOrTwoPlayer == 2 && humanOrComputer == 2)
                    {
                        //Not working here. Goes through this loop 3 times, then allows player 1 to take their turns. Will do 3x3 if we choose 3 days
                        computer.AddInventory();
                        computer.MakeRecipe();
                        WillBuy(computer);
                        DailyInventoryUsed(computer);
                        computer.AddMoney(computer);
                        Console.WriteLine($"After day {i + 1}, here are the computer's results:");
                        computer.DeclareInventory();
                        //Probably won't work yet. still need to create computer's recipe

                    }
                    else
                    {
                        Console.WriteLine("Not a valid input. Please try again!");
                        OneOrTwoPlayer();
                    }
                    //Probably a cleaner way to do this. Right now I've copied a lot of code. Try to have only the second player code in the else if statement
                }

                Console.WriteLine("Game is over");
                WhichWon();
                Console.ReadLine();
            }
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
                Console.WriteLine("Alright, let's go!");
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

        //This is the validation for the issue above in DailyInventoryUsed() if the sales are more than the inventory.
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


