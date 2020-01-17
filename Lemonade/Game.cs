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
        int currentDay;
        int lengthofGame = 3;
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


        public void PrintInventory()
        {
            Console.WriteLine($"You have {player.inventory.lemons.Count} lemons");
            Console.WriteLine($"You have {player.inventory.sugarCubes.Count} sugar cubes");
            Console.WriteLine($"You have {player.inventory.iceCubes.Count} ice cubes");
            Console.WriteLine($"You have {player.inventory.cups.Count} cups");
            Console.WriteLine($"You have {player.wallet.money} left");
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
