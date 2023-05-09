using System.Diagnostics;
using System.Net.Http.Headers;

internal class Program
{


    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Kata!");
        Product product1 = new Product("The Little Prince", 12345, 20.25);
        Console.WriteLine($"the price with applying discount and adding tax is = {product1.Price.ToString()}");
    }
}