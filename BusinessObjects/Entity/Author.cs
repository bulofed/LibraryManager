namespace BusinessObjects.Entity
{
    public abstract class Author : IEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required IEnumerable<Book> Books { get; set; }
    }
}