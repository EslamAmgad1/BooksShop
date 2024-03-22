namespace BooksShop.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderRepository(ApplicationDbContext context, ICartRepository cartRepository, IHttpContextAccessor contextAccessor, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _cartRepository = cartRepository;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<bool> Create()
        {
            var userCart = await _cartRepository.GetUserCartWithDetails();
            if (userCart is null)
            {
                return false;
            }
            using var Transaction = _context.Database.BeginTransaction();
            try 
            {
                var order = new Order
                {
                    UserId = userCart.UserId,
                    CreatedDate = DateTime.UtcNow,
                    OrderStatusId = 1,
                    OrderDetails = userCart.CartDetails.Select(cd => new OrderDetails
                    {
                        BookId = cd.BookId,
                        Quantity = cd.Quantity,
                        UnitPrice = cd.UnitPrice,
                    }).ToList()
                };
                _context.Add(order);
                _context.SaveChanges();
                _cartRepository.DeleteCart(userCart);
                Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<Order> GetAllUserOrdersWithDetails()
        {
            var userId = GetUserId() ?? throw new Exception("User is not Logined");
            var orders = _context.Orders
                                 .Include(o=>o.OrderStatus)
                                 .Include(o=>o.OrderDetails)
                                 .ThenInclude(od=>od.Book)
                                 .ThenInclude(b=>b.Genre)
                                 .Where(o=> o.UserId == userId).AsNoTracking().ToList();
            return orders;

        }
        private string? GetUserId()
        {
            var principal = _contextAccessor.HttpContext!.User;
            string userId = _userManager.GetUserId(principal)!;
            return userId;
        }
    }
}
