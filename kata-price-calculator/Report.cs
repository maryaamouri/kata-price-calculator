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
            double _cost = product.Price;
            double _taxAmount = Math.Round(product.TaxAmount(_cost), 2);
            double _upcDiscountAmount = Math.Round(product.UpcDiscountAmount(_cost), 2);
            double _universalDiscountAmount = Math.Round(product.UniversalDiscountAmount(_cost), 2);
            double _discounts = _universalDiscountAmount + _upcDiscountAmount;
            double _addtionalCosts =0;
            double _finalPrice = Math.Round(_cost + _taxAmount - _discounts, 2);

            string productInfo = $"Title = {product.Name}, UPC = {product.Upc}, Price = {product.Price}";
            string taxReport = $"Tax = {_taxAmount}";
            string discountReport="";
            string addtionalCostsReport="";

            if (!product._isUpcDiscountAppllied && !product.IsUniversalDiscountAppllied)
                discountReport += "no discounts";
            else  discountReport = $"discount = {_discounts}";

            if(product.Transport != null)
            {
                addtionalCostsReport += $"Transport = {product.Transport.Amount} \n";
                _addtionalCosts += product.Transport.Amount;
            }
            if (product.Administrative != null)
            {
                addtionalCostsReport += $"Administrative = {product.Administrative.Amount}\n";
                _addtionalCosts += product.Administrative.Amount;
            }
            if (product.Packaging != null)
            {
                addtionalCostsReport += $"Packaging = {product.Packaging.Amount}\n";
                _addtionalCosts += product.Packaging.Amount;
            }
            else if(product.Transport == null &&
                product.Administrative != null&&
                product.Packaging != null)
                addtionalCostsReport = "no addtional costs";

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
