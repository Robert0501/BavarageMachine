using CoffeeMachine_Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{
    public abstract class Beverage
    {
        private BeverageType _beverageType;
        public BeverageType BeverageType { get { return _beverageType; } set { _beverageType = value; } }


        private int _basePrice;
        public int BasePrice { get { return _basePrice; } set { _basePrice = value; } }


        private SizeType _size;
        public SizeType SizeType { get { return _size; } set { _size = value; } }

        public CoffeeType CoffeeType { get; internal set; }

       


        public Beverage()
        {
            
        }

        public Beverage(BeverageType beverageType, SizeType size)
        {
            this._beverageType = beverageType;
            this.SizeType = size;
            
        }


        public abstract double BeveragePrice();
       
        public abstract void GetReceipt();

        public abstract int GetUsedIngredientsNumber();



    }
}
