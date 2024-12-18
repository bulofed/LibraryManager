using BusinessObjects;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository;

public interface IGenericRepository<out T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    IEnumerable<T> Find(Func<T, bool> predicate);
    void Add(IEntity entity);
}
