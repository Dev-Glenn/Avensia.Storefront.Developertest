using Avensia.Storefront.Developertest.Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avensia.Storefront.Developertest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _productRepository.GetProducts();
            return products;
        }

        public IPagedList<ProductDto> GetProducts(int start, int pageSize)
        {
            var products = _productRepository.GetProducts();
            var pagedProducts = products.ToPagedList(start, 5);
            return pagedProducts;
        }
    }
}
