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
    public double UniversalDiscountAmount(double price) => price * UniversalDiscount;
    public double UpcDiscountAmount(double price) => price * UPCDiscount;
    public static int SelectedUpc { set; get; } = 12345;
    public double TaxAmount(double price) => price *Tax;
    public double AppllyDiscountBeforeTax()
    {
        double discountamount = 0;
        if (IsUniversalDiscountAppllied)
            discountamount = UniversalDiscountAmount(Price);
        if (IsUpcDiscountAppllied)
            discountamount += UpcDiscountAmount(Price);
        double price = Price + TaxAmount(Price - discountamount);
        return price;
    }
    public bool IsUniversalDiscountAppllied { set; get; }
    public bool IsUpcDiscountAppllied
    {
        private set {
            if (Upc == SelectedUpc)
                _isUpcDiscountAppllied = true;
            else _isUpcDiscountAppllied = false;
        }
        get => _isUpcDiscountAppllied;
    }
    public double GetAmountDeduced()
    {
        return Math.Round(UniversalDiscountAmount + UpcDiscountAmount, 2);
    }
}