internal class Product
{
    public Product(string Name, int Upc, double Price)
    {
        this.Name = Name;
        this.Upc = Upc;
        this.Price = Price;
        Tax = 0.2;
    }

    public  string Name { get;  set; }
    public  int Upc { get;  set; }
    public double Price { get;  set; }
    public static double Tax { private set; get; } 
    private double AddTax(double Price)
    {
        double addedValue = Price / Tax;
        return Price + addedValue;
    }
}