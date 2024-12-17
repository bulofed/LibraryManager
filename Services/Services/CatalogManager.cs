using BusinessObjects.Entity;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public class CatalogManager(IGenericRepository<Book> bookRepository)
    {
        public IEnumerable<Book> GetCatalog()
        {
            return bookRepository.GetAll();
        }
    }
}