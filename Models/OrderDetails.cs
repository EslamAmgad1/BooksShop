namespace BooksShop.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }


        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public Order Order { get; set; } = default!;

        public Book Book { get; set; } = default!;

    }
}
