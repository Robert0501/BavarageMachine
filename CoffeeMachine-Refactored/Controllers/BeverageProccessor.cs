
using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        private List<Ingredient> TeaIngredients;
        private Tea? tea;

        private int userOption = 0;


        private void addAllIngredientsToTheList(BeverageType type, List<Ingredient> list)
        {
            switch (type)
            {
                case BeverageType.Coffee:
                    foreach (int ingredients in Enum.GetValues(typeof(CoffeeIngredientsType)))
                    {
                        list.Add(new Ingredient((CoffeeIngredientsType)ingredients));

                    }
                    break;
                case BeverageType.Soda:
                    foreach (int ingredients in Enum.GetValues(typeof(SodaType)))
                    {
                        list.Add(new Ingredient((SodaType)ingredients));

                    }
                    break;
                case BeverageType.Tea:
                    foreach (int ingredients in Enum.GetValues(typeof(TeaIngredientsType)))
                    {
                        list.Add(new Ingredient((TeaIngredientsType)ingredients));

                    }
                    break;
            }



        }

        public BeverageProccessor()
        {
            CoffeeIngredients = new List<Ingredient>();
            SodaIngredients = new List<Ingredient>();
            TeaIngredients = new List<Ingredient>();

            addAllIngredientsToTheList(BeverageType.Coffee, CoffeeIngredients);
            addAllIngredientsToTheList(BeverageType.Soda, SodaIngredients);
            addAllIngredientsToTheList(BeverageType.Tea, TeaIngredients);
        }

        public void showActualIngredientAmount()
        {
            switch (userOption)
            {
                case 1:
                    foreach (Ingredient i in CoffeeIngredients)
                    {
                        Console.WriteLine(i.CoffeeType + " " + i.ActualAmount);
                    }
                    break;
                case 2:
                    foreach (Ingredient i in SodaIngredients)
                    {
                        Console.WriteLine(i.SodaType + " " + i.ActualAmount);
                    }
                    break;
                case 3:
                    foreach (Ingredient i in TeaIngredients)
                    {
                        Console.WriteLine(i.TeaType + " " + i.ActualAmount);
                    }
                    break;

            }

        }

        private void ThrowErrorIfTheIngredientIsNotFound(Ingredient ingredient, SizeType size)
        {
            switch (userOption)
            {
                case 1: throw new IngredientNotFoundException(ingredient.CoffeeType.ToString(), size.ToString().ToLower());
                case 2: throw new IngredientNotFoundException(ingredient.SodaType.ToString(), size.ToString().ToLower());
                case 3: throw new IngredientNotFoundException(ingredient.TeaType.ToString(), size.ToString().ToLower());
            }
        }

        private void CheckForIngredients(Ingredient ingredient, SizeType size)
        {
            switch (size)
            {
                case SizeType.Small:
                    if (ingredient.ActualAmount < 1)
                    {

                        ThrowErrorIfTheIngredientIsNotFound(ingredient, size);
                    }
                    break;
                case SizeType.Medium:
                    if (ingredient.ActualAmount < 2)
                    {
                        ThrowErrorIfTheIngredientIsNotFound(ingredient, size);
                    }
                    break;
                case SizeType.Large:
                    if (ingredient.ActualAmount < 3)
                    {
                        ThrowErrorIfTheIngredientIsNotFound(ingredient, size);
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
                "2. Soda\n" +
                "3. Tea");

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

            string askForTea = "Please insert the number of the tea you want:\n" +
              "1.Mint\n" +
              "2.ForestFruit\n" +
              "3.Chamoile";

            var coffeeType = CoffeeType.Espresso;
            var sodaType = SodaType.Fanta;
            var teaType = TeaType.Mint;

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

                        sodaType = (SodaType)sodaChoise;

                    }
                    break;
                case 3:
                    Console.WriteLine(askForTea);
                    if (int.TryParse(Console.ReadLine(), out var teaChoise))
                    {

                        teaType = (TeaType)teaChoise;

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
                case 3: tea = new Tea(teaType, size); break;
            }


        }

        public void GetReceipt()
        {
            switch (userOption)
            {
                case 1: coffee.GetReceipt(); break;
                case 2: soda.GetReceipt(); break;
                case 3: tea.GetReceipt(); break;
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
                case 3:
                    Console.Write("Your " + tea.SizeType + "  " + tea.TeaType + " will be " + price + " lei. Please insert the amount: ");
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
                case 3: return tea.BeveragePrice(); break;
            }

            return 0;

        }

        public void Pour()
        {
            int index = -1;
            List<CoffeeIngredientsType> coffeeNeededIngredients = new List<CoffeeIngredientsType>();
            List<TeaIngredientsType> teaNeededIngredients = new List<TeaIngredientsType>();
            List<SodaType> odaNeededIngredients = new List<SodaType>();


            switch (userOption)
            {
                case 1:

                    coffeeNeededIngredients = coffee.GetNedeedIngredients();
                    break;

                case 2:

                    odaNeededIngredients = soda.GetNedeedIngredients();
                    break;
                case 3:

                    teaNeededIngredients = tea.GetNedeedIngredients();

                    break;
            }


            switch (userOption)
            {

                case 1:

                    foreach (CoffeeIngredientsType ingredientNeeded in coffeeNeededIngredients)
                    {
                        index = CoffeeIngredients.FindIndex(x => x.CoffeeType.Equals(ingredientNeeded));

                        UpdateIngredientAmount(CoffeeIngredients[index], coffee.SizeType);
                    }

                    break;
                case 2:
                    foreach (SodaType ingredientNeeded in odaNeededIngredients)
                    {
                        index = SodaIngredients.FindIndex(x => x.SodaType.Equals(ingredientNeeded));

                        UpdateIngredientAmount(SodaIngredients[index], soda.SizeType);
                    }
                    break;
                case 3:
                    foreach (TeaIngredientsType ingredientNeeded in teaNeededIngredients)
                    {
                        index = TeaIngredients.FindIndex(x => x.TeaType.Equals(ingredientNeeded));

                        UpdateIngredientAmount(TeaIngredients[index], tea.SizeType);
                    }

                    break;
            }



        }
    }
}
