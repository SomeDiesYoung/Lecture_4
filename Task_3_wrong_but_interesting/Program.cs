using System;
using System.Collections.Generic;
using System.Threading.Channels;

public class Product
{
    public string Naming { get; private set; }
    public decimal Price { get; private set; }
    public int SelledUnits { get; private set; }

    public Product(string name, decimal price, int units)
    {
        Naming = name;
        Price = price;
        SelledUnits = units;
    }    
}

public class ProductManager
{
    private readonly List<Product> products = new List<Product>();

    public ProductManager() { }

    public void AddProduct()
    {
        var Name = GetProductNameFromConsole();
        var Units = GetProductSelledUnitFromConsole();
        var Price = GetProductPriceFromConsole();

        var product = new Product(Name, Price, Units);
        products.Add(product);
    }

    Random random = new Random();

    public void DisplayProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products added.");
        }
        else
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Naming}, Price: {product.Price}, Units Sold: {product.SelledUnits} ,Selling Day :{GetDayOfTheWeek().DayOfWeek}");
            }
        }
    }

    public string GetProductNameFromConsole()
    {
        Console.WriteLine("Enter product name:");
        return Console.ReadLine();
    }

    public int GetProductSelledUnitFromConsole()
    {
        while (true)
        {
            Console.WriteLine("Enter the number of units sold:");
            if (int.TryParse(Console.ReadLine(), out int unit))
            {
                return unit;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public decimal GetProductPriceFromConsole()
    {
        while (true)
        {
            Console.WriteLine("Enter product price:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                return price;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid price.");
            }
        }
    }

   
    public DateTime GetDayOfTheWeek() {
        int i = random.Next(1,31);
        DateTime dateValue = new DateTime(2008, 6,  i);
        return dateValue;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductManager manager = new ProductManager();

        while (true)
        {
            manager.AddProduct();
            Console.WriteLine("Do you want to add another product? (Yes/No)");

            string response = Console.ReadLine().ToLower();
            if (response != "yes" && response != "y")
            {
                break;
            }
        }

        Console.WriteLine("Displaying all products:");
        manager.DisplayProducts();
    }
}





