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
            // Dictionary faster to search with SKU as key ( O(1) instead of O(n) )
            Dictionary<char, Stock> StockList = new Dictionary<char, Stock>();
            

            // Create all stock items in kata and append them to list
            StockList.Add('A', new Stock('A', 50, 130, 3));
            StockList.Add('B', new Stock('B', 30, 45, 2));
            StockList.Add('C', new Stock('C', 20));
            StockList.Add('D', new Stock('D', 15));


            // Create new instance of checkout
            Checkout Checkout = new Checkout(StockList);


            // Accepts item and returns correct price
            Checkout.Scan('A');
            Console.WriteLine("Expecting: 50. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Accepts items out of order
            Checkout.Scan('A');
            Checkout.Scan('B');
            Checkout.Scan('A');
            Console.WriteLine("Expecting: 130. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Caculates correct discount even if out of order
            Checkout.Scan('B');
            Checkout.Scan('A');
            Checkout.Scan('B');
            Console.WriteLine("Expecting: 95. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Accepts unordered range of discounted and non-discounted items
            Checkout.Scan('A');
            Checkout.Scan('B');
            Checkout.Scan('C');
            Checkout.Scan('D');
            Checkout.Scan('C');
            Checkout.Scan('B');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Console.WriteLine("Expecting: 230. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Accepts many discounted item and still returns correct value
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Console.WriteLine("Expecting: 360. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Handles incorrect input, and continues running
            Console.WriteLine("Expecting error emssage.");
            Checkout.Scan('E');
            Checkout.Scan('A');
            Console.WriteLine("Expecting: 50. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();

            Console.ReadLine();
        }
    }
}
