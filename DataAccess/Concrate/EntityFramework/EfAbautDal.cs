using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfAbautDal : GenericRepository<Abaut>, IAbautDal
{
    public EfAbautDal (ProjeContext context) : base(context)
    {
        
    }
}