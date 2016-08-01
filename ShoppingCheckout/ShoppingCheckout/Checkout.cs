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


    class Checkout : ICheckout
    {
        private List<Stock> _stockList;
        private Dictionary<Stock, int> _itemsScanned = new Dictionary<Stock, int>();


        public Checkout(List<Stock> StockList)
        {
            _stockList = StockList;
        }


        // Checks database (simple list currently) for item, appends to dictionary or increases quantity
        public void Scan(char Code)
        {
            Stock StockItem;
            foreach (Stock Item in _stockList)
            {
                if (Item.SKU == Code) { StockItem = Item; }
                break;
            }

            // Check if StockItem already key in _itemsScanned
            // If so increment quantity
            // Else add to dict with quantity of 1
        }


        public int GetTotalPrice()
        {
            return 0;
        }


        public void Paid()
        {
            _itemsScanned.Clear();
        }
    }
}
