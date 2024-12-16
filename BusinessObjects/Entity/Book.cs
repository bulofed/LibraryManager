using BusinessObjects.Enum;

namespace BusinessObjects.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; init; }
        public int Pages { get; set; }
        public TypeLivre Type { get; init; }
        public int Rate { get; set; }
        public required Author Author { get; init; }
    }
}