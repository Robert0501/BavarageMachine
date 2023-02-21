using CoffeeMachine_Refactored.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Exceptions
{
    [Serializable]
    public class IngredientNotFoundException : Exception
    {
        public IngredientNotFoundException() { }

        public IngredientNotFoundException(string ingredient, string size) : base("There is not enough " + ingredient + " in the machine for a " + size + " size coffee") { }

       
    }
}
