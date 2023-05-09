using kata_price_calculator;
﻿using System.Diagnostics;
using System.Net.Http.Headers;
using System.Security.Cryptography;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello Kata!");
        Product product1 = new Product("The Little Prince", 12345, 20.25);
        Report report1 = new Report(product1);
        report1.DisplayWithDiscount();


    }
}