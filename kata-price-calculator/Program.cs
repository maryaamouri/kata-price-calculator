using kata_price_calculator;
﻿using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Kata!");
        var product1 = new Product("The Little Prince", 12345, 20.25);
        Console.WriteLine("Case#1");
        Product.Tax = 0.21;
        Product.UniversalDiscount = 0.15;
        Product.UPCDiscount = 0.07;
        Product.SelectedUpc = 12345;
        product1.AddPackaging("packgin", 2.2);
        product1.AddTransport("transport", 0.2);
        var report1 = new Report(product1) ;
        
        Console.WriteLine("Case#2");
        var product2 = new Product("The Big Prince", 700, 20.25);
        product2.IsUniversalDiscountAppllied = false;
        var report2 = new Report(product2) ;
        report1.Dispaly();
        report2.Dispaly();
    }
}