using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace ShoppingCheckout
{
    /// <summary>
    /// All tests just for stock class
    /// </summary>
    [TestFixture]
    public class StockTests
    {
        // Instantiate stock for testing
        Stock A = new Stock('A', 50, 130, 3);
        Stock C = new Stock('C', 20);


        /// <summary>
        /// Checks for valid stock type where using the default constructor
        /// </summary>
        [Test]
        public void DefaultStockInstance()
        {
            Assert.AreEqual(typeof(Stock), C.GetType());

            Assert.IsTrue(C.SKU == 'C');
            Assert.IsTrue(C.Price == 20);
            Assert.IsTrue(C.SpecialPrice == 0);
            Assert.IsTrue(C.QuantityRequired == 0);
        }


        /// <summary>
        /// Checks for valid stock type where all parameters are given
        /// </summary>
        [Test]
        public void OverloadedStockInstance()
        {
            Assert.AreEqual(typeof(Stock), A.GetType());

            Assert.IsTrue(A.SKU == 'A');
            Assert.IsTrue(A.Price == 50);
            Assert.IsTrue(A.SpecialPrice == 130);
            Assert.IsTrue(A.QuantityRequired == 3);
        }


        /// <summary>
        /// Checks for appropriate discounting within stock class
        /// </summary>
        [Test]
        public void DefaultStockDiscounts()
        {
            Assert.IsTrue(C.CalculateDiscount(0) == 0);
            Assert.IsTrue(C.CalculateDiscount(5) == 0);
        }


        /// <summary>
        /// Checks against inappropriate discounting within stock class
        /// </summary>
        [Test]
        public void OverloadedStockDiscounts()
        {
            Assert.IsTrue(A.CalculateDiscount(0) == 0);
            Assert.IsTrue(A.CalculateDiscount(3) == 20);
            Assert.IsTrue(A.CalculateDiscount(5) == 20);
        }
    }


    /// <summary>
    /// All tests for checkout class
    /// </summary>
    [TestFixture]
    public class CheckoutTests
    {
        // Instantiate stocklist for testing
        static Dictionary<Char, Stock> StockList = new Dictionary<Char, Stock>
        {
            { 'A', new Stock('A', 50, 130, 3) },
            { 'B', new Stock('B', 30, 45, 2) },
            { 'C', new Stock('C', 20) },
            { 'D', new Stock('D', 15) },
        };
        
        // Instantiate checkout for testing
        Checkout Checkout = new Checkout(StockList);


        /// <summary>
        /// Checks Scan and GetTotalPrice methods
        /// </summary>
        [Test]
        public void InputOutput()
        {
            Checkout.Scan('A');
            Assert.AreEqual(50, Checkout.GetTotalPrice());

            Checkout.Paid();
        }


        /// <summary>
        /// Checks checkout returns appropriate discount
        /// </summary>
        public void DiscountedItems()
        {
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('A');
            Assert.AreEqual(130, Checkout.GetTotalPrice());

            Checkout.Paid();
        }


        /// <summary>
        /// Checks checkout returns appropriate discount, and does not over discount
        /// </summary>
        public void ManyItems()
        {
            Checkout.Scan('A');
            Checkout.Scan('A');
            Checkout.Scan('B');
            Checkout.Scan('B');
            Checkout.Scan('C');
            Checkout.Scan('C');
            Checkout.Scan('D');
            Checkout.Scan('C');
            Checkout.Scan('B');
            Checkout.Scan('A');
            Assert.AreEqual(325, Checkout.GetTotalPrice());

            Checkout.Paid();
        }


        /// <summary>
        /// Checks checkout does not crash with bad input
        /// </summary>
        public void BadInput()
        {
            Checkout.Scan('A');
            Checkout.Scan('E');
            Assert.AreEqual(50, Checkout.GetTotalPrice());

            Checkout.Paid();
        }
    }
}
