using System;
using System.Collections.Generic;

public class Product
{
    public string Naming { get; private set; }
    public decimal Price { get; private set; }
    public int SelledUnits { get; private set; }
    public DayOfWeek SoldDay { get; private set; }

    public Product(string name, decimal price, int units, DayOfWeek soldDay)
    {
        Naming = name;
        Price = price;
        SelledUnits = units;
        SoldDay = soldDay;
    }

    public decimal GetTotalPrice()
    {
        return Price * SelledUnits;
    }
}

public class ProductManager
{
    private readonly List<Product> products = new List<Product>();

    Random random = new Random();

    public ProductManager()
    {
    }

    public void AddProduct()
    {
        var Name = GetProductNameFromConsole();
        var Units = random.Next(1, 100);
        var Price = Math.Round((decimal)(random.Next(1, 100) + random.NextDouble()), 2);
        var SoldDay = GetRandomDayOfWeek();

        var product = new Product(Name, Price, Units, SoldDay);
        products.Add(product);
    }

    public string GetProductNameFromConsole()
    {
        Console.WriteLine("Enter product name:");
        return Console.ReadLine();
    }

    public DayOfWeek GetRandomDayOfWeek()
    {
        return (DayOfWeek)random.Next(0, 7);
    }

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
                Console.WriteLine($"Name: {product.Naming}, Price: {product.Price}, Units Sold: {product.SelledUnits}, Day Sold: {product.SoldDay}");
            }
        }
    }

    public void DisplaySalesByDay()
    {
        decimal[] weeklySales = new decimal[7];

        foreach (var product in products)
        {
            weeklySales[(int)product.SoldDay] += product.GetTotalPrice();
        }

        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine($"{(DayOfWeek)i}: {weeklySales[i]:C}");
        }
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

        Console.WriteLine("Displaying sales by day:");
        manager.DisplaySalesByDay();
    }
}
