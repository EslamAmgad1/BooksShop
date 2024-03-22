namespace BooksShop.Repository
{
    public interface IOrderRepository
    {
        public Task<bool> Create();
        public IEnumerable<Order> GetAllUserOrdersWithDetails();
    }
}