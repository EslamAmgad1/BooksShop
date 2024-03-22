namespace BooksShop.Models
{
    public class CartDetails
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required] 
        public int ShoppingCartId {  get; set; }

        public Book Book { get; set; } = default!;

        public ShoppingCart ShoppingCart { get; set; } = default!;

    }
}
