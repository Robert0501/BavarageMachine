using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Interfaces
{
    public interface IBeverageProcessor
    {
        double GetPrice();
        void Pour();
        void AskForBeverage();
        void AskForPayment();
        void GetReceipt();
        void showActualIngredientAmount();
    }
}
