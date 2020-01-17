using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Wallet
    {
        //Need to do some stuff with public and private / Get and Set here
        private double money = 3;

        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value <= 0)
                {
                    money = 0;
                }
            }
        }
    }

}
