namespace BooksShop.Repository
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<Genre>> GetAll();
    }
}
