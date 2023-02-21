using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Enums
{
    public enum CoffeeType
    {
        [Display(Name = "Hot Chocolate") ]
        HotChocolate = 1,
        Espresso = 2,
        [Display(Name = "Irish Coffee")]
        IrishCoffee = 3
    }
}
