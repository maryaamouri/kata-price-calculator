namespace kata_price_calculator
{
    internal class Report
    {
        Product product;

        public Report(Product product)
        {
            this.product = product;
        }
        public void Dispaly()
        {
            double _universalDiscount = Math.Round(Product.UniversalDiscount * 100, 2);
            double _upcDiscount= Math.Round(Product.UPCDiscount * 100, 2);
            double _upcDiscountAmount = Math.Round(product.UpcDiscountAmount(product.Price), 2);
            double _remainingPrice = Math.Round(product.Price,2)- _upcDiscountAmount;
            double _taxAmount = Math.Round(product.TaxAmount(_remainingPrice), 2);
            double _universalDiscountAmount = Math.Round(product.UniversalDiscountAmount(_remainingPrice), 2);
            double _finalPrice =Math.Round(product.Price-_upcDiscountAmount+_taxAmount-_universalDiscountAmount,2);

            string productInfo = $"Title = {product.Name}, UPC = {product.Upc}";
            string taxReport = $"Tax = {Product.Tax*100}%, ";
            string uniDiscountReport = $"universal discount (after tax) = {_universalDiscount}%, ";
            string upcDiscountReport = $"UPC-discount (before tax) = {_upcDiscount}% for UPC={product.Upc}";
            string priceReport = $"UPC discount amount = ${_upcDiscountAmount}," +
                $" remaining price = {_remainingPrice}\n" +
                $"Tax amount = {_taxAmount}" +
                $" universal discount amount= {_universalDiscountAmount}\n" +
                $"Final price = {_finalPrice}";

            Console.WriteLine(
                productInfo+"\n" + 
                taxReport+
                uniDiscountReport+"\n"+
                upcDiscountReport + "\n" +
                priceReport);
        }
    }
}
