using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            var currencies = _currencyRepository.GetCurrencies();
            return currencies;
        }

        public IEnumerable<Currency> GetCurrencies(string currencyCode)
        {
            var selectedCurrency = _currencyRepository.GetCurrencies(currencyCode);
            return selectedCurrency;
        }

        public decimal GetExchangeRates(decimal price, string currency)
        {
            var selectedCurrency = GetCurrency(currency);
            if (selectedCurrency == null)
            {
                return price;
            }
            return price * selectedCurrency.ExchangeRate;
        }

        private Currency GetCurrency(string currency)
        {
            var currencyList = _currencyRepository.GetCurrencies();
            return currencyList.FirstOrDefault(curr => curr.CurrencyCode == currency);
        }

        public bool IsCurrencyExist(string currency)
        {
            var currencies = _currencyRepository.GetCurrencies();
            var selectedCurrency = currencies.FirstOrDefault(c => c.CurrencyCode == currency);
            
            return selectedCurrency != null ? true : false;
        }
    }
}
