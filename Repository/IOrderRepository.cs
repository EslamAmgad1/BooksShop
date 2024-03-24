namespace BooksShop.Repository
{
    public interface IOrderRepository
    {
        public Task<bool> Create();
        public Task<IEnumerable<Order>> GetAllUserOrdersWithDetails();
    }
}
