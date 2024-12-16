using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository(List<Author> authors)
    {
        public IEnumerable<Author> GetAll()
        {
            return authors;
        }

        public Author Get(int id)
        {
            return authors.FirstOrDefault(a => a.Id == id) ?? throw new InvalidOperationException();
        }
    }
}