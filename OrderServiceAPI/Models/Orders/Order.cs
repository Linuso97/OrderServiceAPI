using OrderServiceAPI.Models.Customers;
using System.Text.Json.Serialization;

namespace OrderServiceAPI.Models.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; } = 0;
    }
}
