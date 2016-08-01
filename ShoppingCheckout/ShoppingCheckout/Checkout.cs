using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    interface ICheckout
    {
        void Scan(string item);

        int GetTotalPrice();
    }


    class Checkout : ICheckout
    {
        private Dictionary<object, int> _itemsScanned = new Dictionary<object, int>();


        public Checkout()
        {
        }


        public void Scan(string item)
        {
            if (_itemsScanned.ContainsKey(item))
            {
                _itemsScanned[item]++;
            }
            else
            {
                _itemsScanned.Add(item, 1);
            }
        }


        private int TotalPriceBeforeDiscount()
        {
            int total = 0;

            foreach (KeyValuePair<object, int> kvp in _itemsScanned)
            {
                total += kvp.Value * // reference price kvp.Key ;
            }

            return total;
        }


        private int TotalDiscount()
        {
            // total of all discounts
            int total = 0;

            foreach (KeyValuePair<object, int> kvp in _itemsScanned)
            {
                // code
            }

            return total;
        }


        public int GetTotalPrice()
        {
            return TotalPriceBeforeDiscount() - TotalDiscount();
        }


        public void Paid()
        {
            _itemsScanned.Clear();
        }
    }
}
