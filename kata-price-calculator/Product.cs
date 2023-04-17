internal class Product
{
    public Product(string Name, int Upc, float Price)
    {
        this.Name = Name;
        this.Upc = Upc;
        this.Price = Price;
    }

    public  string Name { get;  set; }
    public  int Upc { get;  set; }
    public  float Price { get;  set; }
}