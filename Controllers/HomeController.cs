namespace BooksShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        public HomeController(IBookRepository bookRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        public IActionResult Index(int GenreFilter = 0 , string SearchTitle = "")
        {
            var displayBooks = _bookRepository.GetAllByBookNameAndGenreId(GenreFilter, SearchTitle).Select(b => new DisplayBooksViewModel
            {
                BookId = b.Id,
                BookName = b.BookName,
                AuthorName = b.AuthorName!,
                Genre = b.Genre,
                Price = b.Price,
                Image = b.Image!
            });

            HomeIndexViewModel model = new()
            {
                Books = displayBooks,
                Genres = _genreRepository.GetAll(),
                GenreFilter = GenreFilter,
                SearchTitle = SearchTitle
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
