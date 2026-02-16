using System;

namespace BookStoreApplication
{
    public class BookUtility
    {
        private Book _book;

        public BookUtility(Book book)
        {
            // TODO: Assign book object
            _book = book;
        }

        public void GetBookDetails()
        {
            // TODO:
            // Print format:
            // Details: <BookId> <Title> <Price> <Stock>
            Console.WriteLine($"{_book.Id} {_book.Title} {_book.Price} {_book.Stock}");
        }

        public void UpdateBookPrice(int newPrice)
        {
            // TODO:
            // Validate new price
            if(newPrice < 0)
            {
                throw new InvalidBookDataException("Invalid Price.");
            }
            // Update price
            _book.Price = newPrice;
            // Print: Updated Price: <newPrice>
            Console.WriteLine($"Updated Price: {_book.Price}");

        }

        public void UpdateBookStock(int newStock)
        {
            // TODO:
            // Validate new stock
            if(newStock < 0)
            {
                throw new InvalidBookDataException("Invalid Stock.");
            }
            // Update stock
            _book.Stock = newStock;
            // Print: Updated Stock: <newStock>
            Console.WriteLine($"UPdated Stock: {_book.Stock}");
        }
    }
}
