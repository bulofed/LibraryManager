using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository(List<Library> libraries)
    {
        public IEnumerable<Library> GetAll()
        {
            return libraries;
        }

        public Library Get(int id)
        {
            return libraries.First(l => l.Id == id);
        }
    }
}