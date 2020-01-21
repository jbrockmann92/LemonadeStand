using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Computer : Player

    {
        public void AddInventory()
        {
            for (int i = 0; i < 10; i++)
            {
                Lemon lemon = new Lemon();
                inventory.lemons.Add(lemon);
            }
            for (int i = 0; i < 10; i++)
            {
                SugarCube sugar = new SugarCube();
                inventory.sugarCubes.Add(sugar);
            }
            for (int i = 0; i < 10; i++)
            {
                IceCube ice = new IceCube();
                inventory.iceCubes.Add(ice);
            }
            for (int i = 0; i < 10; i++)
            {
                Cup cup = new Cup();
                inventory.cups.Add(cup);
            }

        }

        public void MakeRecipe()
        {
            recipe.amountOfLemons = 1;
            recipe.amountOfSugarCubes = 1;
            recipe.amountOfIceCubes = 1;
            recipe.pricePerCup = 1;
        }

    }
}
