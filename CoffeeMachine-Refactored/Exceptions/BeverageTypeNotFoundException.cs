using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Exceptions
{
    [Serializable]
    internal class BeverageTypeNotFoundException : Exception
    {
        public BeverageTypeNotFoundException() : base() { }
        public BeverageTypeNotFoundException(string message) : base(message) { }
    }
}
