using CoffeeMachine_Refactored.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{
    internal class Ingredient
    {
        private readonly int MAX_AMOUNT = 20;

        private int _actualAmount;
        public int ActualAmount { get { return _actualAmount; } set { _actualAmount = value; } }
        public IngredientsType IngredientType;

        public Ingredient(IngredientsType ingredientType)
        {
            ActualAmount = MAX_AMOUNT;
            this.IngredientType = ingredientType;
        }

        public void FillIngredient()
        {
            ActualAmount= MAX_AMOUNT;
        }

       
    }
}
