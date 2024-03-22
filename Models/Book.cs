namespace BooksShop.Models
{
    public class Book
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string BookName { get; set; } = string.Empty;

        [MaxLength(40)]
        public string? AuthorName { get; set; }

        [Required]  
        public double Price { get; set; }

        public string? Image {  get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; } = default!;

        public ICollection<CartDetails> CartDetails { get; set; } = new List<CartDetails>();
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
