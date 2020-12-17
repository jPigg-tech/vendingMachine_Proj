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
            double valueOfCoinsRemovedFromWallet = 0;
            List<Coin> digitalHand = new List<Coin>();

            while (selectedCan.Price > valueOfCoinsRemovedFromWallet)
            {
                if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .25 )
                {
                    valueOfCoinsRemovedFromWallet += .25;
                    digitalHand.Add(GetCoinFromWallet("Quarter"));
                }
                else if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .10)
                {
                    valueOfCoinsRemovedFromWallet += .10;
                    digitalHand.Add(GetCoinFromWallet("Dime"));
                }
                else if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .05)
                {
                    valueOfCoinsRemovedFromWallet += .05;
                    digitalHand.Add(GetCoinFromWallet("Nickle"));
                }
                else if ((selectedCan.Price - valueOfCoinsRemovedFromWallet) > .01)
                {
                    valueOfCoinsRemovedFromWallet += .01;
                    digitalHand.Add(GetCoinFromWallet("Penny"));
                }
                else
                {
                    return null;
                }
            }
            return digitalHand;
        }
        //Returns a coin object from the wallet based on the name passed into it.
        //Returns null if no coin can be found
        public Coin GetCoinFromWallet(string coinName)
        {           
            for (int i = 0; i < Wallet.Coins.Count; i++)
            {
                if (coinName == Wallet.Coins[i].Name)
                {
                    Wallet.Coins.Remove(Wallet.Coins[i]);
                    return Wallet.Coins[i];
                }
                else
                {
                    continue;
                }
            }
            return null;
                
        }
        //Takes in a list of coin objects to add into the customers wallet.
        public void AddCoinsIntoWallet(List<Coin> coinsToAdd)
        {
            foreach (Coin coin in coinsToAdd)
            {
                Wallet.Coins.Add(coin);
            }
        }
        //Takes in a can object to add to the customers backpack.
        public void AddCanToBackpack(Can purchasedCan)
        { 
            Backpack.cans.Add(purchasedCan);
        }
    }
}
