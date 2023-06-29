using Microsoft.EntityFrameworkCore;

Console.WriteLine("");
using (var db = new ApplicationContext())
{
    //Create
    var country1 = new Country { Name = "Italy" };
    var country2 = new Country { Name = "Germany" };

    var city1 = new City { Name = "Rome", Country = country1 };
    var city2 = new City { Name = "Florence", Country = country1 };
    var city3 = new City { Name = "Berlin", Country = country2 };


    db.Countries.Add(country1);
    db.Countries.Add(country2);
    db.Cities.AddRange(city1, city2, city3);

    db.SaveChanges();

    //Read
    var countries = db.Countries.Include(c => c.Cities).ToList();

    Console.WriteLine("Countries and Cities:");
    foreach (var country in countries)
    {
        Console.WriteLine($"- {country.Name}");

        foreach (var city in country.Cities)
        {
            Console.WriteLine($"  * {city.Name}");
        }
    }

    //Update
    var countryToUpdate = db.Countries.FirstOrDefault(c => c.Name == "Italy");
    if (countryToUpdate != null)
    {
        countryToUpdate.Name = "Updated Country";
        db.SaveChanges();
    }

    //Delete
    var cityToDelete = db.Cities.FirstOrDefault(c => c.Name == "Berlin");
    if (cityToDelete != null)
    {
        db.Cities.Remove(cityToDelete);
        db.SaveChanges();
    }
}



public class Country
{
    public Country() { }
    public Country(string name, uint yearFounded, string govermentType, string mapImageLink, uint population, uint area, double gdp, string currentRuler, string nationalAnthem)
    {
        Name = name;
        YearFounded = yearFounded;
        GovernmentType = govermentType;
        MapImageLink = mapImageLink;
        Population = population;
        Area = area;
        GDP = gdp;
        CurrentRuler = currentRuler;
        NationalAnthem = nationalAnthem;
    }

    public int Id { get; set; }

    public string Name { get; set; }
    public uint YearFounded { get; set; }
    public string GovernmentType { get; set; }
    public string MapImageLink { get; set; }
    public uint Population { get; set; }
    public uint Area { get; set; }
    public double GDP { get; set; }
    public string CurrentRuler { get; set; }
    public string NationalAnthem { get; set; }

    public List<City> Cities { get; set; }
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int CountryId { get; set; }
    public Country Country { get; set; }
}

public class ApplicationContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-DNU6I5R;Initial Catalog=CountryDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .HasMany(c => c.Cities)
            .WithOne(city => city.Country)
            .HasForeignKey(city => city.CountryId);
    }
}
