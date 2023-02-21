using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{
    public class Coffee
    {
        private readonly int BASE_PRICE = 10;


        public Coffee()
        {

        }

        public double Price(SizeList size, int ingredientsNumber)
        {
            switch (size)
            {
                case SizeList.Small: return BASE_PRICE + (ingredientsNumber * 0.2 * BASE_PRICE);
                case SizeList.Medium: return BASE_PRICE + (2 * ingredientsNumber * 0.2 * BASE_PRICE);
                case SizeList.Large: return BASE_PRICE + (3 * ingredientsNumber * 0.2 * BASE_PRICE);
                default: return 0;
            }

        }
    }
}
