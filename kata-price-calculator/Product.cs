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
        get {
            double priceWithTax = AddTax(_price);
            double roundedValue = Math.Round(priceWithTax, 2);
            return roundedValue; 
        }
        set =>_price = value;
    }
    static double _tax = 0.2;
    public static double Tax
    {

        get => _tax;

        set => _tax = value;

    }
    private double AddTax(double Price)
    {
        double addedValue = Price * _tax;
        return Price + addedValue;
    }
}