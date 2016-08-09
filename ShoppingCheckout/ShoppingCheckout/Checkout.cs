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
        void Scan(char item);

        int GetTotalPrice();
    }


    /// <summary>
    /// Scan codes, retrieve items from database, and calculate total price with discounts applied
    /// </summary>
    public class Checkout : ICheckout
    {
        private Dictionary<char, Stock> _stockList;
        private Dictionary<Stock, int> _itemsScanned = new Dictionary<Stock, int>();


        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="StockList"> All stock available to checkout </param>
        public Checkout(Dictionary<char, Stock> StockList)
        {
            _stockList = StockList;
        }


        /// <summary>
        /// Check stock for key, append to _itemsScanned or increase quantity
        /// </summary>
        /// <param name="Code"></param>
        public void Scan(char Code)
        {
            Stock StockItem;

            // Handle bad input
            if (_stockList.TryGetValue(Code, out StockItem)) { }
            else
            {
                Console.WriteLine(Code + " does not exist!");
            }


            
            if (StockItem != null)
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


        /// <summary>
        /// Calculates total price of all items, then subtracts total applicable discount
        /// </summary>
        /// <returns> Int of total price after discounts applied </returns>
        public int GetTotalPrice()
        {
            int runningtotal = 0;

            // For all items scanned add total price to running total and subtract discount if any
            foreach (KeyValuePair<Stock, int> Item in _itemsScanned)
            {
                runningtotal += Item.Key.Price * Item.Value;
                runningtotal -= Item.Key.CalculateDiscount(Item.Value);
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
