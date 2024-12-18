namespace BusinessObjects.Entity
{
    public class Stock : IEntity
    {
        public int IdLibrary { get; init; }
        public int IdBook { get; init; }
        public required Library Library { get; init; }
        public required Book Book { get; init; }
        public int Id { get; set; }
    }
}