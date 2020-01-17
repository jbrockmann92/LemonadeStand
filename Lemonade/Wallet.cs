using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Wallet
    {
        private double money = 100;
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
                if (value <= 0)
                {
                    money = 0;
                }
            }
        }
    }

}
