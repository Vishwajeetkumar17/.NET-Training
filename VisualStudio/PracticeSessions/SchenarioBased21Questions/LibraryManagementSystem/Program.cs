using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
    }

    public class LibraryUtility
    {
        public void AddBook(string title, string author, string genre, int year)
        {
            int key = Program.AllBooks.Count + 1;

            List<Book> books = new List<Book>
            {
                new Book
                {
                    Title = title,
                    Author = author,
                    Genre = genre,
                    PublicationYear = year
                }
            };
            Program.AllBooks.Add(key, books);
        }

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> groupBooks = new SortedDictionary<string, List<Book>>();

            foreach (var bookList in Program.AllBooks.Values)
            {
                foreach (Book book in bookList)
                {
                    if (!groupBooks.ContainsKey(book.Genre))
                    {
                        groupBooks[book.Genre] = new List<Book>();
                    }
                    groupBooks[book.Genre].Add(book);
                }
            }
            return groupBooks;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> result = new List<Book>();

            foreach (var bookList in Program.AllBooks.Values)
            {
                foreach (Book book in bookList)
                {
                    if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(book);
                    }
                }
            }
            return result;
        }

        public int GetTotalBooksCount()
        {
            int count = 0;
            foreach (var list in Program.AllBooks.Values)
            {
                count += list.Count;
            }
            return count;
        }
    }

    public class Program
    {
        public static SortedDictionary<int, List<Book>> AllBooks = new SortedDictionary<int, List<Book>>();

        static void Main(string[] args)
        {
            LibraryUtility libraryUtility = new LibraryUtility();

            while (true)
            {
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Display books grouped by genre");
                Console.WriteLine("3. Search books by author");
                Console.WriteLine("4. Show total books count");
                Console.WriteLine("Enter your choice");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter Title:");
                    string title = Console.ReadLine();

                    Console.WriteLine("Enter Author:");
                    string author = Console.ReadLine();

                    Console.WriteLine("Enter Genre:");
                    string genre = Console.ReadLine();

                    Console.WriteLine("Enter Publication Year:");
                    int year = int.Parse(Console.ReadLine());

                    libraryUtility.AddBook(title, author, genre, year);
                    Console.WriteLine("Book details added successfully\n");
                }
                else if (choice == 2)
                {
                    var groupedBooks = libraryUtility.GroupBooksByGenre();

                    foreach (var genre in groupedBooks)
                    {
                        Console.WriteLine($"Genre: {genre.Key}");
                        foreach (Book book in genre.Value)
                        {
                            Console.WriteLine($"Title: {book.Title}");
                            Console.WriteLine($"Author: {book.Author}");
                            Console.WriteLine($"Year: {book.PublicationYear}");
                            Console.WriteLine();
                        }
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter author name:");
                    string author = Console.ReadLine();

                    var books = libraryUtility.GetBooksByAuthor(author);

                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books found.\n");
                    }
                    else
                    {
                        foreach (Book book in books)
                        {
                            Console.WriteLine($"Title: {book.Title} (Year: {book.PublicationYear}) - Genre: {book.Genre}");
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Total books count: " + libraryUtility.GetTotalBooksCount() + "\n");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Exiting.");
                    break;
                }
            }
        }
    }
}
