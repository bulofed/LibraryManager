namespace BusinessObjects.Entity
{
    public abstract class Stock : IEntity
    {
        public int IdLibrary { get; set; }
        public int IdBook { get; set; }

        public required Library Library { get; set; }
        public required Book Book { get; set; }
        public int Id { get; set; }
    }
}