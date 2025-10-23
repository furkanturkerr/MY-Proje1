using System.Linq.Expressions;

namespace DataAcces.Abstract;

public interface IGenericDal<T>
{
    List<T> GetAll();
    void Add(T t);
    void Update(T t);
    void Delete(T t);
    List<T> GetAll(Expression<Func<T, bool>> filter);
}