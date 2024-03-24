namespace BooksShop.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;
        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Genre>> GetAll()
        {
            return await _context.Genres.OrderBy(g=>g.GenreName).AsNoTracking().ToListAsync(); 
        }
    }
}
