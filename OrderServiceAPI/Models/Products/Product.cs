using System.ComponentModel.DataAnnotations;

namespace OrderServiceAPI.Models.Products
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
    }
}
