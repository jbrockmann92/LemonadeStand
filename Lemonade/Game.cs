﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Game
    {
        Player player;
        List<Day> days;
        int currentDay;
        int lengthofGame;

        public void Introduction()
        {
            Console.WriteLine("Hello, welcome to the Lemonade Stand Game");
            Console.WriteLine("In this game, you'll be the owner of a lemonade stand, and your decisions will be the difference between");
            Console.WriteLine("money and fame, and homelessness. The choice is yours.");
        }

        public void BeginGame()
        {
            lengthofGame = 7;

        }
    }
}
