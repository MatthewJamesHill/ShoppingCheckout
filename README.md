# ShoppingCheckout
Implementation of code for a supermarket checkout for challenge below:



Implement a code for a supermarket checkout
    It must handle pricing strategies such as 3 for 130 etc.
    Prices change regularly so must be independent of the checkout
    
    
    The interface for the checkout is:
    
    Interface ICheckout
    {
        void Scan(char item);
        int GetTotalPrice();
    }

    
    The current stocklist is:
    
        SKU     UnitPrice       SpecialPrice
        A           50          3 for 130
        B           30          2 for 45
        C           20
        D           15

The first three files are for my first implementation
The next three files are for a refactored version using a Code First Entity framework implementation
