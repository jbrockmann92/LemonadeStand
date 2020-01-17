using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Weather
    {
        public string condition;
        public int temperature;
        public List<string> weatherConditions = new List<string>() { "Sunny", "Mostly Sunny", "Hazy", "Cloudy", "Rainy" };
        public string predictedForecast;

        //Still need to assign values, 40-100 or so, to the weather conditions
    }
}
