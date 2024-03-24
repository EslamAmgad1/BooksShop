namespace BooksShop.Models
{
    public class CartDetails
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public int ShoppingCartId {  get; set; }

        public Book Book { get; set; } = default!;

        public ShoppingCart ShoppingCart { get; set; } = default!;

    }
}
