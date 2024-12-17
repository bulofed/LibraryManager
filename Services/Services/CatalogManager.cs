using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;

namespace Services.Services;

public class CatalogManager(BookRepository bookRepository)
{
    public IEnumerable<Book> GetCatalog()
    {
        return bookRepository.GetAll();
    }

    public IEnumerable<Book> GetCatalog(TypeLivre type)
    {
        return bookRepository.GetAll().Where(book => book.Type == type);
    }

    public Book? FindBook(int id)
    {
        try
        {
            return bookRepository.Get(id);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }
}