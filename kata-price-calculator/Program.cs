using System.Diagnostics;
using System.Net.Http.Headers;

internal class Program
{


    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Kata!");
        Console.WriteLine("test case1: tax 20%");
        Product product1 = new Product("The Little Prince", 12345, 20.25);
        Console.WriteLine($"the price with tax is = {product1.Price.ToString()}");
        Console.WriteLine("test case2: tax 21%");
        Product.Tax = 0.21;
        Console.WriteLine($"the price with tax is = {product1.Price.ToString()}");

    }
}