namespace BooksShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IActionResult> Create()
        {
            var isCreated = await _orderRepository.Create();
            if (!isCreated) 
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> GetUserOrders()
        {
            var orders = await _orderRepository.GetAllUserOrdersWithDetails();
            return View(orders);
        }
    }
}
