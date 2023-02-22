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
    public class CoffeeMachine
    {
        IMachineProcessor _beverageProccessor;

        public CoffeeMachine(IMachineProcessor beverageProcessor)
        {
            _beverageProccessor = beverageProcessor;
        }

        public CoffeeMachine()
        {
            _beverageProccessor = new BeverageProccessor(BeverageType.Coffee);
        }

        public void PourCoffee()
        {


            _beverageProccessor.PourBeverage(BeverageType.Coffee);

        }

    }
}
