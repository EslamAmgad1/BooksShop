namespace BooksShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int OrderStatusId { get; set; }

        public bool IsDeleted { get; set; } = false;
        
        public OrderStatus OrderStatus { get; set; } = default!;

        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        
    }
}
