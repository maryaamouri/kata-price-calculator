using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

internal class Product
{
    public Product(string Name, int Upc, double Price)
    {
        this.Name = Name;
        this.Upc = Upc;
        this.Price = Price;

    }

    public string Name { get; set; }
    public int Upc { get; set; }
    public double Price
    {
        set =>_price = value;
        get
        {
            return AddTax(_price);
        }
    }
    public double GetAmountDeduced()
    {
        return Math.Round(_price-AppllyDiscount(), 2); ;
    }
  
    static double _tax = 0.2;
    static double _universalDiscount = 0.15;
    double _price;
    static double _upcDiscount = 0.07;
    static int _selectedUpc = 12345;
    public double _discountAmount;
    public double _taxAmount;

    public static double Tax
    {   get => _tax;
        set => _tax = value;
    }
    public static double UniversalDiscount
    {

        get => _tax;

        set => _tax = value;

    }
    public static double Discount
    {

        get => _discount;

        set => _discount = value;

    }
    public double TaxAmount
    {
        get =>  _price * Tax;
    }
    public double AppllyDiscount()
    {
        double discountedValue = _price * _discount;
        return AddTax(_price - discountedValue);
    }
}