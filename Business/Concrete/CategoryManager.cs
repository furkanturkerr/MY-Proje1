using System.Linq.Expressions;
using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;

namespace Business.Concrete;

public class CategoryManager : ICategoryService
{
    private ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    
    public List<Category> GetAll()
    {
        return _categoryDal.GetAll();
    }

    public void Add(Category t)
    {
        _categoryDal.Add(t);
    }

    public void Update(Category t)
    {
        _categoryDal.Update(t);
    }

    public void Delete(Category t)
    {
        _categoryDal.Delete(t);
    }

    public List<Category> GetAll(Expression<Func<Category, bool>> filter)
    {
        return _categoryDal.GetAll(filter);   
    }
}