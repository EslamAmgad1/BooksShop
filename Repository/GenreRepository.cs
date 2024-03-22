namespace BooksShop.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.OrderBy(g=>g.GenreName).AsNoTracking().ToList(); 
        }
    }
}
