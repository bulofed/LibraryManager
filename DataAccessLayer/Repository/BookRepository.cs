using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class BookRepository(List<Book> books)
    {
        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Book Get(int id)
        {
            return books.FirstOrDefault(b => b.Id == id) ?? throw new InvalidOperationException();
        }

        public IEnumerable<Book> GetByType(string type)
        {
            return books.Where(b => b.Type.ToString() == type);
        }
    }
}