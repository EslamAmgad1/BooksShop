namespace BooksShop.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllWithGenre()
        {
            return _context.Books.Include(b=>b.Genre).AsNoTracking().ToList();
        }
        public IEnumerable<Book> GetAllByBookTitle(string title = "")
        {
            title = title.ToLower();
            return _context.Books.Include(b => b.Genre).Where(b=>b.BookName.StartsWith(title)).AsNoTracking().ToList();
        }
        public IEnumerable<Book> GetAllByBookNameAndGenreId(int GenreFilter = 0, string SearchTitle = "")
        {
            SearchTitle = SearchTitle.ToLower();
            IEnumerable<Book> books;
            if (SearchTitle == "")
            {
                books = GetAllWithGenre();
            }
            else
            {
                books = GetAllByBookTitle(SearchTitle);
            }
            if (GenreFilter > 0)
            {
               return books = books.Where(b=>b.GenreId==GenreFilter).ToList();
            }
            else
            {
                return books;
            }

        }

    }
}
