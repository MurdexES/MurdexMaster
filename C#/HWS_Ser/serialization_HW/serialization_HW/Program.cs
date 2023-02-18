using Serl;
using Journal;
Console.WriteLine();


namespace Journal
{
    class Magazine : ISerialiazation
    {
        Magazine(string name, string publisherName, DateTime releaseDate, int pagesNumber)
        {
            this.Name = name;
            this.PublisherName = publisherName;
            this.ReleaseDate = releaseDate;
            this.PagesNumber = pagesNumber;
        }

        public Magazine CreateMagazine()
        {
            string tmpName;
            string tmpPublisherName;
            DateTime tmpReleaseDate;
            int tmpPagesNumber;

            Console.WriteLine("--Magazine Creation--");

            Console.WriteLine("Enter Name of Magazine: ");
            tmpName = Console.ReadLine();

            Console.WriteLine("Enter Publisher Name of Magazine: ");
            tmpPublisherName = Console.ReadLine();

            Console.WriteLine("Enter date: ");
            tmpReleaseDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of page of Magazine: ");
            tmpPagesNumber = Int32.Parse(Console.ReadLine());

            Magazine tmpMagazine = new Magazine(tmpName, tmpPublisherName, tmpReleaseDate, tmpPagesNumber);

            return tmpMagazine;
        }

        public void printAll()
        {
            Console.WriteLine(
                $"Name: {this.Name}\n" +
                $"Publisher Name: {this.PublisherName}\n" +
                $"Release Date: {this.ReleaseDate}\n" +
                $"Pages Number: {this.PagesNumber}\n"
            );
        }

        public void serializeMagazine(Magazine magazine)
        {
            Serializator service = new();

            var json = service.Serialize(magazine);

            using FileStream fs = new("album_data.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public void deserializeMagazine(Magazine magazine)
        {
            using FileStream fs = new("magazine_data.json", FileMode.OpenOrCreate);
            using StreamReader sr = new(fs);

            Serializator service = new();
            var obj = service.Deserialiaze<Magazine>(sr.ReadToEnd());

            Console.WriteLine(obj);
        }


        public string Name { get; set; }
        public string PublisherName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PagesNumber { get; set; }
    }


}
