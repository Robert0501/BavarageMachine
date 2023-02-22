using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{
    public class Ingredient
    {
        private readonly int MAX_AMOUNT = 20;

        private int _actualAmount;
        public int ActualAmount { get { return _actualAmount; } set { _actualAmount = value; } }
        public CoffeeIngredientsType CoffeeType;
        public SodaType SodaType;
        public TeaIngredientsType TeaType;

       
        public Ingredient(CoffeeIngredientsType ingredientType)
        {
            ActualAmount = MAX_AMOUNT;
            this.CoffeeType = ingredientType;
        }

        public Ingredient(SodaType sodaType)
        {
            ActualAmount = MAX_AMOUNT;
            this.SodaType = sodaType;
        }

        public Ingredient(TeaIngredientsType teaType)
        {
            ActualAmount = MAX_AMOUNT;
            this.TeaType = teaType;
        }

        public void FillIngredient()
        {
            ActualAmount = MAX_AMOUNT;
        }


    }
}
