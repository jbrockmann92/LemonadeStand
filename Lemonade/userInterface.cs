using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    public static class UserInterface
    {
        public static void DisplayIntroduction()
        {
            Console.WriteLine("Hello, welcome to the Lemonade Stand Game");
            Console.WriteLine("In this game, you'll be the owner of a lemonade stand, and your decisions will be the difference between");
            Console.WriteLine("money, power, fame, the life of your dreams -- and homelessness. The choice is yours.");
            Console.WriteLine("");
            Console.WriteLine("Here are the rules: You'll buy ingredients and have the option to change your recipe every day.");
            Console.WriteLine("The better your recipe is, the higher the chances will be of customers buying your lemonade.");
            Console.WriteLine("You'll also get the chance to change how much you charge per cup before each day.");
            Console.WriteLine("You'll earn money, and use that money to buy more ingredients.");
            Console.WriteLine("The game lasts 7 days, and you'll be given a score at the end.");
            Console.WriteLine("Press the return key to begin.");
            Console.ReadLine();
            Console.WriteLine("Good luck!");
            Console.ReadLine();
        }
    }
}
