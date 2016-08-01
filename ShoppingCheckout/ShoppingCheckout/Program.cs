using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCheckout
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using a list instead of writing new database for kata
            List<Stock> StockList = new List<Stock>();


            // Create all stock items and append them to list
            StockList.Add(new Stock('A', 50, 130, 3));
            StockList.Add(new Stock('B', 30, 45, 2));
            StockList.Add(new Stock('C', 20));
            StockList.Add(new Stock('D', 15));


        }
    }
}
