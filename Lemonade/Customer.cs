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

        public Customer()
        {

        }
        public void Buy()
        {
            Console.WriteLine("{0} bought lemonade", name);
        }
    }
}
