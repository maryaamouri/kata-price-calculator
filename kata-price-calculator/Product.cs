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
    double _price;
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
    static double _discount = 0.15;
    public static double Tax
    {

        get => _tax;

        set => _tax = value;

    }
    public static double Discount
    {

        get => _discount;

        set => _discount = value;

    }
    private double AddTax(double price)
    {
        double addedValue = price * Tax;
        double roundedValue = Math.Round(price + addedValue, 2);
        return roundedValue;
    }

    public double AppllyDiscount()
    {
        double discountedValue = _price * _discount;
        return AddTax(_price - discountedValue);
    }
}