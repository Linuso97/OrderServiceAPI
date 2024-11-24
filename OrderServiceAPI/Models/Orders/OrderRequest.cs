using OrderServiceAPI.Models.Customers;
using System.Text.Json.Serialization;

namespace OrderServiceAPI.Models.Orders
{
    public class OrderRequest
    {
        [JsonIgnore]
        public int OrderRequestId { get; set; }
        public int CustomerId { get; set; }
        public List<OrderRequestItem> Items { get; set; }
    }
}
