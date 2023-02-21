using CoffeeMachine_Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Interfaces
{
    public interface IBeverageProcessor
    {
        void MakeBeverage(CoffeeType coffeeType, SizeList size);
        double GetPrice(CoffeeType coffeeType, SizeList size);
    }
}
