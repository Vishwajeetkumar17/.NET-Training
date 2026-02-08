namespace MovieLibraryManagementSystem
{
    public interface IFilm
    {
        string Title { get; set; }
    }
    public class Film : IFilm
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Film(string title, string director, int year)
        {
            Title = title;
            Director = director;
            Year = year;
        }
    }
    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();
        List<IFilm> SearchFilms(string query);
        int GetTotalFilmCount();
    }
    public class FilmLibrary : IFilmLibrary
    {
        private List<IFilm> _films = new List<IFilm>();
        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }
        public void RemoveFilm(string title)
        {
            var film = _films.FirstOrDefault(f => f.Title == title);
            if (film != null)
                _films.Remove(film);
        }
        public List<IFilm> GetFilms()
        {
            return _films;
        }

        public int GetTotalFilmCount()
        {
            return _films.Count;
        }
        public List<IFilm> SearchFilms(string query)
        {
            List<IFilm> films = new List<IFilm>();
            foreach (var film in _films)
            {
                Film f = film as Film;
                if (f != null && (f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || f.Director.Contains(query, StringComparison.OrdinalIgnoreCase)))
                {
                    films.Add(film);
                }
            }
            return films;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IFilmLibrary library = new FilmLibrary();

            // ---------------- TEST CASE 1: Add Films ----------------
            Console.WriteLine("TEST CASE 1: Adding films");

            Film f1 = new Film("Inception", "Christopher Nolan", 2010);
            Film f2 = new Film("Interstellar", "Christopher Nolan", 2014);
            Film f3 = new Film("Titanic", "James Cameron", 1997);

            library.AddFilm(f1);
            library.AddFilm(f2);
            library.AddFilm(f3);

            Console.WriteLine("Films added successfully\n");

            // ---------------- TEST CASE 2: Display All Films ----------------
            Console.WriteLine("TEST CASE 2: Displaying all films");

            foreach (Film film in library.GetFilms())
            {
                Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
            }
            Console.WriteLine();

            // ---------------- TEST CASE 3: Search by Director ----------------
            Console.WriteLine("TEST CASE 3: Search films by director 'Nolan'");

            List<IFilm> searchResult = library.SearchFilms("Nolan");
            foreach (IFilm film in searchResult)
            {
                Film f = (Film)film;
                Console.WriteLine($"{f.Title} | {f.Director}");
            }
            Console.WriteLine();

            // ---------------- TEST CASE 4: Remove a Film ----------------
            Console.WriteLine("TEST CASE 4: Removing film 'Titanic'");
            library.RemoveFilm("Titanic");

            Console.WriteLine("Remaining films:");
            foreach (Film film in library.GetFilms())
            {
                Console.WriteLine(film.Title);
            }
            Console.WriteLine();

            // ---------------- TEST CASE 5: Get Total Film Count ----------------
            Console.WriteLine("TEST CASE 5: Total film count");
            Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
        }
    }
}
