using DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcces.Concrate.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ProjeContext _context;

        public GenericRepository(ProjeContext context)
        {
            _context = context;
        }

        public void Add(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return filter == null 
                ? _context.Set<T>().ToList()
                : _context.Set<T>().Where(filter).ToList();
        }
    }
}