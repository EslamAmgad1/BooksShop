namespace BooksShop.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<DisplayBooksViewModel> Books { get; set; } = new List<DisplayBooksViewModel>();
        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
        public int GenreFilter { get; set; }

        public string SearchTitle = string.Empty;
    }
}
