namespace BooksShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<IActionResult> AddItem(int bookId, int Redirect = 0 )
        {
            var NumberOfItemsInCart = await _cartRepository.AddItem(bookId);
            if(Redirect == 0)
            {
                return Ok(NumberOfItemsInCart);
            }
            return  RedirectToAction("GetUserCart");
        }
        public async Task<IActionResult> RemoveItem(int bookId)
        {
             var isDeleted = await _cartRepository.RemoveItem(bookId);
            if (!isDeleted)
                return BadRequest();
            return RedirectToAction("GetUserCart");
        }
        public async Task<IActionResult> GetUserCart()
        {
            var UserCart = await _cartRepository.GetUserCartWithDetails();
            return View(UserCart);
        }
        public async Task<IActionResult> GetTotalNumberOfItemsInCart()
        {
            var TotalNumber = await _cartRepository.GetUserCartItemsCount();
            return Ok(TotalNumber);
        }
        

    }
}
