using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    struct Stock
    {
        public string StockKeepingUnit { get; set; }

        public int Price { get; set; }


        public Stock(string StockKeepingUnit, int Price)
        {
            this.StockKeepingUnit = StockKeepingUnit;
            this.Price = Price;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
