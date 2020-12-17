using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        //Member Variables (Has A)
        private List<Coin> _register;
        private List<Can> _inventory;

        //Constructor (Spawner)
        public SodaMachine()
        {
            _register = new List<Coin>();
            _inventory = new List<Can>();

            Quarter quarter = new Quarter();
            Dime dime = new Dime();
            Nickel nickle = new Nickel();
            Penny penny = new Penny();

            FillRegister(quarter, 20);
            FillRegister(dime, 10);
            FillRegister(nickle, 20);
            FillRegister(penny, 50);

            RootBeer rootBeer = new RootBeer();
            Cola cola = new Cola();
            OrangeSoda orangeSoda = new OrangeSoda();

            FillInventory(rootBeer, 10);
            FillInventory(cola, 10);
            FillInventory(orangeSoda, 10);

        }

        //Member Methods (Can Do)

        //A method to fill the sodamachines register with coin objects.
        public void FillRegister(Coin coin, int startingUnits)
        {
            _register.AddRange(Enumerable.Repeat(coin, startingUnits));
            
        }
        //A method to fill the sodamachines inventory with soda can objects.
        public void FillInventory(Can can, int startingUnits)
        {
            _inventory.AddRange(Enumerable.Repeat(can, startingUnits));
            
        }
        //Method to be called to start a transaction.
        //Takes in a customer which can be passed freely to which ever method needs it.
        public void BeginTransaction(Customer customer)
        {
            bool willProceed = UserInterface.DisplayWelcomeInstructions(_inventory);
            if (willProceed)
            {
                Transaction(customer);
            }
        }
        
        //This is the main transaction logic think of it like "runGame". This is where the user will be prompted for the desired soda.
        //grab the desired soda from the inventory.
        //get payment from the user.
        //pass payment to the calculate transaction method to finish up the transaction based on the results.
        private void Transaction(Customer customer)
        {
            GetSodaFromInventory(UserInterface.SodaSelection(_inventory));

        }
        //Gets a soda from the inventory based on the name of the soda.
        private Can GetSodaFromInventory(string nameOfSoda)
        {

            for (int i = 0; i < _inventory.Count; i++)
            {
                if (nameOfSoda == _inventory[i].Name)
                {                 
                    _inventory.Remove(_inventory[i]);
                    return _inventory[i];                   
                }
                else 
                {
                    continue;
                }               
            }
            return null;
        }

        //This is the main method for calculating the result of the transaction.
        //It takes in the payment from the customer, the soda object they selected, and the customer who is purchasing the soda.
        //This is the method that will determine the following:
        //If the payment is greater than the price of the soda, and if the sodamachine has enough change to return: Dispense soda, and change to the customer.
        //If the payment is greater than the cost of the soda, but the machine does not have ample change: Dispense payment back to the customer.
        //If the payment is exact to the cost of the soda:  Dispense soda.
        //If the payment does not meet the cost of the soda: dispense payment back to the customer.
        private void CalculateTransaction(List<Coin> payment, Can chosenSoda, Customer customer)
        {
            double determinedChange = DetermineChange(TotalCoinValue(payment), chosenSoda.Price);

            customer.GatherCoinsFromWallet(chosenSoda);
            DepositCoinsIntoRegister(payment);

            if (TotalCoinValue(payment) > chosenSoda.Price && TotalCoinValue(_register) >= determinedChange)
            {               
                GetSodaFromInventory(chosenSoda.Name);
                customer.AddCanToBackpack(chosenSoda);
                GatherChange(determinedChange);
                customer.AddCoinsIntoWallet(GatherChange(determinedChange));
            }
            else if (TotalCoinValue(payment) > chosenSoda.Price && TotalCoinValue(_register) < determinedChange)
            {
                GatherChange(DetermineChange(TotalCoinValue(payment), 0));
                customer.AddCoinsIntoWallet(GatherChange(determinedChange));
            }
            else if (TotalCoinValue(payment) == chosenSoda.Price)
            {
                GetSodaFromInventory(chosenSoda.Name);
                customer.AddCanToBackpack(chosenSoda);
            }
            else if(TotalCoinValue(payment) != chosenSoda.Price)
            {
                GatherChange(DetermineChange(TotalCoinValue(payment), 0));
                customer.AddCoinsIntoWallet(GatherChange(determinedChange));
            }
        }
        //Takes in the value of the amount of change needed.
        //Attempts to gather all the required coins from the sodamachine's register to make change.
        //Returns the list of coins as change to despense.
        //If the change cannot be made, return null.
        private List<Coin> GatherChange(double changeValue)
        {
            double valueOfCoinsRemovedFromRegister = 0;
            List<Coin> coinsUsedForChange = new List<Coin>();

            foreach (Coin coin in coinsUsedForChange)
            {
                while (changeValue > valueOfCoinsRemovedFromRegister)
                {
                    if ((changeValue - valueOfCoinsRemovedFromRegister) > .25 && RegisterHasCoin("Quarter"))
                    {
                        valueOfCoinsRemovedFromRegister += .25;
                        coinsUsedForChange.Add(GetCoinFromRegister("Quarter"));
                        return coinsUsedForChange;
                    }
                    else if ((changeValue - valueOfCoinsRemovedFromRegister) > .10 && RegisterHasCoin("Dime"))
                    {
                        valueOfCoinsRemovedFromRegister += .10;
                        coinsUsedForChange.Add(GetCoinFromRegister("Dime"));
                        return coinsUsedForChange;
                    }
                    else if ((changeValue - valueOfCoinsRemovedFromRegister) > .05 && RegisterHasCoin("Nickle"))
                    {
                        valueOfCoinsRemovedFromRegister += .05;
                        coinsUsedForChange.Add(GetCoinFromRegister("Nickle"));
                        return coinsUsedForChange;
                    }
                    else if ((changeValue - valueOfCoinsRemovedFromRegister) > .01 && RegisterHasCoin("Penny"))
                    {
                        valueOfCoinsRemovedFromRegister += .01;
                        coinsUsedForChange.Add(GetCoinFromRegister("Penny"));
                        return coinsUsedForChange;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return null;         
        }
        //Reusable method to check if the register has a coin of that name.
        //If it does have one, return true.  Else, false.
        private bool RegisterHasCoin(string name)
        {
            for (int i = 0; i < _register.Count; i++)
            {
                if (name == _register[i].Name)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
        //Reusable method to return a coin from the register.
        //Returns null if no coin can be found of that name.
        private Coin GetCoinFromRegister(string name)
        {
            for (int i = 0; i < _register.Count; i++)           
            {
                if (name == _register[i].Name)
                {
                    _register.Remove(_register[i]);
                    return _register[i];                   
                }
                else
                {
                    continue;
                }
            }
            return null;
        }
        //Takes in the total payment amount and the price of can to return the change amount.
        private double DetermineChange(double totalPayment, double canPrice)
        {
            double changeDetermined = totalPayment - canPrice;
            return changeDetermined;
        }
        //Takes in a list of coins to return the total value of the coins as a double.
        private double TotalCoinValue(List<Coin> payment)
        {
            double coinValueTotal = 0;
            foreach (Coin coin in payment)
            {
                coinValueTotal += coin.Value;              
            }
            return coinValueTotal;
        }
        //Puts a list of coins into the soda machines register.
        private void DepositCoinsIntoRegister(List<Coin> coins)
        {
            foreach (Coin coin in coins)
            {
                _register.Add(coin);
            } 
        }
    }
}
