using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade
{
    class Inventory
    {
        public List<Lemon> lemons = new List<Lemon>() { new Lemon() };
        public List<IceCube> iceCubes = new List<IceCube>();
        public List<Cup> cups = new List<Cup>();
        public List<SugarCube> sugarCubes = new List<SugarCube>();
    }
}
