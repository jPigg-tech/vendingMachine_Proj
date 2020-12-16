using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
            Quarter quarter = new Quarter();
            int twenty = 20;
            void FillRegister(Coin coin, int startingUnits)
            {
                sodaMachine._register.AddRange(Enumerable.Repeat(coin, startingUnits));

            }
            FillRegister(quarter, twenty);
            //Simulation simulation = new Simulation();
            //simulation.Simulate();
        }
    }
}
