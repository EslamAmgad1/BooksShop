namespace BooksShop.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        public CartRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager , IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> AddItem(int bookId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                string? userId = GetUserId();
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("user is not logged-in");
                var cart = await GetUserCart(userId);
                if (cart is null)
                {
                    cart = new ShoppingCart() { UserId = userId };
                    _context.Add(cart);
                    _context.SaveChanges();
                }
                var cartDetails = _context.CartsDetails
                                          .FirstOrDefault(c => c.BookId == bookId && c.ShoppingCartId == cart.Id);
                if (cartDetails is null)
                {
                    var book = _context.Books.Find(bookId);
                    if (book is null)
                        throw new Exception("Invalid Book");
                    else { 
                        cartDetails = new()
                        {
                            BookId = bookId,
                            Quantity = 1,
                            ShoppingCartId = cart.Id,
                            UnitPrice = book.Price
                        };
                    _context.Add(cartDetails);
                    }
                }
                else
                {
                    cartDetails.Quantity = cartDetails.Quantity + 1;
                }
                _context.SaveChanges();
                transaction.Commit();
                var cartItemCount = await GetUserCartItemsCount(userId);
                return cartItemCount;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> RemoveItem(int bookId)
        {
            string? userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return false;
            var cart = await GetUserCart(userId);
            if (cart is null)
            {
                return false;
            }
            var cartDetails = _context.CartsDetails
                                      .FirstOrDefault(c => c.BookId == bookId && c.ShoppingCartId == cart.Id);
            if (cartDetails is null)
            {
                return false;
            }
            else if(cartDetails.Quantity==1)
            {
                _context.Remove(cartDetails);
            }
            else
            {
                cartDetails.Quantity = cartDetails.Quantity - 1;
            }
            _context.SaveChanges();
            return true;
        }
        public async Task<ShoppingCart?> GetUserCart(string userId)
        {
            var cart = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }
        public async Task<ShoppingCart?> GetUserCartWithDetails()
        {
            var user = GetUserId();
            if(user is null) 
            {
                throw new Exception("user is not logged-in");
            }
            var cart = await _context.ShoppingCarts
                .Include(c => c.CartDetails)
                .ThenInclude(d => d.Book)
                .ThenInclude(b => b.Genre)
                .FirstOrDefaultAsync(c => c.UserId == user);

            return cart;
        }
        public async Task<int> GetUserCartItemsCount(string? userId="" )
        {
            if (string.IsNullOrEmpty(userId)) 
            {
                userId = GetUserId();
                if(userId is null)
                {
                    throw new Exception("User is not Logined");
                }
            }
            var data = await (from cart in _context.ShoppingCarts
                              join cartDetail in _context.CartsDetails
                              on cart.Id equals cartDetail.ShoppingCartId
                              where cart.UserId == userId 
                              select new { cartDetail.Id }
                        ).ToListAsync();
            return data.Count;
        }

        public void  DeleteCart (ShoppingCart cart)
        {
            _context.ShoppingCarts.Remove(cart);
            _context.SaveChanges();
        }

        private string? GetUserId()
        {
            var principal = _contextAccessor.HttpContext!.User;
            string userId = _userManager.GetUserId(principal)!;
            return userId;
        }
        
    }
}
