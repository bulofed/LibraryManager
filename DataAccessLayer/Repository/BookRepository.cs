using System.Collections;
using BusinessObjects.Entity;
using DataAccessLayer.Contexts; 

namespace DataAccessLayer.Repository;

public class BookRepository(LibraryContext context) : IGenericRepository<Book>
{
    public IEnumerable<Book> GetAll()
    {
        return context.Books;
    }

    public Book Get(int id)
    {
        return context.Books.First(book => book.Id == id);
    }
    
    public IEnumerable GetByType(string type)
    {
        return context.Books.Where(b => b.Type.ToString() == type);
    }
}