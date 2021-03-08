using Avensia.Storefront.Developertest.Models;
using Avensia.Storefront.Developertest.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Caching;
using PagedList;

namespace Avensia.Storefront.Developertest
{
    public class ProductRepository : IProductRepository
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "products.json");
        private const string CacheKey = "jsonProducts";


        public IEnumerable<ProductDto> GetProductsFromFile() 
        {
            ObjectCache cache = MemoryCache.Default;

            if (cache.Contains(CacheKey))
            {
                return (IList<ProductDto>)cache.Get(CacheKey);
            }
            else 
            {
                CacheItemPolicy policy = new CacheItemPolicy
                {
                    //5 minutes cache memory expiration
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                };

                List<string> filePaths = new List<string>();
                    string cachedFilePath = filePath;

                filePaths.Add(cachedFilePath);

                policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));

                // Fetch the file contents.
                var jsonStr = string.Empty;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    jsonStr = sr.ReadToEnd();
                }

                var products = JsonConvert.DeserializeObject<IList<ProductDto>>(jsonStr);
                cache.Set("jsonProducts", products, policy);

                return products;
            }
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = GetProductsFromFile();
            return products;
        }

    }
}