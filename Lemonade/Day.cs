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
            RandTemperature();
            RandCustomer();
        }

        public void RandCondition()
        {
            Random random = new Random();
            
            weather.predictedForecast = weather.weatherConditions[random.Next(5)];
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

        //Added RandTempterature() in line with Open/Closed Prinicple, rather than adding it to the RandCondition() function
        public void RandTemperature()
        {
            Random rnd = new Random();
            weather.temperature = rnd.Next(30, 105);
        }

        public void RandCustomer()
        {
            for (int i = 0; i < (weather.temperature + (weather.temperature / 7)); i++)
                //Change number weather.temperature is divided by here to weight weather more heavily in the equation. Will create more customers.
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
            weatherBuyValue += calculateTotalIngredients;
        }
    }
}


