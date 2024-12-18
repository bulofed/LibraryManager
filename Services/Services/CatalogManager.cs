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

        public IEnumerable<Book> GetCatalog(TypeLivre type)
        {
            var bookList = new List<Book>();
            foreach (var book in bookRepository.GetAll())
            {
                if (book.Type == type)
                {
                    bookList.Add(book);
                }
            }

            return bookList;
        }

        public Book FindBook(int id)
        {
            foreach (var book in bookRepository.GetAll())
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }
    }
}