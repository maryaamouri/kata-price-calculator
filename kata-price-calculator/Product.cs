internal class Product
{
    public Product(string Name, int Upc, float Price)
    {
        this.Name = Name;
        this.Upc = Upc;
        this.Price = Price;
        Tax = (float)0.2;
    }

    public  string Name { get;  set; }
    public  int Upc { get;  set; }
    public  float Price { get;  set; }
    public static float  Tax { private set; get; } 
    private float AddTax(float Price)
    {
        return (float)(Price +(Price /Tax));
    }
}