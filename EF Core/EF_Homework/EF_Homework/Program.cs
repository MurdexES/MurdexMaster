using Microsoft.Data.SqlClient;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using EF_Homework;
using System.Text.Json;
using System.Diagnostics;

int select = 0;

Console.WriteLine("1.Add Product\n" +
    "2.Sort Products\n" +
    "3.Filter Products\n" +
    "Enter your choice: ");

select = Int32.Parse(Console.ReadLine());

switch (select)
{
    case 1:
        AddProduct();
        break;
    case 2:
        SortProduct();
        break;
    case 3:
        FilterProduct();
        break;
}

void AddProduct()
{
    string name;
    string description;
    float price;
    string brand;

    Console.WriteLine("Enter Name of Product: ");
    name  = Console.ReadLine();

    Console.WriteLine("Enter Description of Product: ");
    description = Console.ReadLine();

    Console.WriteLine("Enter Price of Product: ");
    price = Convert.ToSingle(Console.ReadLine());

    Console.WriteLine("Enter Brand of Product: ");
    brand = Console.ReadLine();

    using (var dbContext = new MyDbContext())
    {
        dbContext.Products.Add(new Product(name, description, price, brand));

        dbContext.SaveChanges();
    }
}

void SortProduct()
{
    int choice = 0;

    Console.WriteLine("1.By Name\n" +
    "2.By Price\n" +
    "Enter your choice: ");

    choice = Int32.Parse(Console.ReadLine());

    using (var dbContext = new MyDbContext())
    {
        switch (choice)
        {
            case 1:
                var sortedByName = dbContext.Products.OrderBy(p => p.Name);
                break;
            case 2:
                var sortedByPrice = dbContext.Products.OrderBy(p => p.Price);
                break;
        }

        dbContext.SaveChanges();
    }
}

void FilterProduct()
{
    int choice = 0;
    string filter = string.Empty;

    Console.WriteLine("1.By Brand\n" +
    "2.By Price\n" +
    "Enter your choice: ");

    choice = Int32.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.WriteLine("Enter Brand to Filter: ");
            filter = Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("Enter Min Price to Filter: ");
            filter = Console.ReadLine();
            break;
    }

    using (var dbContext = new MyDbContext())
    {
        switch (choice)
        {
            case 1:
                var filteredByBrand = dbContext.Products.Where(p => p.Brand == filter);
                break;
            case 2:
                var filteredByPrice = dbContext.Products.Where(p => p.Price > Convert.ToSingle(filter));
                break;
        }

        dbContext.SaveChanges();
    }
}
