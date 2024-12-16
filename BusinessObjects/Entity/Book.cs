using BusinessObjects.Enum;

namespace BusinessObjects.Entity
{
    public abstract class Book : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Pages { get; set; }
        public TypeLivre Type { get; set; }
        public int Rate { get; set; }
        public required Author Author { get; set; }
    }
}