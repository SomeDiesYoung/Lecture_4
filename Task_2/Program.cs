

public class Product {
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public int Quantity { get; private set; }

    public Product(string name, decimal price, int quantity) { 
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalPriceOfOneTypeUnits()
    {
        return Price*Quantity;
    }

}

public class ProductManager
{
    private readonly List<Product> products = new List<Product>();

    public void AddProduct()
    {
        Random random = new Random();
        var Name = GetProductNameFromConsole();
        var Price = Math.Round((decimal)random.NextDouble() * (15.5m),2);
        var Quantity = random.Next(0, 250);


        var product = new Product(Name, Price, Quantity);
        products.Add(product);
    }
    private string GetProductNameFromConsole()
    {
        Console.WriteLine("Sheiyvanet Productis dasaxeleba:");
        return Console.ReadLine();
    }


    public void DisplayProducts()
    {
        foreach (var product in products)
        {
            Console.WriteLine($"Productis dasaxeleba : {product.Name} ,\n" +
                $" Productis Fasi : {product.Price}\n" +
                $" Productis Raodenoba : {product.Quantity} ,\n" +
                $" Total Price Of All Units : {product.GetTotalPriceOfOneTypeUnits()}\n");
            
        }
        Console.WriteLine($"Yvela Productis Saerto Fasia {GetTotalPriceOfAllTypesUnits()}");
    }

    public decimal GetTotalPriceOfAllTypesUnits()
    {
        decimal sum = 0;
        foreach (var product in products)
        {
            sum += product.Price * product.Quantity;
        }
        return sum;
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
            Console.WriteLine("Gsurt Productis damateba? (Yes/No)");

            string response = Console.ReadLine().ToLower();
            if (response != "yes" && response != "y")
            {
                break;
            }
        }
        manager.DisplayProducts();
    }
}
