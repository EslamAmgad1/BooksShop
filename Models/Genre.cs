using System.ComponentModel.DataAnnotations;

namespace BooksShop.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string GenreName { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
