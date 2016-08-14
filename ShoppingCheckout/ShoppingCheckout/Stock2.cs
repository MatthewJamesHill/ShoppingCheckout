using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DbSet<Stock2> Stock { get; set; }
    }


    /// <summary>
    /// Item of stock, includes SKU, price, and discount information
    /// </summary>
    public class Stock2
    {
        [Key]
        public string SKU { get; set; }

        public int Price { get; set; }

        public int SpecialPrice { get; set; } = 0;

        public int QuantityRequired { get; set; } = 0;
    }


    public static class Discounts
    {
        /// <summary>
        /// Calculates how much to deduct from the total price based on the quantity of stock given
        /// </summary>
        /// <param name="Quantity"> How many items are being purchased in this transaction </param>
        /// <param name="Price"> Price of this stock item </param>
        /// <param name="QuantityRequired"> How many items required to obtain discount </param>
        /// <param name="SpecialPrice"> New price per item if QuantityRequired met </param>
        /// <returns> Positive integer of discount in pence </returns>                        
        public static int CalculateDiscount(int Quantity, int Price, int QuantityRequired, int SpecialPrice)
        {

            if (SpecialPrice == 0 || Quantity < QuantityRequired)
            {
                return 0;
            }

            else
            {
                return (Quantity / QuantityRequired) * ((Price * QuantityRequired) - SpecialPrice);
            }
        }
    }
}
