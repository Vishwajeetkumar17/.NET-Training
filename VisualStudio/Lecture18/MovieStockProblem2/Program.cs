using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStockProblem2
{
    /// <summary>
    /// Represents a movie with basic details
    /// such as title, artist, genre, and rating.
    /// </summary>
    public class Movie
    {
        #region Properties

        // Gets or sets the movie title
        public string Title { get; set; }

        // Gets or sets the artist name
        public string Artist { get; set; }

        // Gets or sets the movie genre
        public string Genre { get; set; }

        // Gets or sets the movie rating
        public int Rating { get; set; }

        #endregion
    }

    /// <summary>
    /// Manages movie stock, allows adding movies,
    /// and viewing movies based on genre or ratings.
    /// </summary>
    public class Program
    {
        #region Fields

        // Stores the list of movies
        public static List<Movie> MovieList = new List<Movie>();

        #endregion

        #region Movie Management Methods

        // Adds a movie using comma-separated input details
        public void AddMovie(string MovieDetails)
        {
            var details = MovieDetails.Split(',');

            if (details.Length != 4)
            {
                Console.WriteLine("Enter a valid Input");
                return;
            }

            if (int.TryParse(details[3], out int rating) && rating >= 0 && rating <= 10)
            {
                Movie movie = new Movie
                {
                    Title = details[0].Trim(),
                    Artist = details[1].Trim(),
                    Genre = details[2].Trim(),
                    Rating = int.Parse(details[3].Trim())
                };

                MovieList.Add(movie);
            }
            else
            {
                Console.WriteLine("Enter a Valid Rating");
            }
        }

        // Returns movies matching the given genre
        public List<Movie> ViewMoviesByGenre(string genre)
        {
            var movies = MovieList.Where(m => m.Genre == genre).ToList();
            return movies;
        }

        // Returns movies sorted by rating
        public List<Movie> ViewMoviesByRatings()
        {
            return MovieList.OrderBy(m => m.Rating).ToList();
        }

        #endregion

        #region UI Methods

        // Takes user input and adds a movie
        public void AddMovieUI()
        {
            Console.Write("Enter Movie Details: ");
            string details = Console.ReadLine();
            AddMovie(details);
        }

        // Displays movies filtered by genre
        public void ViewMoviesByGenreUI()
        {
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            var movies = ViewMoviesByGenre(genre);
            if (movies.Count == 0)
            {
                Console.WriteLine($"No Movies found in genre '{genre}'");
            }
            else
            {
                foreach (var movie in movies)
                {
                    Console.WriteLine(
                        movie.Title + "," +
                        movie.Artist + "," +
                        movie.Genre + "," +
                        movie.Rating
                    );
                }
            }
        }

        // Displays movies sorted by ratings
        public void ViewMoviesByRatingsUI()
        {
            var movies = ViewMoviesByRatings();
            foreach (var movie in movies)
            {
                Console.WriteLine(
                    movie.Title + "," +
                    movie.Artist + "," +
                    movie.Genre + "," +
                    movie.Rating
                );
            }
        }

        #endregion

        #region Application Entry Point

        // Entry point of the application
        static void Main(string[] args)
        {
            Program p = new Program();
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. View Movies By Genre");
                Console.WriteLine("3. View Movies By Ratings");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        p.AddMovieUI();
                        break;
                    case 2:
                        p.ViewMoviesByGenreUI();
                        break;
                    case 3:
                        p.ViewMoviesByRatingsUI();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        #endregion
    }
}
