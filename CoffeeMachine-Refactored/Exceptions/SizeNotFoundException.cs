using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Exceptions
{
    public class SizeNotFoundException : Exception
    {

        public SizeNotFoundException() : base() { }
        public SizeNotFoundException(string message) : base(message) { }
    }
}
