using BusinessObjects;

namespace DataAccessLayer.Repository;

public interface IGenericRepository<out T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Add(IEntity entity);
}
