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
        set { 
            double priceWithDiscount = AppllyDiscount(value);
            double priceWithTax = AddTax(priceWithDiscount); 
            double roundedValue = Math.Round(priceWithTax, 2); 
            _price = roundedValue;
            }
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
        double addedValue = price / Tax;
        return price + addedValue;
    }

    private double AppllyDiscount(double price)
    {
        double discountedValue = price * Discount;
        return price - discountedValue;
    }
}