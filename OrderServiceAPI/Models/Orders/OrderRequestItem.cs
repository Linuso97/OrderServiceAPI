using OrderServiceAPI.Models.Products;
using System.Text.Json.Serialization;

namespace OrderServiceAPI.Models.Orders
{
    public class OrderRequestItem
    {
        [JsonIgnore]
        public int OrderRequestItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public int OrderRequestId { get; set; }
    }
}
