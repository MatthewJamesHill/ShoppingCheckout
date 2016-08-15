using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    /// <summary>
    /// Default interface required by kata
    /// </summary>
    interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();
    }


    /// <summary>
    /// Scan codes, retrieve items from database, and calculate total price with discounts applied
    /// </summary>
    public class Checkout : ICheckout
    {
        private Dictionary<Stock, int> _itemsScanned = new Dictionary<Stock, int>();


        /// <summary>
        /// Check stock for key, append to _itemsScanned or increase quantity
        /// </summary>
        /// <param name="Code"> String scanned into checkout </param>
        public void Scan(string Code)
        {
            using (var db = new StockContext())
            {
                Stock StockItem = db.Stock.Find(Code);

                // Handle bad input
                if (StockItem == null)
                {
                    Console.WriteLine(Code + " does not exist!");
                }

                else
                {
                    if (_itemsScanned.ContainsKey(StockItem))
                    {
                        _itemsScanned[StockItem]++;
                    }
                    else
                    {
                        _itemsScanned.Add(StockItem, 1);
                    }
                }
            }
        }


        /// <summary>
        /// Calculates total price of all items, then subtracts total applicable discount
        /// </summary>
        /// <returns> Int of total price after discounts applied </returns>
        public int GetTotalPrice()
        {
            int runningtotal = 0;

            // For all items scanned add total price to running total and subtract discount if any
            foreach (KeyValuePair<Stock2, int> Item in _itemsScanned)
            {
                runningtotal += Item.Key.Price * Item.Value;
                runningtotal -= Discounts.CalculateDiscount(Item.Value,
                                                            Item.Key.Price,
                                                            Item.Key.QuantityRequired,
                                                            Item.Key.SpecialPrice);
            }

            return runningtotal;
        }


        /// <summary>
        /// Clears _itemsScanned for next customer
        /// </summary>
        public void Paid()
        {
            _itemsScanned.Clear();
        }
    }
}
