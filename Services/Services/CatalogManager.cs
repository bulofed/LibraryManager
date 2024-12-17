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
            var booklist = new List<Book>();
            foreach (var book in bookRepository.GetAll())
            {
                if (book.Type == type)
                {
                    booklist.Add(book);
                }
            }

            return booklist;
        }

        public Book Findbook(int id)
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