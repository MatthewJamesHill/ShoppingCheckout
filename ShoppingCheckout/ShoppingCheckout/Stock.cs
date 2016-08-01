using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    class Stock
    {
        // Would rather use string for greater variation / flexibility but Kata requires char
        public char SKU { get; private set; }
        public int Price { get; set; }

        public int? SpecialPrice { get; set; }
        public int? QuantityRequired { get; set; }


        // Default constructor with no discount
        public Stock(char StockKeepingUnit, int UnitPrice)
        {
            SKU = StockKeepingUnit;
            Price = UnitPrice;

            SpecialPrice = null;
            QuantityRequired = null;
        }
        

        // Overriden constructor with discount
        public Stock(char StockKeepingUnit, int UnitPrice, int SpecialPrice, int QuantityRequired)
        {
            SKU = StockKeepingUnit;
            Price = UnitPrice;

            this.SpecialPrice = SpecialPrice;
            this.QuantityRequired = QuantityRequired;
        }

         
        // Positive integer of difference between QuantityRequired times price and SpecialPrice
        private int DiscountPerQuantityRequired => (Price * (int)QuantityRequired) - (int)SpecialPrice;


        // Returns positive integer of discount to be applied based on quantity of item
        public int CalculateDiscount(int Quantity)
        {
            if (Quantity < QuantityRequired) { return 0; }

            else
            {
                return (Quantity / (int)QuantityRequired) * DiscountPerQuantityRequired;
            }
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
