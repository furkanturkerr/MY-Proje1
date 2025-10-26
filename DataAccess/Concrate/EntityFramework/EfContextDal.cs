using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfContextDal : GenericRepository<Content>, IContentDal
{
    public EfContextDal (ProjeContext context) : base(context)
    {
        
    }
}