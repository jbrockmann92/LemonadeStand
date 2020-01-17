using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Customer
    {
        public string name;
        public int chanceToBuy;
        public List<Customer> customers = new List<Customer>() { };

        public void ChanceToBuy(Customer customer)
        {
            Random rng = new Random();
            int randomNumber = rng.Next(100);
        }
    }
}
