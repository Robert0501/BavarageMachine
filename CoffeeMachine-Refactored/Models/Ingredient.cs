using CoffeeMachine_Refactored.Enums;
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
        public CoffeeIngredientsType IngredientType;
        public SodaType sodaType;

        public Ingredient(CoffeeIngredientsType ingredientType)
        {
            ActualAmount = MAX_AMOUNT;
            this.IngredientType = ingredientType;
        }

        public Ingredient(SodaType sodaType)
        {
            ActualAmount = MAX_AMOUNT;
            this.sodaType = sodaType;
        }

        public void FillIngredient()
        {
            ActualAmount= MAX_AMOUNT;
        }

       
    }
}
