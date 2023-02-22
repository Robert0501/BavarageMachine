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
        IMachineProcessor _coffeeProccessor;
        IMachineProcessor _sodaProccessor;

        public BeverageMachine(IMachineProcessor beverageProcessor, IMachineProcessor sodaProccessor)
        {
            _coffeeProccessor = beverageProcessor;
            _sodaProccessor = sodaProccessor;
        }

        public BeverageMachine()
        {
            _coffeeProccessor = new BeverageProccessor(BeverageType.Coffee);
            _sodaProccessor = new BeverageProccessor(BeverageType.Soda);
        }

        public void PourCoffee()
        {


            _coffeeProccessor.PourBeverage(BeverageType.Coffee);

        }

        public void PourSoda()
        {
            _sodaProccessor.PourBeverage(BeverageType.Soda);
        }

    }
}
