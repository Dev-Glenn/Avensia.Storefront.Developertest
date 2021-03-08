using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.Models;
using System;
using System.Linq;

namespace Avensia.Storefront.Developertest
{
    public class ProductListVisualizer
    {
        private readonly IProductService _productService;
        private readonly ICurrencyService _currencyService;
        private string selectedCurrency;

        public ProductListVisualizer(IProductService productService, ICurrencyService currencyService)
        {
            _productService = productService;
            _currencyService = currencyService;
        }

        public string SelectedCurrency
        {
            get { return selectedCurrency; }
            set { selectedCurrency = value; }
        }


        public void OutputAllProduct()
        {
            var products = _productService.GetProducts();
            
            foreach (var product in products)
            {
                var convertedPrice = _currencyService.GetExchangeRates(product.Price, SelectedCurrency);
                Console.WriteLine($"{product.Id}\t{product.Name}\t{convertedPrice} {selectedCurrency}");
            }
        }

        public void OutputPaginatedProducts(int? start, int? pageSize)
        {
            var products = _productService.GetProducts(start ?? 1, pageSize ?? 5);
            foreach (var product in products)
            {
                var convertedPrice = _currencyService.GetExchangeRates(product.Price, SelectedCurrency);
                Console.WriteLine($"{product.Id}\t{product.Name}\t{convertedPrice} {selectedCurrency}");
            }
            Console.WriteLine($"Showing {products.PageNumber} of {products.PageCount} Pages");
            Console.WriteLine("\n");
            Console.WriteLine($"Enter Page Number ( 1 - {products.PageCount}) (0 - Back): ");

            var input = Console.ReadLine();
            int page = -1;
            if (!int.TryParse(input, out page))
            {
                Console.WriteLine("Not a valid input!");
                return;
            }

            if (page == 0) { return; }

            if (page < 1 || page > products.PageCount)
            {
                Console.WriteLine("Not a valid input!");
                return;
            }

            OutputPaginatedProducts(page, 5);
            Console.WriteLine("\n");
        }

        public void OutputProductGroupedByPriceSegment()
        {
            var products = _productService.GetProducts().OrderBy(x => x.Price);

            foreach (var product in products)
            {
                product.Price = _currencyService.GetExchangeRates(product.Price, SelectedCurrency);

                decimal round = Convert.ToInt32(Math.Floor(product.Price / 100.0M) * 100.0M);
                var priceGroup = $"{round} - { (round + 100)}";
                product.Ranges = priceGroup;
            }

            var groupProducts = products.GroupBy(x => x.Ranges);

            foreach (var productsList in groupProducts)
            {
                Console.WriteLine($"{productsList.Key} {selectedCurrency}");
                foreach (var product in productsList)
                {
                    Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Price} {selectedCurrency}");
                }
                Console.WriteLine($"\n");
            }
        }

        public void OutputChangeCurrency(string newCurrency)
        {
            if (_currencyService.IsCurrencyExist(newCurrency))
            {
                selectedCurrency = newCurrency;
                Console.WriteLine("Currency has been successfully changed.");
            }
            else
            {
                Console.WriteLine("Currency not supported.");
            }
        }

        public void OutputExchangeRates(string day)
        {
            if (day == "YESTERDAY")
            {
                Console.WriteLine("Currency Code \t\t Exchange Rate");
                var currencyList = _currencyService.GetCurrencies();

                foreach (var currency in currencyList)
                {
                    Console.WriteLine($"{currency.CurrencyCode} \t\t\t {currency.ExchangeRate}");
                }
                Console.WriteLine("\n");
            }
            else if (day == "TODAY")
            {
                throw new NotImplementedException();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}