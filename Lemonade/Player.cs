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
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;
        public int recipeLemons;
        public int recipeSugarCubes;
        public int recipeIceCubes;
        public void CreateRecipe()

        {
            recipe = new Recipe();
            Console.WriteLine("How many Lemons in your recipe?");
            recipe.amountOfLemons = int.Parse(Console.ReadLine());
            

            Console.WriteLine("How many Sugar Cubes in your recipe?");
            recipe.amountOfSugarCubes = int.Parse(Console.ReadLine());
            

            Console.WriteLine("How many Ice Cubes in your recipe?");
            recipe.amountOfIceCubes = int.Parse(Console.ReadLine());

            Console.WriteLine("Set your price per cup");
            recipe.pricePerCup = double.Parse(Console.ReadLine());
        }
    }
    
}
