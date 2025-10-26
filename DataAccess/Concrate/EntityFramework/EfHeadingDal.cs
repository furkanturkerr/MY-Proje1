using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Concrate.EntityFramework;

public class EfHeadingDal : GenericRepository<Heading>, IHeadingDal
{
    private IHeadingDal _headingDalImplementation;

    public EfHeadingDal (ProjeContext context) : base(context)
    {
        
    }

    public List<Heading> GetAllWithCategory()
    {
        using var c = new ProjeContext();
        return c.Headings
            .Include(h => h.Category)   
            .AsNoTracking()
            .ToList();
    }
}