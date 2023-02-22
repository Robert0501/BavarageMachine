using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{
    public class Soda : IBeverage
    {
        private SodaType _sodaType;
        public SodaType SodaType { get { return _sodaType; } set { _sodaType = value; } }

        private int _basePrice;
        public int BasePrice { get { return _basePrice; } set { _basePrice = value; } }

        private SizeType _sizeType;
        public SizeType SizeType { get { return _sizeType; } set { _sizeType = value; } }

        public List<SodaType> Ingredients;
        public Soda()
        {
            Ingredients = new List<SodaType>();
        }

        public Soda(SodaType sodaType, SizeType size)
        {
            this.BasePrice = 5;
            _sodaType = sodaType;
            _sizeType = size;
            Ingredients = new List<SodaType>();
        }

        public double BeveragePrice()
        {
            return BasePrice + (0.2 * _basePrice * (double)SizeType);
        }

        public void GetReceipt()
        {
            switch (SodaType)
            {
                case SodaType.CocaCola:
                    this.Ingredients.Add(SodaType.CocaCola); break;
                case SodaType.Pepsi:
                    this.Ingredients.Add(SodaType.Pepsi); break;
                case SodaType.Fanta:
                    this.Ingredients.Add(SodaType.Fanta); break;
                case SodaType.Sprite:
                    this.Ingredients.Add(SodaType.Sprite); break;
                default: throw new BeverageTypeNotFoundException("We don't have that type of soda");
            }
        }

        public List<SodaType>? GetNedeedIngredients()
        {
            var neededIngredients = new List<SodaType>();
            foreach (SodaType ingredient in Ingredients)
            {
                neededIngredients.Append(ingredient);
            }

            return neededIngredients;
        }

        public int GetUsedIngredientsNumber()
        {
            return 1;
        }
    }
}
