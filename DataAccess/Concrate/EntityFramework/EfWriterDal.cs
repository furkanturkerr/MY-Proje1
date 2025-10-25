using DataAcces.Abstract;
using DataAcces.Concrate.Repositories;
using Entity.Concrete;

namespace DataAcces.Concrate.EntityFramework;

public class EfWriterDal : GenericRepository<Writer>, IWriterDal
{
    public EfWriterDal (ProjeContext context) : base(context)
    {
        
    }
}