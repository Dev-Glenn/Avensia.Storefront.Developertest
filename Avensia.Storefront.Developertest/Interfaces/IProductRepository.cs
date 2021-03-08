using PagedList;
using System.Collections.Generic;

namespace Avensia.Storefront.Developertest
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetProducts();
    }
}