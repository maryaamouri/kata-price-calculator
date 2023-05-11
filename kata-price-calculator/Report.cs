using System.Xml.Schema;

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
            var _cost = product.Price;
            var _taxAmount = Math.Round(product.TaxAmount(_cost), 2);
            var _upcDiscountAmount = Math.Round(product.UpcDiscountAmount(_cost), 2);
            var _universalDiscountAmount = Math.Round(product.UniversalDiscountAmount(_cost), 2);
            var _discounts = _universalDiscountAmount + _upcDiscountAmount;
            var _addtionalCosts =0.0;

            var productInfo = $"Title = {product.Name}, UPC = {product.Upc}, Price = {product.Price}";
            var taxReport = $"Tax = {_taxAmount}";
            var discountReport ="";
            var addtionalCostsReport ="";

            if (!product._isUpcDiscountAppllied && !product.IsUniversalDiscountAppllied)
                discountReport += "no discounts";
            else  discountReport = $"discount = {_discounts}";

            if(product.Transport != null)
            {
                addtionalCostsReport += $"Transport = {product.Transport.Amount} \n";
                _addtionalCosts = _addtionalCosts+product.Transport.Amount;
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

            var _finalPrice = Math.Round(_cost + _taxAmount - _discounts+_addtionalCosts, 2);

            Console.WriteLine(
                productInfo+"\n" + 
                taxReport+"\n"+
                discountReport+"\n"+
                addtionalCostsReport+
                $"TOTAL = {_finalPrice}" );
        }
    }
}
