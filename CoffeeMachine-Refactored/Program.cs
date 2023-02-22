using CoffeeMachine_Refactored.Controllers;
using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Models;
using System;
using System.Net.NetworkInformation;
using System.Reflection;

namespace CoffeeMachine_Refactored // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {

            BeverageMachine beverageMachine = new BeverageMachine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Would you like coffee or soda?\n1.Coffee\n2.Soda");
                    int userOption = int.Parse(Console.ReadLine());
                    switch (userOption)
                    {
                        case 1:
                            beverageMachine.PourCoffee();
                            break;
                        case 2:
                            beverageMachine.PourSoda();
                            break;
                    }
                }
                catch (Exception ex) when (ex is BeverageTypeNotFoundException ||
                                           ex is IngredientNotFoundException ||
                                           ex is SizeNotFoundException)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}