using LibraryApp.Models;

namespace LibraryApp.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public MemoryBookRepository()
        {
            _books = new List<Book>()
            {
                new Book{ BookId = 1, Title = "C Programming", Author = "Raman", Price = 500 },
                new Book{ BookId = 2, Title = "Java", Author = "Snehal", Price = 650 },
                new Book{ BookId = 3, Title = "c#", Author = "Asha", Price = 700 }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.BookId == id);
        }

        public void AddBook(Book book)
        {
            book.BookId = _books.Max(b => b.BookId) + 1;
            _books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
                _books.Remove(book);
        }
    }
}