internal class Product
{
    public Product(string Name, int Upc, double Price)
    {
        this.Name = Name;
        this.Upc = Upc;
        this.Price = Price;
        Tax = 0.2;
    }


    static double _tax = 0.2;
    public static double Tax
    {

        get => _tax;

        set => _tax = value;

    }
    private double AddTax(double Price)
    {
        double addedValue = Price / Tax;
        return Price + addedValue;
    }
}