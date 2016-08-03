using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    public class Stock
    {
        // Would rather use string for greater variation / flexibility but Kata requires char
        public char SKU { get; private set; }
        public int Price { get; set; }

        public int SpecialPrice { get; set; }
        public int QuantityRequired { get; set; }


        // Default constructor with no discount
        public Stock(char StockKeepingUnit, int UnitPrice)
        {
            SKU = StockKeepingUnit;
            Price = UnitPrice;

            SpecialPrice = 0;
            QuantityRequired = 0;
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
        private int DiscountPerQuantityRequired => (Price * QuantityRequired) - SpecialPrice;


        // Returns positive integer of discount to be applied based on quantity of item
        public int CalculateDiscount(int Quantity)
        {

            if ( SpecialPrice == 0 || Quantity < QuantityRequired)
            {
                return 0;
            }

            else
            {
                return (Quantity / QuantityRequired) * DiscountPerQuantityRequired;
            }
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
