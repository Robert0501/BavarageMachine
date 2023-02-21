using CoffeeMachine_Refactored.Controllers;
using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Models;
using System;
using System.Net.NetworkInformation;
using System.Reflection;

namespace CoffeeMachine_Refactored // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CoffeeMachine coffeeMachine = new CoffeeMachine();

            while (true)
            {
                try
                {
                    coffeeMachine.MakeCoffee();

                }
                catch (IngredientNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CoffeeTypeNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (SizeNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}