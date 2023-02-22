using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Interfaces;
using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Controllers
{
    public class BeverageProccessor : IMachineProcessor
    {
        private readonly CoffeeProccessor? coffeeProccessor;

        public BeverageProccessor()
        {

        }

        public BeverageProccessor(BeverageType beverageType)
        {

            switch (beverageType)
            {
                case BeverageType.Coffee:
                    coffeeProccessor = new CoffeeProccessor();
                    break;
            }
        }

        public void PourBeverage(BeverageType beverageType)
        {
            switch (beverageType)
            {
                case BeverageType.Coffee:
                    coffeeProccessor.AskForBeverage();
                    coffeeProccessor.GetReceipt();
                    coffeeProccessor.AskForPayment();
                    coffeeProccessor.Pour();
                    coffeeProccessor.showActualIngredientAmount();
                    break;
            }
        }
    }
}
