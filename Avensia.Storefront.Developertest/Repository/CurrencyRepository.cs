using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public IEnumerable<Currency> GetCurrencies()
        {
            var currencyList = new List<Currency> {
                new Currency { CurrencyCode = "USD", ExchangeRate = 1.0M },
                new Currency { CurrencyCode = "GBP", ExchangeRate = 0.71M },
                new Currency { CurrencyCode = "SEK", ExchangeRate = 8.38M },
                new Currency { CurrencyCode = "DKK", ExchangeRate = 6.06M },
            };

            return currencyList;
        }

        public IEnumerable<Currency> GetCurrencies(string currencyCode)
        {
            var currencyList = new List<Currency> {
                new Currency { CurrencyCode = "USD", ExchangeRate = 1.0M },
                new Currency { CurrencyCode = "GBP", ExchangeRate = 0.71M },
                new Currency { CurrencyCode = "SEK", ExchangeRate = 8.38M },
                new Currency { CurrencyCode = "DKK", ExchangeRate = 6.06M },
            };

            var selectedCurrency = currencyList.FirstOrDefault(c => c.CurrencyCode == currencyCode);
            yield return selectedCurrency;
        }
    }
}
