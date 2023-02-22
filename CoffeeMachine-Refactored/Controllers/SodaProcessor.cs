using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Controllers
{
    public class SodaProcessor : IBeverageProcessor
    {
        private List<Ingredient> ingredients;
        private Soda? soda;

        private void addAllIngredientsToTheList(List<Ingredient> list)
        {
            foreach (int ingredients in Enum.GetValues(typeof(SodaType)))
            {
                list.Add(new Ingredient((SodaType)ingredients));

            }
        }

        public SodaProcessor()
        {
            ingredients= new List<Ingredient>();

            addAllIngredientsToTheList(ingredients);
        }

        public void AskForBeverage()
        {
            Console.WriteLine("Please insert the number of the soda you want:\n" +
              "1.Coca Cola\n" +
              "2.Pepsi\n" +
              "3.Fanta\n" +
              "4.Sprite");

            var sodaType = SodaType.CocaCola;
            if (int.TryParse(Console.ReadLine(), out var sodaChoise))
            {

                sodaType = (SodaType)sodaChoise;

            }


            Console.WriteLine("You choose a " + sodaType.ToString() + " Would you like it to be:" +
                                        "\n1. Small" +
                                        "\n2. Medium" +
                                        "\n3. Large");

            var size = SizeType.Small;
            if (int.TryParse(Console.ReadLine(), out var sizeChoose))
            {
                size = (SizeType)sizeChoose;
            }

            soda = new Soda(sodaType, size);
        }

        private void CheckForIngredients(Ingredient ingredient, SizeType size)
        {
            switch (size)
            {
                case SizeType.Small:
                    if (ingredient.ActualAmount < 1)
                    {
                        throw new IngredientNotFoundException(ingredient.IngredientType.ToString(), size.ToString().ToLower());
                    }
                    break;
                case SizeType.Medium:
                    if (ingredient.ActualAmount < 2)
                    {
                        throw new IngredientNotFoundException(ingredient.IngredientType.ToString(), size.ToString().ToLower());
                    }
                    break;
                case SizeType.Large:
                    if (ingredient.ActualAmount < 3)
                    {
                        throw new IngredientNotFoundException(ingredient.IngredientType.ToString(), size.ToString().ToLower());
                    }
                    break;
            }
        }
        private void UpdateIngredientAmount(Ingredient ingredient, SizeType size)
        {

            CheckForIngredients(ingredient, size);
            switch (size)
            {
                case SizeType.Small: ingredient.ActualAmount -= 1; break;
                case SizeType.Medium: ingredient.ActualAmount -= 2; break;
                case SizeType.Large: ingredient.ActualAmount -= 3; break;
                default: throw new SizeNotFoundException("We don't have that size\n");
            }
        }

        public void GetReceipt()
        {
            soda.GetReceipt();
        }

        public void AskForPayment()
        {
            double price = GetPrice();

            double paidAmount = 0;

            Console.Write("Your " + soda.SizeType + "  " + soda.SodaType + " will be " + price + " lei. Please insert the amount: ");

            do
            {
                paidAmount += double.Parse(Console.ReadLine());
                if (paidAmount < price)
                {
                    Console.WriteLine("You have to pay " + (price - paidAmount) + " more");
                    paidAmount += double.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Your change is " + (paidAmount - price));
                }

            } while (price > paidAmount);
        }

        public double GetPrice()
        {
            return soda.BeveragePrice();
        }

        public void Pour()
        {
            UpdateIngredientAmount(ingredients[0], soda.SizeType);
            
        }
    }
}
