namespace BooksShop.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string StatusName { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
