using BusinessObjects.Enum;

namespace BusinessObjects.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; init; }
        public int Pages { get; init; }
        public TypeBook Type { get; init; }
        public int Rate { get; init; }
    }
}