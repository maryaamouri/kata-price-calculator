using kata_price_calculator;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
internal class Product
{
    public double _discountAmount=0;
    public double _taxAmount=0;
    public bool _isUpcDiscountAppllied=false;
    public Product(string Name, int Upc, double Price)
    {
        this.Name = Name;
        this.Upc = Upc;
        this.Price = Price;
    }
    public string Name { get; set; }
    public int Upc { get; set;}
    public double Price { set; get; }
    public static double Tax { get; set; } = 0.2;
    public static double UniversalDiscount { get; set; } = 0.15;
    public static double UPCDiscount { get; set; } = 0.07;
    public static int SelectedUpc { set; get; } = 12345;
    public bool IsUniversalDiscountAppllied { set; get; } = true;

    public bool IsUpcDiscountAppllied
    {
        private set
        {
            if (Upc == SelectedUpc)
                _isUpcDiscountAppllied = true;
            else _isUpcDiscountAppllied = false;
        }
        get => _isUpcDiscountAppllied;
    }
    public double UniversalDiscountAmount(double price) => price * UniversalDiscount;
    public double UpcDiscountAmount(double price) => price * UPCDiscount;
    public double TaxAmount(double price) => price *Tax;
    public Expense Transport { set; get; } = null;
    public Expense Administrative { set; get; } = null;
    public Expense Packaging { set; get; } = null;

    public void AddTransport(string description, double amount)
    {
        Transport = new Expense(description, amount);
    }
    public void AddAdministrative(string description, double amount)
    {
        Administrative = new Expense(description, amount);
    }
    public void AddPackaging(string description, double amount)
    {
        Packaging = new Expense(description, amount);
    }
    public double AppllyDiscounts()
    {
        double discountamount = 0;
        if (IsUniversalDiscountAppllied)
            discountamount = UniversalDiscountAmount(Price);
        if (IsUpcDiscountAppllied)
            discountamount += UpcDiscountAmount(Price);
        double price = Price + TaxAmount(Price - discountamount);
        if (Packaging != null)
            price += Packaging.Amount;
        if (Transport != null)
            price += Transport.Amount;
        if (Administrative != null)
            price += Administrative.Amount;
        return price;
    }
    public double AppllyUpcDiscountAfterTax()
    {
        double price = Price;
        if (IsUpcDiscountAppllied)
            price = Price - UpcDiscountAmount(Price);
        price += TaxAmount(price);
        if (IsUniversalDiscountAppllied)
            price -= UniversalDiscountAmount(price);

        if (Packaging != null)
            price += Packaging.Amount;
        if (Transport != null)
            price += Transport.Amount;
        if (Administrative != null)
            price += Administrative.Amount;

        return price;
    }

}