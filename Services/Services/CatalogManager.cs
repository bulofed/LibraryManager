using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public class CatalogManager(IGenericRepository<Book> bookRepository)
    {
        public IEnumerable<Book> GetCatalog()
        {
            return bookRepository.GetAll();
        }
        
        public Book FindBook(int id)
        {
            return bookRepository.Get(id);
        }

        public IEnumerable<Book> GetCatalog(TypeBook type)
        {
            return bookRepository.GetAll().Where(book => book.Type == type);
        }
        
        public void AddBook(Book book)
        {
            bookRepository.Add(book);
        }
    }
}