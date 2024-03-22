namespace BooksShop.Repository
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetAll();
    }
}