using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Controllers
{
    internal class CoffeeMachine
    {
        IBeverageProcessor _coffeeProcessor;

        public CoffeeMachine(IBeverageProcessor coffeeProcessor)
        {
            _coffeeProcessor = coffeeProcessor;
        }

        public CoffeeMachine()
        {
            _coffeeProcessor = new CoffeeProccessor();
        }

        public void MakeCoffee()
        {

            Console.WriteLine("Please insert the number of the coffee you want:\n" +
                "1.Hot Chocolate\n" +
                "2.Espresso\n" +
                "3.Irish Coffee");

            var coffeeType = CoffeeType.Espresso;
            if (int.TryParse(Console.ReadLine(), out var coffeChoise))
            {

                coffeeType = (CoffeeType)coffeChoise;

            }


            Console.WriteLine("You choose a " + coffeeType.ToString() + " Would you like it to be:" +
                                        "\n1. Small" +
                                        "\n2. Medium" +
                                        "\n3. Large");

            var size = SizeList.Small;
            if (int.TryParse(Console.ReadLine(), out var sizeChoose))
            {
                size = (SizeList)sizeChoose;
            }

            double price = _coffeeProcessor.GetPrice(coffeeType, size);

            double paidAmount = 0;

            Console.Write("Your coffe will be " + price + " lei. Please insert the amount: ");

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

            _coffeeProcessor.MakeBeverage(coffeeType, size);

            Console.WriteLine("Your " + size + " " + coffeeType + " is ready\n");
        }

    }
}
