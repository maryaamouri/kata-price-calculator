namespace kata_price_calculator
{
    internal class Report
    {
        Product product;

        public Report(Product product)
        {
            this.product = product;
        }

 

        public void DisplayWithDiscount()
        {
            Console.WriteLine($"Tax = {Product.Tax}%, discount = {Product.Discount}%\r\nProgram prints price {product.GetPriceWithDiscount()}\r\nProgram displays {product.GetAmountDeduced()} amount which was deduced");
        }
        public void DisplayWithoutDiscount()
        {
            Console.WriteLine($"Tax = {Product.Tax}%, discount = no discount%\r\nProgram prints price {product.GetPriceWithoutDiscount()}\r\nProgram doesn’t show any discounted amount.");
        }
    }
}
