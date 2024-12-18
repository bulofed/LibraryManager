namespace BusinessObjects.Entity
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; init; }
        public required string Address { get; init; }
        public required IEnumerable<Stock> Stocks { get; init; }
    }
}