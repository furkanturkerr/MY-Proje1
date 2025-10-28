using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfImageDal : GenericRepository<Image>, IImageDal
{
    public EfImageDal(ProjeContext context) : base(context)
    {
        
    }
}