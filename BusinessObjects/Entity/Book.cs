using System.ComponentModel.DataAnnotations.Schema;
using BusinessObjects.Enum;

namespace BusinessObjects.Entity
{
    [Table( "Book" )]
    public class Book : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; init; }
        public int Pages { get; init; }
        public TypeBook Type { get; init; }
        public int Rate { get; init; }
        
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        
    }
}