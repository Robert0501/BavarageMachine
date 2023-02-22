using CoffeeMachine_Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Interfaces
{
    public interface IBeverage
    {

        public int BasePrice { get; set; }

        public SizeType SizeType { get; set; }


        public abstract double BeveragePrice();

        public abstract void GetReceipt();

        public abstract int GetUsedIngredientsNumber();



    }
}
