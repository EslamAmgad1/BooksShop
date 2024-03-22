namespace BooksShop
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAllWithGenre();
        public IEnumerable<Book> GetAllByBookTitle(string title = "");
        public IEnumerable<Book> GetAllByBookNameAndGenreId(int GenreFilter = 0, string SearchTitle = "");
    }
}