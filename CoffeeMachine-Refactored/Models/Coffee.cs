using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{
    public class Coffee : Beverage
    {

        private CoffeeType _coffeeType;
        public CoffeeType CoffeeType { get { return _coffeeType; } set { _coffeeType = value; } }

        public List<CoffeeIngredientsType> Ingredients;


        public Coffee() : base()
        {
            Ingredients = new List<CoffeeIngredientsType>();
        }

        public Coffee(BeverageType beverageType, CoffeeType coffeeType, SizeType size) : base(beverageType, size)
        {
            this.BasePrice = 10;
            this.CoffeeType = coffeeType;
            Ingredients = new List<CoffeeIngredientsType>();
        }

        public override void GetReceipt()
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
                default: throw new CoffeeTypeNotFoundException("We don't have that type of coffee\n");
            }

        }

        public List<CoffeeIngredientsType>? GetNedeedIngredients()
        {
            var neededIngredients = new List<CoffeeIngredientsType>();
            foreach (CoffeeIngredientsType ingredient in Ingredients)
            {
                neededIngredients.Append(ingredient);
            }

            return neededIngredients;
        }

        public override int GetUsedIngredientsNumber()
        {
           
            return this.Ingredients.Count();
        }

        public override double BeveragePrice()
        {
            int numberOfIngredients = GetUsedIngredientsNumber();
            return this.BasePrice + (0.1 * BasePrice * numberOfIngredients * (double)this.SizeType);
        }

        public override string ToString()
        {
            return "Size " + this.SizeType + " coffee Type: " + this.CoffeeType;
        }

    }
}
