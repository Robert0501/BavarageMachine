using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Exceptions
{
    [Serializable]
    internal class CoffeeTypeNotFoundException : Exception
    {
        public CoffeeTypeNotFoundException() : base() { }
        public CoffeeTypeNotFoundException(string message) : base(message) { }
    }
}
