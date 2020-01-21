using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Player
    {
        public string name;
        public Inventory inventory = new Inventory();
        public Wallet wallet = new Wallet();
        public Recipe recipe = new Recipe();
        public Pitcher pitcher = new Pitcher();

        public void RecipeAndPrice()
        {
            CreateRecipe();
            SetPrice();
        }

        public void CreateRecipe()
        {
            bool isValid = false;
            while(isValid == false)
            {
                if (inventory.lemons.Count > 0)
                {
                    Console.WriteLine("How many Lemons in your recipe?");
                    recipe.amountOfLemons = int.Parse(Console.ReadLine());
                    if (recipe.amountOfLemons <= inventory.lemons.Count)
                    {
                        isValid = true;
                        Console.WriteLine($"Added {recipe.amountOfLemons} to recipe!");
                    }
                    else
                    {
                        Console.WriteLine("Fresh out of Lemons!");
                        return;   
                    }
                }
                if (inventory.sugarCubes.Count > 0)
                {
                    Console.WriteLine("How many sugar cubes in your recipe?");
                    recipe.amountOfSugarCubes = int.Parse(Console.ReadLine());
                    if (recipe.amountOfSugarCubes <= inventory.sugarCubes.Count)
                    {
                        isValid = true;
                        Console.WriteLine($"Added {recipe.amountOfSugarCubes} to recipe!");
                    }
                    else
                    {
                        Console.WriteLine("Fresh out of sugar cubes!");
                        return;
                    }
                }
                if (inventory.iceCubes.Count > 0)
                {
                    Console.WriteLine("How many ice cubes in your recipe?");
                    recipe.amountOfIceCubes = int.Parse(Console.ReadLine());
                    if (recipe.amountOfIceCubes <= inventory.iceCubes.Count)
                    {
                        isValid = true;
                        Console.WriteLine($"Added {recipe.amountOfIceCubes} to recipe!");
                    }
                    else
                    {
                        Console.WriteLine("Fresh out of ice cubes!");
                        return;
                    }
                }
            }

        }
        public void SetPrice()
        {
            bool isValid = false;
            while (isValid == false)
            {
                Console.WriteLine("How much will you charge per cup?");
                Console.WriteLine("Note: max price per cup is $5.00. Remember, the lower you keep this number, the more likely people will be to buy your lemonade.");
                recipe.pricePerCup = double.Parse(Console.ReadLine());

                if (recipe.pricePerCup <= 5)
                {
                    Console.WriteLine($" You will be charging customers ${recipe.pricePerCup} for a cup of lemonade. ");
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Please enter less than or equal to $5!");
                }
            }
        }

        
    }
    
}
