using ECommerceApp;

internal class Program
{
    public static void Main(string[] args)
    {
        var product = new Product(100, "Laptop", 1000, 10);
        Console.WriteLine(product);
    }
}