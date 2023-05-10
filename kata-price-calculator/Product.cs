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
    public int Upc { get; set;
    }
    public double Price
    {
        set => _price = value;
        get => AddTax(_price);
    }
    public static double Tax { get; set; } = 0.2;
    public static double UniversalDiscount { get; set; } = 0.15;
    public static double UPCDiscount { get; set; } = 0.07;
    public double UniversalDiscountAmount => _price * UniversalDiscount;
    public double UpcDiscountAmount => _price * UPCDiscount;
    public static int SelectedUpc { set; get; } = 12345;
    private double AddTax(double price) => price + TaxAmount;
    public double AppllyDiscount()
    {
        double discountamount = 0;
        if (IsUniversalDiscountAppllied)
            discountamount = UniversalDiscountAmount;
        if(IsUpcDiscountAppllied)
            discountamount += UpcDiscountAmount;
        double price = AddTax(_price - discountamount);
        return Math.Round(price, 2); ;
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