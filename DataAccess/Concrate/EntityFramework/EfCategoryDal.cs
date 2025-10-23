using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
    public EfCategoryDal(ProjeContext context) : base(context)
    {
        
    }
}