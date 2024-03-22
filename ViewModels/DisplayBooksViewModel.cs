namespace BooksShop.ViewModels
{
    public class DisplayBooksViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public Genre Genre { get; set; } = default!;

    }
}
