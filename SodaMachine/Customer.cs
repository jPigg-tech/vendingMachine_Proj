﻿using System;
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
            List<Coin> digitalHand = new List<Coin>();

            while (selectedCan.Price > digitalHand.Count)
            {
                if ((selectedCan.Price - digitalHand.Count) > .25 )
                {
                    digitalHand.Add(GetCoinFromWallet("Quarter"));
                    return digitalHand;
                }
                else if ((selectedCan.Price - digitalHand.Count) > .10)
                {
                    digitalHand.Add(GetCoinFromWallet("Dime"));
                    return digitalHand;
                }
                else if ((selectedCan.Price - digitalHand.Count) > .05)
                {
                    digitalHand.Add(GetCoinFromWallet("Nickle"));
                    return digitalHand;
                }
                else if ((selectedCan.Price - digitalHand.Count) > .01)
                {
                    digitalHand.Add(GetCoinFromWallet("Penny"));
                    return digitalHand;
                }
                else
                {
                    continue;
                }
            }
            return null;
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
