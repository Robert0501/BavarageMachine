using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Controllers
{
    internal class CoffeeProccessor : IBeverageProcessor
    {
        private List<Ingredient> ingredients;
        private List<IngredientsType> neededIngredientsList;

        private void addAllIngredientsToTheList(List<Ingredient> list)
        {
            foreach (int ingredients in Enum.GetValues(typeof(IngredientsType)))
            {
                list.Add(new Ingredient((IngredientsType)ingredients));
            }

        }

        public CoffeeProccessor()
        {
            ingredients = new List<Ingredient>();
            neededIngredientsList = new List<IngredientsType>();

            addAllIngredientsToTheList(ingredients);
        }

        private void ClearList(List<IngredientsType> list)
        {
            list.Clear();
        }

        private void GetReceipt(CoffeeType coffee)
        {
            ClearList(neededIngredientsList);
            switch (coffee)
            {
                case CoffeeType.HotChocolate:
                    neededIngredientsList.Add(IngredientsType.Cocoa);
                    neededIngredientsList.Add(IngredientsType.Milk);
                    break;
                case CoffeeType.Espresso:
                    neededIngredientsList.Add(IngredientsType.Coffee);
                    neededIngredientsList.Add(IngredientsType.Water);
                    break;
                case CoffeeType.IrishCoffee:
                    neededIngredientsList.Add(IngredientsType.Cocoa);
                    neededIngredientsList.Add(IngredientsType.Milk);
                    neededIngredientsList.Add(IngredientsType.Coffee);
                    neededIngredientsList.Add(IngredientsType.Sugar);
                    break;
                default: throw new CoffeeTypeNotFoundException("We don't have that type of coffee\n");
            }
        }

        private void CheckForIngredients(Ingredient ingredient, SizeList size)
        {
            switch (size)
            {
                case SizeList.Small:
                    if (ingredient.ActualAmount < 1)
                    {
                        throw new IngredientNotFoundException(ingredient.IngredientType.ToString(), size.ToString().ToLower());
                    }
                    break;
                case SizeList.Medium:
                    if (ingredient.ActualAmount < 2)
                    {
                        throw new IngredientNotFoundException(ingredient.IngredientType.ToString(), size.ToString().ToLower());
                    }
                    break;
                case SizeList.Large:
                    if (ingredient.ActualAmount < 3)
                    {
                        throw new IngredientNotFoundException(ingredient.IngredientType.ToString(), size.ToString().ToLower());
                    }
                    break;
            }
        }

        private void UpdateIngredientAmount(Ingredient ingredient, SizeList size)
        {
            CheckForIngredients(ingredient, size);
            switch (size)
            {
                case SizeList.Small: ingredient.ActualAmount -= 1; break;
                case SizeList.Medium: ingredient.ActualAmount -= 2; break;
                case SizeList.Large: ingredient.ActualAmount -= 3; break;
                default: throw new SizeNotFoundException("We don't have that size\n");
            }
        }

        private int GetIngredientsNumber()
        {
            return neededIngredientsList.Count();
        }

        public double GetPrice(CoffeeType coffeeType, SizeList size)
        {
            GetReceipt(coffeeType);
            int nrOfIngredients = GetIngredientsNumber();
            
            var coffee = new Coffee();
            return coffee.Price(size, nrOfIngredients);
        }

        public void MakeBeverage(CoffeeType coffeeType, SizeList size)
        {
            foreach (IngredientsType ingredientNeeded in neededIngredientsList)
            {
                int index = ingredients.FindIndex(x => x.IngredientType.Equals(ingredientNeeded));
                UpdateIngredientAmount(ingredients[index], size);
            }


        }
    }
}
