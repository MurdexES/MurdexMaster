using Serl;
using Music;



namespace Music
{
    class Song
    {
        public Song(string name, float songLongevity, string genre)
        {
            Name = name;
            SongLongevity = songLongevity;
            Genre = genre;
        }

        public Song createSong()
        {
            string tmpName;
            float tmpLongevity;
            string tmpGenre;

            Console.WriteLine("--Song Creation--");

            Console.WriteLine("Enter name of Song: ");
            tmpName = Console.ReadLine();

            Console.WriteLine("Enter longevity of Song: ");
            tmpLongevity = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter genre of Song: ");
            tmpGenre = Console.ReadLine();

            Song tmpSong = new Song(tmpName, tmpLongevity, tmpGenre);

            return tmpSong;
        }

        public void printAll()
        {
            Console.WriteLine(
                $"Song Name - {Name}\n" +
                $"Song Longevity - {SongLongevity}\n" +
                $"Song Genre - {Genre}\n"
            );
        }

        public string Name { get; set; }
        public float SongLongevity { get; set; }
        public string Genre { get; set; }
    }
    class Album : ISerialization
    {
        public Album(string name, string artistName, DateTime releaseDate, float longevity, string studioName, Song[] songs)
        {
            Name = name;
            ArtistName = artistName;
            ReleaseDate = releaseDate;
            Longevity = longevity;
            StudioName = studioName;
            Songs = songs;
        }

        public Album createAlbum()
        {
            string tmpName;
            string tmpArtistName;
            DateTime tmpReleaseDate;
            float tmpLongevity;
            string tmpStudioName;
            Song[] songs = Songs;

            int len = songs.Length;

            Console.WriteLine("--Album Creation--");

            Console.WriteLine("Enter name of Album: ");
            tmpName = Console.ReadLine();

            Console.WriteLine("Enter name of Author of Album: ");
            tmpArtistName = Console.ReadLine();

            Console.WriteLine("Enter date of  release Album: ");
            tmpReleaseDate = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter longevity of Album: ");
            tmpLongevity = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter name studio of Album: ");
            tmpStudioName = Console.ReadLine();

            for (int i = 0; i < len; i++)
            {
                songs[i] = songs[i].createSong();
            }

            Album tmpAlbum = new Album(tmpName, tmpArtistName, tmpReleaseDate, tmpLongevity, tmpStudioName, songs);

            return tmpAlbum;
        }

        public void printAll()
        {
            Console.WriteLine(
                $"Album Name - {Name}\n" +
                $"Album Author`s Name - {ArtistName}\n" +
                $"Album Release Date - {ReleaseDate}\n" +
                $"Album Longevity - {Longevity}\n" +
                $"Album Studio Name - {StudioName}\n"
            );

            for (int i = 0; i < Songs.Length; i++)
            {
                Console.WriteLine($"-- {i + 1} --");
                Songs[i].printAll();
            }
        }

        public void serializeAlbum(Album album)
        {
            Serializator service = new();

            var json = service.Serialize(album);

            using FileStream fs = new("album_data.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public void deserializeAlbum(Album album)
        {
            using FileStream fs = new("album_data.json", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);

            Serializator service = new();
            var obj = service.Deserialize<Album>(sr.ReadToEnd());

            Console.WriteLine(obj);
        }

        public string Name { get; set; }
        public string ArtistName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Longevity { get; set; }
        public string StudioName { get; set; }
        public Song[] Songs { get; set; }

    }
}
