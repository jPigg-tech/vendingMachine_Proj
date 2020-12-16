using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Customer
    {
        //Member Variables (Has A)
        public Wallet Wallet;
        public Backpack Backpack;

        //Constructor (Spawner)
        public Customer()
        {
            Wallet = new Wallet();
            Backpack = new Backpack();
        }
        //Member Methods (Can Do)

        //This method will be the main logic for a customer to retrieve coins form their wallet.
        //Takes in the selected can for price reference
        //Will need to get user input for coins they would like to add.
        //When all is said and done this method will return a list of coin objects that the customer will use as payment for their soda.
        public List<Coin> GatherCoinsFromWallet(Can selectedCan)
        {
            //what do we need to compare the price of the can to?
            double valueOfCoinsRemovedFromWallet = 0;
            List<Coin> digitalHand = new List<Coin>();

            while (selectedCan.Price > valueOfCoinsRemovedFromWallet)
            {
                if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .25 )
                {
                    
                }
                else if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .10)
                {

                }
                else if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .05)
                {

                }
                else if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .01)
                {

                }
                else
                {

                }
            }
        }
        //Returns a coin object from the wallet based on the name passed into it.
        //Returns null if no coin can be found
        public Coin GetCoinFromWallet(string coinName)
        {
            Coin coin = new Coin();
            for (int i = 0; i < Wallet.Coins.Count; i++)
            {
                if (coinName == Wallet.Coins[i].Name)
                {
                    coin = Wallet.Coins[i];
                }
                else
                {
                    return null;
                }
            }
            return coin;
                
        }
        //Takes in a list of coin objects to add into the customers wallet.
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {
            Wallet wallet = new Wallet();
            //wallet.Coins.AddRange(coinsToAdd);

            foreach (Coin coin in coinsToAdd)
            {
                wallet.Coins.Add(coin);
            }
        }
        //Takes in a can object to add to the customers backpack.
        public void AddCanToBackpack(Can purchasedCan)
        {
            Backpack backpack = new Backpack();
            backpack.cans.Add(purchasedCan);
        }
    }
}
