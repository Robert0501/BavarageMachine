using CoffeeMachine_Refactored.Enums;
using CoffeeMachine_Refactored.Exceptions;
using CoffeeMachine_Refactored.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine_Refactored.Models
{

    public class Tea : IBeverage

    {
        private TeaType _teaType;
        public TeaType TeaType { get { return _teaType; } set { _teaType = value; } }

        private int _basePrice;
        public int BasePrice { get { return _basePrice; } set { _basePrice = value; } }

        private SizeType _sizeType;
        public SizeType SizeType { get { return _sizeType; } set { _sizeType = value; } }

        public List<TeaIngredientsType> Ingredients;
        public Tea()
        {
            Ingredients = new List<TeaIngredientsType>();
        }

        public Tea(TeaType teaType, SizeType size)
        {
            this.BasePrice = 5;
            this._teaType = teaType;
            this._sizeType = size;
            Ingredients = new List<TeaIngredientsType>();
        }
        public double BeveragePrice()
        {
            int numberOfIngredients = GetUsedIngredientsNumber();
            return this.BasePrice + (0.1 * BasePrice * numberOfIngredients * (double)this.SizeType);
        }

        public void GetReceipt()
        {
            switch (TeaType)
            {
                case TeaType.Mint:
                    this.Ingredients.Add(TeaIngredientsType.Mint); break;
                case TeaType.ForestFruit:
                    this.Ingredients.Add(TeaIngredientsType.ForestFruit); break;
                case TeaType.Chamomile:
                    this.Ingredients.Add(TeaIngredientsType.Chamomile); break;
                default: throw new BeverageTypeNotFoundException("We don't have that type of tea");
            }

            this.Ingredients.Add(TeaIngredientsType.Water);
        }

        public List<TeaIngredientsType>? GetNedeedIngredients()
        {
            var neededIngredients = new List<TeaIngredientsType>();
            foreach (TeaIngredientsType ingredient in Ingredients)
            {
                neededIngredients.Add(ingredient);
                
            }

            return neededIngredients;
        }

        public int GetUsedIngredientsNumber()
        {

            return this.Ingredients.Count();
        }
    }
}
