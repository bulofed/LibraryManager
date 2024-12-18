using BusinessObjects;
using BusinessObjects.Enum;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly LibraryContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(LibraryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public T Get(int id)
    {
        return _dbSet.Find(id) ?? throw new InvalidOperationException();
    }

    public void Add(IEntity entity)
    {
        if (entity is T validEntity)
        {
            _dbSet.Add(validEntity);
            _context.SaveChanges();
        }
        else
        {
            throw new InvalidOperationException($"Entity is not of type {typeof(T).Name}");
        }
    }
}