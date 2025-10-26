using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrate.EntityFramework
{
    public class EfContentDal : GenericRepository<Content>, IContentDal
    {
        private readonly ProjeContext _context;

        public EfContentDal(ProjeContext context) : base(context)
        {
            _context = context;
        }
        public List<Content> GetListByHeadingIdWithWriter(int headingId)
        {
            return _context.Contents
                .Where(x => x.HeadingId == headingId)
                .Include(x => x.Writer)
                .OrderByDescending(x => x.ContentTime)
                .AsNoTracking()
                .ToList();
        }
    }
}