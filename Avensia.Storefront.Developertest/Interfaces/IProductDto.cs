using Newtonsoft.Json;

namespace Avensia.Storefront.Developertest
{
    public interface IProductDto
    {
         string Id { get; set; }
        [JsonProperty("ProductName")]
         string Name { get; set; }
         string CategoryId { get; set; }
         decimal Price { get; set; }
    }
}