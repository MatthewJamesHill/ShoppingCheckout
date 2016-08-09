using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShoppingCheckout
{
    /// <summary>
    /// Context for database
    /// </summary>
    public class StockContext : DbContext
    {
        public DbSet<Stock> Stock { get; set; }
    }
    // https://msdn.microsoft.com/en-us/data/jj572366

    
    
    /// <summary>
    /// Item of stock, includes SKU, price, and discount information
    /// </summary>
    public class Stock
    {
        // Would rather use string for greater variation / flexibility but Kata requires char
        public char SKU { get; private set; }
        public int Price { get; set; }

        public int SpecialPrice { get; set; }
        public int QuantityRequired { get; set; }


        /// <summary>
        /// Default constructor with no discount
        /// </summary>
        /// <param name="StockKeepingUnit"> SKU reference for stock item </param>
        /// <param name="UnitPrice"> Price in pence per unit </param>
        public Stock(char StockKeepingUnit, int UnitPrice)
        {
            SKU = StockKeepingUnit;
            Price = UnitPrice;

            SpecialPrice = 0;
            QuantityRequired = 0;
        }


        /// <summary>
        /// Overriden constructor with discount
        /// </summary>
        /// <param name="StockKeepingUnit"> SKU reference for stock item </param>
        /// <param name="UnitPrice"> Price in pence per unit </param>
        /// <param name="SpecialPrice"> Price in pence per unit if quantity required condition met </param>
        /// <param name="QuantityRequired"> Quantity of stock required for discount to apply </param>
        public Stock(char StockKeepingUnit, int UnitPrice, int SpecialPrice, int QuantityRequired)
        {
            SKU = StockKeepingUnit;
            Price = UnitPrice;

            this.SpecialPrice = SpecialPrice;
            this.QuantityRequired = QuantityRequired;
        }


        /// <summary>
        /// Positive integer of difference between QuantityRequired times price and SpecialPrice
        /// </summary>
        private int DiscountPerQuantityRequired => (Price * QuantityRequired) - SpecialPrice;


        /// <summary>
        /// Calculates how much to deduct from the total price based on the quantity of stock given
        /// </summary>
        /// <param name="Quantity"> How many items are being purchased in this transaction </param>
        /// <returns> Positive integer in pence </returns>
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
            return SKU.ToString();
        }
    }
}
