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
    public class Coffee : IBeverage
    {

        private CoffeeType _coffeeType;
        public CoffeeType CoffeeType { get { return _coffeeType; } set { _coffeeType = value; } }

        private SizeType _sizeType;
        public SizeType SizeType { get { return _sizeType; } set { _sizeType = value; } }

        private int _basePrice;
        public int BasePrice { get { return _basePrice; } set { _basePrice = value; } }

        public List<CoffeeIngredientsType> Ingredients;


        public Coffee()
        {
            Ingredients = new List<CoffeeIngredientsType>();
        }

        public Coffee(CoffeeType coffeeType, SizeType size)
        {
            this.BasePrice = 10;
            this.CoffeeType = coffeeType;
            this.SizeType = size;
            Ingredients = new List<CoffeeIngredientsType>();
        }

        public double BeveragePrice()
        {
            int numberOfIngredients = GetUsedIngredientsNumber();
            return this.BasePrice + (0.1 * BasePrice * numberOfIngredients * (double)this.SizeType);
        }

        public void GetReceipt()
        {
            switch (CoffeeType)
            {
                case CoffeeType.HotChocolate:

                    this.Ingredients.Add(CoffeeIngredientsType.Coffee);
                    this.Ingredients.Add(CoffeeIngredientsType.Milk);

                    break;
                case CoffeeType.Espresso:
                    this.Ingredients.Add(CoffeeIngredientsType.Coffee);
                    this.Ingredients.Add(CoffeeIngredientsType.Water);
                    break;
                case CoffeeType.IrishCoffee:
                    this.Ingredients.Add(CoffeeIngredientsType.Cocoa);
                    this.Ingredients.Add(CoffeeIngredientsType.Milk);
                    this.Ingredients.Add(CoffeeIngredientsType.Coffee);
                    this.Ingredients.Add(CoffeeIngredientsType.Sugar);
                    break;
                default: throw new BeverageTypeNotFoundException("We don't have that type of coffee\n");
            }

        }

        public List<CoffeeIngredientsType>? GetNedeedIngredients()
        {
            var neededIngredients = new List<CoffeeIngredientsType>();
            foreach (CoffeeIngredientsType ingredient in Ingredients)
            {
                neededIngredients.Add(ingredient);
            }

            return neededIngredients;
        }

        public int GetUsedIngredientsNumber()
        {

            return this.Ingredients.Count();
        }



        public override string ToString()
        {
            return "Size " + this.SizeType + " coffee Type: " + this.CoffeeType;
        }

    }
}
