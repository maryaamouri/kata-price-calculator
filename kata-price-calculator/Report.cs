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
            Console.WriteLine($"Tax = {Product.Tax}%, discount = {Product.UniversalDiscount}%\r\nProgram prints price {product.AppllyDiscount()}\r\nProgram displays {product.GetAmountDeduced()} amount which was deduced");
        }
        public void DisplayWithoutDiscount()
        {
            Console.WriteLine($"Tax = {Product.Tax}%, discount = no discount\r\nProgram prints price {product.Price}\r\nProgram doesn’t show any discounted amount.");
        }
        public void DispalyPrecedence()
        {
            Console.WriteLine($"Tax = {Product.Tax}%, " +
                $"universal discount (after tax) = {Product.UniversalDiscount*100}%\r\n" +
                $"UPC-discount (before tax) = {Product.UPCDiscount}% for UPC={Product.SelectedUpc}\r\n" +
                $"UPC discount amount = {product.UpcDiscountAmount}, remaining price = {product.AppllyDiscount}%\r\n" +
                $"Tax amount = {product.TaxAmount}%\r\n,  universal discount = {Product.UniversalDiscount}" +
                $"Program prints price {product.Price}\r\n" +
                $"Program displays {product.GetAmountDeduced()}");
        }
    }
}
