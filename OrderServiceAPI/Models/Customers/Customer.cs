using System.ComponentModel.DataAnnotations;

namespace OrderServiceAPI.Models.Customers
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
