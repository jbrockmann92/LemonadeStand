using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;
        public int weatherBuyValue;

        //Need a function to randomize weather
        //Need a function to randomize temperature
        //Need a function to randomize customers

        public void RandomizeWeather()
        {
            RandCondition();
            RandTemperature();
            RandCustomer();
        }

        public void RandCondition()
        {
            Random rnd = new Random();
            weather.predictedForecast = weather.weatherConditions[rnd.Next(5)];
            //Probably supposed to do something about 
        }

        public void RandTemperature()
        {
            Random rnd = new Random();
            weather.temperature = rnd.Next(30, 105);
            //Need to assign values to each of the weather variables
        }

        public void RandCustomer()
        {
            //Need a for loop to go over the temperature and add a customer to the list for each degree
            //Matt can create a series of names in a list and we can choose from the list randomly for which name we want to use?
            for (int i = 0; i < weather.temperature + 10; i++)
            {
                Customer customer = new Customer();
                customers.Add(customer);
            }
        }

        public void CalcIngredientValues(Player player)
        {
            //Add recipe ingredient values together. Divide total by 20 and * 100 to get a number roughly between 20 and 100
            int calculateTotalIngredients = player.recipeLemons + player.recipeSugarCubes + player.recipeIceCubes;
            calculateTotalIngredients /= 20;
            calculateTotalIngredients *= 20;
        }
    }
}


