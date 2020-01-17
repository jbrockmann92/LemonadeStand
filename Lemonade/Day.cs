using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Day
    {
        public Weather weather = new Weather();
        public List<Customer> customers = new List<Customer>();
        public int weatherBuyValue;
        public Customer customer = new Customer();

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
            if (weather.predictedForecast == "Sunny")
            {
                weatherBuyValue = 100;
            }
            else if (weather.predictedForecast == "Mostly Sunny")
            {
                weatherBuyValue = 80;
            }
            else if (weather.predictedForecast == "Hazy")
            {
                weatherBuyValue = 60;
            }
            else if (weather.predictedForecast == "Cloudy")
            {
                weatherBuyValue = 40;
            }
            else if (weather.predictedForecast == "Rainy")
            {
                weatherBuyValue = 20;
            }
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
            weatherBuyValue += customers.Count;
        }

        public void CalcIngredientValues(Player player)
        {
            //Add recipe ingredient values together. Divide total by 20 and * 100 to get a number roughly between 20 and 100
            int calculateTotalIngredients = player.recipe.amountOfLemons + player.recipe.amountOfSugarCubes + player.recipe.amountOfIceCubes;
            calculateTotalIngredients /= 2;
            //Trying to get this to play with Game class to Buy function that will add cups to the list of Cups there
            weatherBuyValue += calculateTotalIngredients;
        }
    }
}


