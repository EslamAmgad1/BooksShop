namespace BooksShop.Repository
{
    public interface ICartRepository
    {
        public Task<int> AddItem(int bookId);
        public Task<bool> RemoveItem(int bookId);

        public Task<ShoppingCart?> GetUserCart(string userId);

        public Task<ShoppingCart?> GetUserCartWithDetails();

        public Task<int> GetUserCartItemsCount(string? userId = "");

        public void DeleteCart(ShoppingCart cart);
    }
}
