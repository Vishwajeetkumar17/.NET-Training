namespace MusicStreamingService
{
    public class Song
    {
        public string SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public TimeSpan Duration { get; set; }
        public int PlayCount { get; set; }
    }
    public class Playlist
    {
        public string PlaylistId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
    }


    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> FavoriteGenres { get; set; } = new List<string>();
        public List<Playlist> UserPlaylists { get; set; } = new List<Playlist>();
    }
    public class MusicManager
    {
        private readonly List<Song> songs = new List<Song>();
        private readonly List<User> users = new List<User>();
        private readonly List<Playlist> playlists = new List<Playlist>();

        private int songCounter = 1;
        private int playlistCounter = 1;

        public void AddUser(string id, string name)
        {
            users.Add(new User { UserId = id, UserName = name });
        }

        public void AddSong(string title, string artist, string genre,
                            string album, TimeSpan duration)
        {
            songs.Add(new Song
            {
                SongId = "S" + songCounter++,
                Title = title,
                Artist = artist,
                Genre = genre,
                Album = album,
                Duration = duration,
                PlayCount = 0
            });
        }

        public void CreatePlaylist(string userId, string playlistName)
        {
            User user = null;

            foreach (var u in users)
                if (u.UserId == userId)
                {
                    user = u;
                    break;
                }

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Playlist playlist = new Playlist
            {
                PlaylistId = "P" + playlistCounter++,
                Name = playlistName,
                CreatedBy = userId
            };

            playlists.Add(playlist);
            user.UserPlaylists.Add(playlist);
        }

        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            Playlist playlist = null;
            Song song = null;

            foreach (var p in playlists)
                if (p.PlaylistId == playlistId)
                {
                    playlist = p;
                    break;
                }

            foreach (var s in songs)
                if (s.SongId == songId)
                {
                    song = s;
                    break;
                }

            if (playlist == null || song == null)
                return false;

            playlist.Songs.Add(song);
            song.PlayCount++;
            return true;
        }

        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            Dictionary<string, List<Song>> grouped =
                new Dictionary<string, List<Song>>();

            foreach (var song in songs)
            {
                if (!grouped.ContainsKey(song.Genre))
                    grouped[song.Genre] = new List<Song>();

                grouped[song.Genre].Add(song);
            }
            return grouped;
        }

        public List<Song> GetTopPlayedSongs(int count)
        {
            List<Song> copy = new List<Song>(songs);

            copy.Sort((a, b) => b.PlayCount.CompareTo(a.PlayCount));

            List<Song> result = new List<Song>();
            for (int i = 0; i < count && i < copy.Count; i++)
                result.Add(copy[i]);

            return result;
        }

        public List<Song> GetAllSongs() => songs;
        public List<Playlist> GetAllPlaylists() => playlists;

        public class Program
        {
            static void Main(string[] args)
            {
                MusicManager manager = new MusicManager();

                manager.AddUser("U1", "Vish");

                while (true)
                {
                    Console.WriteLine("1. Add Song");
                    Console.WriteLine("2. Create Playlist");
                    Console.WriteLine("3. Add Song To Playlist");
                    Console.WriteLine("4. Group Songs By Genre");
                    Console.WriteLine("5. Top Played Songs");
                    Console.WriteLine("6. Exit");
                    Console.Write("Choice: ");

                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (choice == 1)
                    {
                        Console.Write("Title: ");
                        string t = Console.ReadLine();

                        Console.Write("Artist: ");
                        string a = Console.ReadLine();

                        Console.Write("Genre: ");
                        string g = Console.ReadLine();

                        Console.Write("Album: ");
                        string al = Console.ReadLine();

                        Console.Write("Duration (mm:ss): ");
                        TimeSpan d = TimeSpan.Parse("00:" + Console.ReadLine());

                        manager.AddSong(t, a, g, al, d);
                    }
                    else if (choice == 2)
                    {
                        Console.Write("User ID: ");
                        string uid = Console.ReadLine();

                        Console.Write("Playlist Name: ");
                        string name = Console.ReadLine();

                        manager.CreatePlaylist(uid, name);
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Playlists:");
                        foreach (var p in manager.GetAllPlaylists())
                            Console.WriteLine($"{p.PlaylistId} - {p.Name}");

                        Console.WriteLine("Songs:");
                        foreach (var s in manager.GetAllSongs())
                            Console.WriteLine($"{s.SongId} - {s.Title}");

                        Console.Write("Playlist ID: ");
                        string pid = Console.ReadLine();

                        Console.Write("Song ID: ");
                        string sid = Console.ReadLine();

                        bool ok = manager.AddSongToPlaylist(pid, sid);
                        Console.WriteLine(ok ? "Added.\n" : "Failed.\n");
                    }
                    else if (choice == 4)
                    {
                        var grouped = manager.GroupSongsByGenre();

                        foreach (var g in grouped)
                        {
                            Console.WriteLine($"Genre: {g.Key}");
                            foreach (var s in g.Value)
                                Console.WriteLine(s.Title);
                            Console.WriteLine();
                        }
                    }
                    else if (choice == 5)
                    {
                        Console.Write("Top how many: ");
                        int c = int.Parse(Console.ReadLine());

                        var top = manager.GetTopPlayedSongs(c);
                        foreach (var s in top)
                            Console.WriteLine($"{s.Title} Plays:{s.PlayCount}");
                    }
                    else if (choice == 6)
                        break;
                }
            }
        }
    }
}
