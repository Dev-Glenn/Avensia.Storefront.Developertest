using Newtonsoft.Json;

namespace Avensia.Storefront.Developertest
{
    public class ProductDto : IProductDto
    {
        public string Id { get; set; }
        [JsonProperty("ProductName")]
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Ranges { get; set; }
    }
}