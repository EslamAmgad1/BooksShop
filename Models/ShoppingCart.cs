namespace BooksShop.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public ICollection<CartDetails> CartDetails { get; set; } = new List<CartDetails>();
    }
}
