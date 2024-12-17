using System.Collections;
using BusinessObjects.Entity;
using BusinessObjects.Enum;

namespace DataAccessLayer.Repository;

public class BookRepository : IGenericRepository<Book>
{
    private readonly List<Book> _books =
    [
        new Book
        {
            Id = 1, Name = "Le Comte de Monte-Cristo", Pages = 900, Type = TypeLivre.Aventure, Rate = 10
        },
        new Book
        {
            Id = 2, Name = "Les Trois Mousquetaires", Pages = 300, Type = TypeLivre.Aventure, Rate = 9
        },
        new Book
        {
            Id = 3, Name = "Apprendre le Java", Pages = 900, Type = TypeLivre.Enseignement, Rate = 10
        }
    ];

    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    public Book Get(int id)
    {
        return _books.First(book => book.Id == id);
    }
    
    public IEnumerable GetByType(string type)
    {
        return _books.Where(b => b.Type.ToString() == type);
    }
}