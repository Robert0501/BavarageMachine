using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Interfaces
{
    public interface IMachineProcessor
    {
        void PourBeverage(BeverageType beverageType);
    }
}
