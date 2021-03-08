using Avensia.Storefront.Developertest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest.Interfaces
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetCurrencies();
        IEnumerable<Currency> GetCurrencies(string currencyCode);
    }
}
