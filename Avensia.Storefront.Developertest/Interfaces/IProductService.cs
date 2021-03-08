using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        IPagedList<ProductDto> GetProducts(int start, int pageSize);
    }
}
