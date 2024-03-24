namespace BooksShop.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllWithGenre()
        {
            return await _context.Books.Include(b=>b.Genre).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetAllByBookTitle(string title = "")
        {
            title = title.ToLower();
            return await _context.Books.Include(b => b.Genre).Where(b=>b.BookName.StartsWith(title)).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetAllByBookNameAndGenreId(int GenreFilter = 0, string SearchTitle = "")
        {
            SearchTitle = SearchTitle.ToLower();
            IEnumerable<Book> books;
            if (SearchTitle == "")
            {
                books = await GetAllWithGenre();
            }
            else
            {
                books = await GetAllByBookTitle(SearchTitle);
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
