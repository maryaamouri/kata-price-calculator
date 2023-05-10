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
        // case 1
        Product.Tax = 0.2;
        Product.UniversalDiscount = 0.15;
        Product.UPCDiscount = 0.07;
        Product.SelectedUpc = 12345;
        var report1 = new Report(product1);
        report1.Dispaly();
    }
}