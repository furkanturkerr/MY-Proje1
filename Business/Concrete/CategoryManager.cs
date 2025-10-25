using Business.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Insert(Category t)
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

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.GetAll(filter);
        }
    }
}