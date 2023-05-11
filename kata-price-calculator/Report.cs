using System.Xml.Schema;

namespace kata_price_calculator
{
     
    internal class Report
    {
        Product product;
        int _roundationDigits =2;
        public Report(Product product)
        {
            this.product = product;
        }
        public void Dispaly()
        {
            var _cost = product.Price;
            var _finalPrice = Math.Round(product.CalculatePrice(), _roundationDigits);

            Console.WriteLine(
                GenerateProductInfoReport() + "\n" +
                GenerateTaxReport(_cost) + "\n" +
                GenerateDiscountReport(_cost) + "\n" +
                GenerateExpensesReport () +
                $"TOTAL = {_finalPrice}");
        }
        private string GenerateProductInfoReport()
        {
            var productInfo = $"Title = {product.Name}," +
                $" UPC = {product.Upc}," +
                $" Price = {product.Price}";
            return productInfo ;
        }
        private string GenerateTaxReport(double _cost)
        {
            var _taxAmount = Math.Round(product.TaxAmount(_cost), _roundationDigits);
            var taxReport = $"Tax = {_taxAmount}";
            return taxReport;
        }
        private string GenerateDiscountReport(double _cost)
        {
            var _upcDiscountAmount = Math.Round(product.UpcDiscountAmount(_cost), _roundationDigits);
            var _universalDiscountAmount = Math.Round(product.UniversalDiscountAmount(_cost), _roundationDigits);
            var _discounts = _universalDiscountAmount + _upcDiscountAmount;
            var discountReport = "";
            
            if (!product._isUpcDiscountAppllied && !product.IsUniversalDiscountAppllied)
                discountReport += "no discounts";
            else discountReport = $"discount = {_discounts}";
            return discountReport;
        }
        private string GenerateExpensesReport()
        {
            var addtionalCostsReport = "";
            var _addtionalCosts = 0.0;
            if (product.Transport != null)
            {
                addtionalCostsReport += $"Transport = {product.Transport.Amount} \n";
                _addtionalCosts = _addtionalCosts + product.Transport.Amount;
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
            else if (product.Transport == null &&
                product.Administrative != null &&
                product.Packaging != null)
                addtionalCostsReport = "no addtional costs";

            return addtionalCostsReport;
        }

    }
}
