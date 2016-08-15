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
            // Populate database with all stock (first migration only)
            using (var db = new StockContext())
            {
                Stock2 A = new Stock2
                {
                    SKU = "A",
                    Price = 50,
                    SpecialPrice = 130,
                    QuantityRequired = 3,
                };

                Stock2 B = new Stock2
                {
                    SKU = "B",
                    Price = 30,
                    SpecialPrice = 45,
                    QuantityRequired = 2,
                };

                Stock2 C = new Stock2
                {
                    SKU = "C",
                    Price = 20,
                };

                Stock2 D = new Stock2
                {
                    SKU = "D",
                    Price = 15,
                };

                db.Stock.Add(A);
                db.Stock.Add(B);
                db.Stock.Add(C);
                db.Stock.Add(D);

                db.SaveChanges();
            }

            // Create new instance of checkout
            Checkout Checkout = new Checkout();


            // Accepts item and returns correct price
            Checkout.Scan("A");
            Console.WriteLine("Expecting: 50. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Accepts items out of order
            Checkout.Scan("A");
            Checkout.Scan("B");
            Checkout.Scan("A");
            Console.WriteLine("Expecting: 130. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Caculates correct discount even if out of order
            Checkout.Scan("B");
            Checkout.Scan("A");
            Checkout.Scan("B");
            Console.WriteLine("Expecting: 95. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Accepts unordered range of discounted and non-discounted items
            Checkout.Scan("A");
            Checkout.Scan("B");
            Checkout.Scan("C");
            Checkout.Scan("D");
            Checkout.Scan("C");
            Checkout.Scan("B");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Console.WriteLine("Expecting: 230. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Accepts many discounted item and still returns correct value
            Checkout.Scan("A");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Checkout.Scan("A");
            Console.WriteLine("Expecting: 360. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            // Handles incorrect input, and continues running
            Console.WriteLine("Expecting error message.");
            Checkout.Scan("E");
            Checkout.Scan("A");
            Console.WriteLine("Expecting: 50. Ouput: {0}", Checkout.GetTotalPrice());
            Checkout.Paid();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
