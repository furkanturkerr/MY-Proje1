using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrate.EntityFramework
{
    public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
    {
        private readonly ProjeContext _context;

        public EfHeadingDal(ProjeContext context) : base(context)
        {
            _context = context;
        }

        public List<Heading> GetAllWithCategory()
        {
            return _context.Headings
                .Include(h => h.Category)
                .AsNoTracking()
                .ToList();
        }
    }
}