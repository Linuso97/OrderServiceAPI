using OrderServiceAPI.Models.Customers;

namespace OrderServiceAPI.Models.Orders
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
