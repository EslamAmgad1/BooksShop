namespace BooksShop.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required] 
        public int OrderId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public Order Order { get; set; } = default!;

        public Book Book { get; set; } = default!;

    }
}
