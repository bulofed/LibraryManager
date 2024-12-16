namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

        public required IEnumerable<Stock> Stocks { get; set; }
    }
}