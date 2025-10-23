using System.Linq.Expressions;
using DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrate.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly ProjeContext _context;
    private readonly DbSet<T> _dbSet;
    
    public GenericRepository(ProjeContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public List<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(T t)
    {
       _dbSet.Add(t);
       _context.SaveChanges();
    }

    public void Update(T t)
    {
        _dbSet.Update(t);
        _context.SaveChanges();
    }

    public void Delete(T t)
    {
        _dbSet.Remove(t);
        _context.SaveChanges();
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Where(filter).ToList();
    }
}