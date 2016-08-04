using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    interface ICheckout
    {
        void Scan(char item);

        int GetTotalPrice();
    }


    public class Checkout : ICheckout
    {
        private Dictionary<char, Stock> _stockList;
        private Dictionary<Stock, int> _itemsScanned = new Dictionary<Stock, int>();


        public Checkout(Dictionary<char, Stock> StockList)
        {
            _stockList = StockList;
        }


        // Checks database (simple list currently) for item, appends to dictionary or increases quantity
        public void Scan(char Code)
        {
            // No code to handle key does not exist yet
            Stock StockItem = _stockList[Code];

            if ( _itemsScanned.ContainsKey(StockItem))
            {
                _itemsScanned[StockItem]++;
            }
            else
            {
                _itemsScanned.Add(StockItem, 1);
            }
        }


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


        public void Paid()
        {
            _itemsScanned.Clear();
        }
    }
}
