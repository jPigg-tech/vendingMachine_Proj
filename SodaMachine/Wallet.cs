using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Wallet
    {
        //Member Variables (Has A)
        public List<Coin> Coins;
        //Constructor (Spawner)
        public Wallet()
        {
            Coins = new List<Coin>();

            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickle = new Nickel();
            Penny penny = new Penny();

            FillRegister(quarter, 12);
            FillRegister(dime, 10);
            FillRegister(nickle, 20);
            FillRegister(penny, 25);

            // FillRegister();
        }
        //Member Methods (Can Do)
        //Fills wallet with starting money
        private void FillRegister(Coin coin, int startingUnits)
        {
            Coins.AddRange(Enumerable.Repeat(coin, startingUnits));
        }
    }
}
