using Serl;
using Journal;
Console.WriteLine("");


namespace Journal
{
    class Article
    {
        Article(string name, int charactersNumber, DateTime anonsDate)
        {
            this.Name = name;
            this.CharactersNumber = charactersNumber;
            this.AnonsDate = anonsDate;
        }

        public Article CreateArticle()
        {
            string tmpName;
            int tmpCharactersNumber;
            DateTime tmpAnonsDate;

            Console.WriteLine("--Article Creation--");

            Console.WriteLine("Enter Name of Article: ");
            tmpName = Console.ReadLine();

            Console.WriteLine("Enter Number of Characters of Article: ");
            tmpCharactersNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Anons Date of Article: ");
            tmpAnonsDate = DateTime.Parse(Console.ReadLine());

            Article tmpArticle = new Article(tmpName, tmpCharactersNumber, tmpAnonsDate);

            return tmpArticle;
        }

        public void printAll()
        {
            Console.WriteLine(
                $"Name of Article: {this.Name}\n" +
                $"Characters Number of Article: {this.CharactersNumber}\n" +
                $"Anons Date of Article: {this.AnonsDate}\n"
            );
            
        }

        public string Name { get; set; }
        public int CharactersNumber { get; set; }
        public DateTime AnonsDate { get; set; }
    }

    class Magazine : ISerialiazation
    {
        Magazine(string name, string publisherName, DateTime releaseDate, int pagesNumber, List<Article> articles)
        {
            this.Name = name;
            this.PublisherName = publisherName;
            this.ReleaseDate = releaseDate;
            this.PagesNumber = pagesNumber;
            this.Articles = articles;
        }

        public Magazine CreateMagazine()
        {
            string tmpName;
            string tmpPublisherName;
            DateTime tmpReleaseDate;
            int tmpPagesNumber;
            List<Article> tmpArticles = new();

            Console.WriteLine("--Magazine Creation--");

            Console.WriteLine("Enter Name of Magazine: ");
            tmpName = Console.ReadLine();

            Console.WriteLine("Enter Publisher Name of Magazine: ");
            tmpPublisherName = Console.ReadLine();

            Console.WriteLine("Enter date: ");
            tmpReleaseDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of page of Magazine: ");
            tmpPagesNumber = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < tmpArticles.Count; i++)
            {
                tmpArticles[i] = tmpArticles[i].CreateArticle();
            }

            Magazine tmpMagazine = new Magazine(tmpName, tmpPublisherName, tmpReleaseDate, tmpPagesNumber, tmpArticles);

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

            Console.WriteLine("Articles: ");

            for (int i = 0; i < this.Articles.Count; i++)
            {
                this.Articles[i].printAll();
            }
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
        public List<Article> Articles { get; set; }
    }


}
