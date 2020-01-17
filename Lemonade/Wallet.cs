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
<<<<<<< HEAD
        private double money = 1000;
=======
        private double money = 3;

>>>>>>> 7b89d34deb11080164a07bb21a69a4ac364e01c6
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
<<<<<<< HEAD
                
=======
>>>>>>> 7b89d34deb11080164a07bb21a69a4ac364e01c6
            }
        }
    }

}
