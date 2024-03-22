namespace BooksShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required] 
        public string UserId { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public int OrderStatusId { get; set; }

        public bool IsDeleted { get; set; } = false;
        
        public OrderStatus OrderStatus { get; set; } = default!;

        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        
    }
}
