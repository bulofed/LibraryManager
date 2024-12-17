using BusinessObjects.Entity;

namespace DataAccessLayer.Repository;

public class AuthorRepository : IGenericRepository<Author>
{
    private readonly List<Author> _authors =
    [
        new Author
        {
            Id = 1, FirstName = "Alexandre", LastName = "Dumas",
        }
    ];
    public IEnumerable<Author> GetAll()
    {
        return _authors;
    }

    public Author Get(int id)
    {
        return _authors.First(a => a.Id == id);
    }
}
