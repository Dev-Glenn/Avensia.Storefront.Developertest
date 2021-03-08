using Avensia.Storefront.Developertest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<Currency> GetCurrencies(string currencyCode);
        bool IsCurrencyExist(string currency);
        decimal GetExchangeRates(decimal price, string currency);
    }
}
