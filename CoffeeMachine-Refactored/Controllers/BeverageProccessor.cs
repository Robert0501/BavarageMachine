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
    public class BeverageProccessor : IBeverageProcessor
    {
        private List<Ingredient> CoffeeIngredients;
        private Coffee? coffee;

        private List<Ingredient> SodaIngredients;
        private Soda? soda;

        private int userOption = 0;


        private void addAllIngredientsToTheList(List<Ingredient> list)
        {

            foreach (int ingredients in Enum.GetValues(typeof(CoffeeIngredientsType)))
            {
                list.Add(new Ingredient((CoffeeIngredientsType)ingredients));

            }

            foreach (int ingredients in Enum.GetValues(typeof(SodaType)))
            {
                list.Add(new Ingredient((CoffeeIngredientsType)ingredients));

            }
        }

        public BeverageProccessor()
        {
            CoffeeIngredients = new List<Ingredient>();
            SodaIngredients = new List<Ingredient>();

            addAllIngredientsToTheList(CoffeeIngredients);
        }

        public void showActualIngredientAmount()
        {
            foreach (Ingredient i in CoffeeIngredients)
            {
                Console.WriteLine(i.ActualAmount);
            }
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

        public void AskForBeverage()
        {
            Console.WriteLine("What drink would you like?\n" +
                "1. Coffee\n" +
                "2. Soda");

            userOption = int.Parse(Console.ReadLine());

            string askForCoffee = "Please insert the number of the coffee you want:\n" +
               "1.Hot Chocolate\n" +
               "2.Espresso\n" +
               "3.Irish Coffee";

            string askForSoda = "Please insert the number of the soda you want:\n" +
              "1.Coca Cola\n" +
              "2.Pepsi\n" +
              "3.Fanta\n" +
              "4.Sprite";

            var coffeeType = CoffeeType.Espresso;
            var sodaType = SodaType.Fanta;

            switch (userOption)
            {
                case 1:
                    Console.WriteLine(askForCoffee);
                    if (int.TryParse(Console.ReadLine(), out var coffeChoise))
                    {

                        coffeeType = (CoffeeType)coffeChoise;

                    }
                    break;
                case 2:
                    Console.WriteLine(askForSoda);
                    if (int.TryParse(Console.ReadLine(), out var sodaChoise))
                    {

                        coffeeType = (CoffeeType)sodaChoise;

                    }
                    break;
            }


            Console.WriteLine("Would you like your drink to be:" +
                                        "\n1. Small" +
                                        "\n2. Medium" +
                                        "\n3. Large");

            var size = SizeType.Small;
            if (int.TryParse(Console.ReadLine(), out var sizeChoose))
            {
                size = (SizeType)sizeChoose;
            }

            switch (userOption)
            {
                case 1: coffee = new Coffee(coffeeType, size); break;
                case 2: soda = new Soda(sodaType, size); break;
            }


        }

        public void GetReceipt()
        {
            switch (userOption)
            {
                case 1: coffee.GetReceipt(); break;
                case 2: soda.GetReceipt(); break;
            }

        }

        public void AskForPayment()
        {
            double price = GetPrice();

            double paidAmount = 0;

            switch (userOption)
            {
                case 1:
                    Console.Write("Your " + coffee.SizeType + "  " + coffee.CoffeeType + " will be " + price + " lei. Please insert the amount: ");
                    break;
                case 2:
                    Console.Write("Your " + soda.SizeType + "  " + soda.SodaType + " will be " + price + " lei. Please insert the amount: ");
                    break;
            }

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
            switch (userOption)
            {
                case 1: return coffee.BeveragePrice(); break;
                case 2: return soda.BeveragePrice(); break;
            }

            return 0;

        }

        public void Pour()
        {
            switch (userOption)
            {
                case 1:
                    foreach (CoffeeIngredientsType ingredientNeeded in coffee.Ingredients)
                    {
                        int index = CoffeeIngredients.FindIndex(x => x.IngredientType.Equals(ingredientNeeded));
                        UpdateIngredientAmount(CoffeeIngredients[index], coffee.SizeType);
                    }
                    break;
                case 2:
                    UpdateIngredientAmount(CoffeeIngredients[0], coffee.SizeType);
                    break;
            }



        }
    }
}
