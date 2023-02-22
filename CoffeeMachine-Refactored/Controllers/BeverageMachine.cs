using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Controllers
{
    public class BeverageMachine
    {
        IBeverageProcessor _beverageProcessor;
  

        public BeverageMachine(IBeverageProcessor beverageProcessor)
        {
            _beverageProcessor = beverageProcessor;
           
        }

        public BeverageMachine()
        {
            _beverageProcessor = new BeverageProccessor();
        }

        public void Pour()
        {
            _beverageProcessor.AskForBeverage();
            _beverageProcessor.GetReceipt();
            _beverageProcessor.AskForPayment();
            _beverageProcessor.Pour();
            _beverageProcessor.showActualIngredientAmount();

        }

        

    }
}
