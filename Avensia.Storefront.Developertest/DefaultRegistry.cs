using Avensia.Storefront.Developertest.Interfaces;
using Avensia.Storefront.Developertest.Services;
using StructureMap;

namespace Avensia.Storefront.Developertest
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ProductListVisualizer>().Use<ProductListVisualizer>();
            For<IProductRepository>().Use<ProductRepository>();
            For<ICurrencyRepository>().Use<CurrencyRepository>();
            For<IProductService>().Use<ProductService>();
            For<ICurrencyService>().Use<CurrencyService>();
        }
    }
}