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
        private Dictionary<Stock, int> _itemsScanned = new Dictionary<Stock, int>();


        public Checkout()
        {
        }


        public void Scan(string item)
        {
            // code
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
