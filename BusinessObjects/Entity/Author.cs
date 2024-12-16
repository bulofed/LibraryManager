namespace BusinessObjects.Entity
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }

        public IEnumerable<Book>? Books { get; set; }
    }
}