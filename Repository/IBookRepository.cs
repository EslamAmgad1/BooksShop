namespace BooksShop
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllWithGenre();
        public Task<IEnumerable<Book>> GetAllByBookTitle(string title = "");
        public Task<IEnumerable<Book>> GetAllByBookNameAndGenreId(int GenreFilter = 0, string SearchTitle = "");
    }
}
